using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelButtonController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameHelper.QuitGame();
        }
    }
    public void TypeOne()
    {
        MusicType.musicType = MusicTypeValue.TypeOne;
        SceneManager.LoadScene("Game");
    }
    public void TypeTwo()
    {
        MusicType.musicType = MusicTypeValue.TypeTwo;
        SceneManager.LoadScene("Game");
    }
    public void TypeThree()
    {
        MusicType.musicType = MusicTypeValue.TypeThree;
        SceneManager.LoadScene("Game");
    }
    public void TypeFour()
    {
        MusicType.musicType = MusicTypeValue.TypeFour;
        SceneManager.LoadScene("Game");
    }
    public void Back()
    {
        SceneManager.LoadScene("SelectMode");
    }
}
