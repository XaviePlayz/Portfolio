using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject StartScreen, SetUsername, Question_1, ResultsScreen, QuestionCounter, goToScoreboard, Quiz;
    public InputField usernameInput;
    public Button continueButton;

    public void Start()
    {
        StartScreen.SetActive(true);
        Question_1.SetActive(false);
        QuestionCounter.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (SetUsername.activeInHierarchy == true)
        {
            if (usernameInput.text.Length >= 1)
            {
                continueButton.interactable = true;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Question_1.SetActive(true);
                    SetUsername.SetActive(false);
                    QuestionCounter.SetActive(true);
                }
            }
            else
            {
                continueButton.interactable = false;
            }
        }
    }

    public void SetUserName()
    {
        SetUsername.SetActive(true);
        StartScreen.SetActive(false);
    }

    public void OnClickConnet()
    {
        Question_1.SetActive(true);
        SetUsername.SetActive(false);
        QuestionCounter.SetActive(true);
    }

    public void Retry()
    {
        StartScreen.SetActive(true);
        ResultsScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void GoToScoreboard()
    {
        Quiz.SetActive(false);
        goToScoreboard.SetActive(true);
        SceneManager.LoadScene(0);
    }
    public void Return()
    {
        Quiz.SetActive(true);
        goToScoreboard.SetActive(false);
    }
}
