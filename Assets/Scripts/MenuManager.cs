using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_Text playerName;
    public TMP_Text highscoreText;
    public void Start()
    {
        if (TheOverseer.instance.highestScore > 0)
        {
            highscoreText.text = "Current Highscore: " + TheOverseer.instance.highestPlayer + " with " + TheOverseer.instance.highestScore + " Points";
        }    
    }

    public void StartGame()
    {
        if (string.IsNullOrWhiteSpace(playerName.text))
        {
            playerName.text = "Jason";
        }
        TheOverseer.instance.playerName = playerName.text;
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        TheOverseer.instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit()
#endif
    }
}
