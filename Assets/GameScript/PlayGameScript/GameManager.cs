using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music;

    public bool startPlaying;

    public static bool hasStarted;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote;
    public int scorePerGreatNote;
    public int scorePerPerfectNote;

    private int normalHits;
    private int greatHits;
    private int perfectHits;
    private int missHits;

    public GameObject resultScreen;
    public Text percentHitText;
    public Text normalHitText;
    public Text greatHitText;
    public Text perfectHitText;
    public Text missHitText;
    public Text rankHitText;
    public Text finalScoreHitText;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;
    void Start()
    {
        init();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameHelper.QuitGame();
        }
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                hasStarted = true;
                music.Play();
                GameObject.Find("Tips").SetActive(false);
            }
        }
        else
        {
            if(!music.isPlaying && !resultScreen.activeInHierarchy)
            {
                resultScreen.SetActive(true);
                music.Stop();
                destroyCloneArrows();
                Destroy(GameObject.Find("MusicPlayer"));

                GameObject Background = GameObject.Find("Background");
                Background.transform.position = new Vector3(Background.transform.position.x, Background.transform.position.y, 0.0f);
                setFinalValue();
            }
        }
    }
    private void init()
    {
        instance = this;

        currentMultiplier = 1;
        scorePerNote = 100;
        scorePerGreatNote = 150;
        scorePerPerfectNote = 225;

        if (MusicType.musicType == MusicTypeValue.Main) music = GameObject.Find("MusicPlayer-Main").GetComponent<AudioSource>();
        if (MusicType.musicType == MusicTypeValue.TypeOne) music = GameObject.Find("MusicPlayer-1").GetComponent<AudioSource>();
        if (MusicType.musicType == MusicTypeValue.TypeTwo) music = GameObject.Find("MusicPlayer-2").GetComponent<AudioSource>();
        if (MusicType.musicType == MusicTypeValue.TypeThree) music = GameObject.Find("MusicPlayer-3").GetComponent<AudioSource>();
        if (MusicType.musicType == MusicTypeValue.TypeFour) music = GameObject.Find("MusicPlayer-4").GetComponent<AudioSource>();
    }
    private void destroyCloneArrows()
    {
        GameObject[] cloneArrows = GameObject.FindGameObjectsWithTag("CloneArrow");
        foreach (var item in cloneArrows)
        {
            Destroy(item);
        }
    }

    private void setFinalValue()
    {
        int totalArrow = ArrowCreatController.totalArrow;
        float totalHit, percentHit;
        Rank finalRank;

        normalHitText.text = normalHits.ToString();
        greatHitText.text = greatHits.ToString();
        perfectHitText.text = perfectHits.ToString();
        missHitText.text = missHits.ToString();

        totalHit = normalHits + greatHits + perfectHits;
        if (totalArrow == 0)
        {
            percentHit = 0f;
            finalRank = Rank.F;
        }
        else
        {
            percentHit = (totalHit / totalArrow) * 100f;
            finalRank = judgeRank();
        }
        
        percentHitText.text = percentHit.ToString("F1") + "%";
        finalScoreHitText.text = currentScore.ToString();
        rankHitText.text = finalRank.ToString();
    }
    private Rank judgeRank()
    {
        Rank finalRank;
        //方法一：根据perfectHits数来判定
        //int totalArrow = ArrowCreatController.totalArrow;
        //if (perfectHits >= (float)((int)Rank.SSS / 100f * totalArrow)) finalRank = Rank.SSS;
        //else if (perfectHits >= (float)((int)Rank.SS / 100f * totalArrow)) finalRank = Rank.SS;
        //else if (perfectHits >= (float)((int)Rank.S / 100f * totalArrow)) finalRank = Rank.S;
        //else if (perfectHits >= (float)((int)Rank.A / 100f * totalArrow)) finalRank = Rank.A;
        //else if (perfectHits >= (float)((int)Rank.B / 100f * totalArrow)) finalRank = Rank.B;
        //else if (perfectHits >= (float)((int)Rank.C / 100f * totalArrow)) finalRank = Rank.C;
        //else finalRank = Rank.D;
        //return finalRank;

        //方法二：根据得分
        if (currentScore >= 1e5) finalRank = Rank.SSS;//十万
        else if (currentScore >= 9e4) finalRank = Rank.SS;//九万
        else if (currentScore >= 8e4 + 5e3) finalRank = Rank.S;//八万
        else if (currentScore >= 6e4 + 5e3) finalRank = Rank.A;//六万五千
        else if (currentScore >= 4e4) finalRank = Rank.B;//四万
        else if (currentScore >= 2e4) finalRank = Rank.C;//两万
        else if (currentScore >= 1e4) finalRank = Rank.D;//一万
        else finalRank = Rank.F;
        return finalRank;
    }
    public void NoteHit()
    {
        scoreText.text = "当前得分: " + currentScore;
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        multiText.text = "当前倍率: X" + currentMultiplier;
        
    }
    public void NoteMissed()
    {
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "当前倍率: X" + currentMultiplier;
        missHits++;
    }
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        normalHits++;
    }
    public void GreatHit()
    {
        currentScore += scorePerGreatNote * currentMultiplier;
        NoteHit();
        greatHits++;
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        perfectHits++;
    }

}
