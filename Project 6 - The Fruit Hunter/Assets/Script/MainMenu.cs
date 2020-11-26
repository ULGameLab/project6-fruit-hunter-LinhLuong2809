using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Text myScore;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(myScore)
        {
            myScore.text = "Score = " + Score.score;
        }
    }

    public void quitGameButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("firstperson");
    }

    public void StartThirdButton()
    {
        SceneManager.LoadScene("ThirdPerson");
    }

    public void RestartGameButton()
    {
        Score.score = 0;
        SceneManager.LoadScene("StartScreen");
    }
}
