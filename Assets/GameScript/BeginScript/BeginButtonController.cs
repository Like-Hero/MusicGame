using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginButtonController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameHelper.QuitGame();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SelectMode");
    }
    public void QuitGame()
    {
        GameHelper.QuitGame();
    }

}
