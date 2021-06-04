using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectModeButtonController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameHelper.QuitGame();
        }
    }
    public void MainGame()
    {
        MusicType.musicType = MusicTypeValue.Main;
        SceneManager.LoadScene("Game");
    }
    public void TrainGame()
    {
        SceneManager.LoadScene("SelectLevel");
    }
    public void Back()
    {
        SceneManager.LoadScene("Begin");
    }
}
