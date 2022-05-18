/*
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    public List<GameObject> Questions = new List<GameObject>();

    public GameObject Results;
    public Text QuestionCountText;

    [Header("Monster Parts")]
    public Image test;

    public Score score;
    public ScoreManager scoreManager;

    public InputField usernameInput;
    public string userName;
    public float MonsterProgress;

    public bool hasFinished = false;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    #region QuestionCounter
    public void Update()
    {
        if (Questions[0].activeInHierarchy == true)
        {
            userName = usernameInput.text;
            hasFinished = false;
            QuestionCountText.text = "Question 1/12";
        }
        if (Questions[1].activeInHierarchy == true)
        {
            QuestionCountText.text = "Question 2/12";
        }
        if (Questions[2].activeInHierarchy == true)
        {
            QuestionCountText.text = "Question 3/12";
        }
        if (Questions[3].activeInHierarchy == true)
        {
            QuestionCountText.text = "Question 4/12";
        }
        if (Questions[4].activeInHierarchy == true)
        {
            QuestionCountText.text = "Question 5/12";
        }
        if (Questions[5].activeInHierarchy == true)
        {
            QuestionCountText.text = "Question 6/12";
        }
        if (Questions[6].activeInHierarchy == true)
        {
            QuestionCountText.text = "Question 7/12";
        }
        if (Questions[7].activeInHierarchy == true)
        {
            QuestionCountText.text = "Question 8/12";
        }
        if (Questions[8].activeInHierarchy == true)
        {
            QuestionCountText.text = "Question 9/12";
        }
        if (Questions[9].activeInHierarchy == true)
        {
            QuestionCountText.text = "Question 10/12";
        }
        if (Questions[10].activeInHierarchy == true)
        {
            QuestionCountText.text = "Question 11/12";
        }
        if (Questions[11].activeInHierarchy == true)
        {
            QuestionCountText.text = "Question 12/12";
        }
        if (Results.activeInHierarchy == true)
        {
            QuestionCountText.text = "";

            if (hasFinished == false)
            {
                MonsterProgress = score.monster;
                scoreManager.AddScore(new Score(name: userName, monster: MonsterProgress));
                scoreManager.SaveScore();
                hasFinished = true;
            }
        }
    }
    #endregion

    #region Question 1 (Choose an element)
    public void Water()
    {
        Questions[0].SetActive(false);
        Questions[1].SetActive(true);
        score.monster += 1;
    }
    public void Fire()
    {
        Questions[0].SetActive(false);
        Questions[1].SetActive(true);
        test.GetComponent<Image>().color = new Color32(55, 32, 124, 100);
        score.monster += 2;
    }
    public void Earth()
    {
        Questions[0].SetActive(false);
        Questions[1].SetActive(true);
        score.monster += 3;
    }
    public void Air()
    {
        Questions[0].SetActive(false);
        Questions[1].SetActive(true);
        score.monster += 4;
    }
    #endregion

    #region Question 2 (Choose your favorite season)
    public void Autumn()
    {
        Questions[1].SetActive(false);
        Questions[2].SetActive(true);
        score.monster += 1;
    }
    public void Winter()
    {
        Questions[1].SetActive(false);
        Questions[2].SetActive(true);
        score.monster += 2;
    }
    public void Spring()
    {
        Questions[1].SetActive(false);
        Questions[2].SetActive(true);
    }
    public void Summer()
    {
        Questions[1].SetActive(false);
        Questions[2].SetActive(true);
        score.monster += 4;
    }
    #endregion

    #region Question 3 (Choose your favorite biome)
    public void Forest()
    {
        Questions[2].SetActive(false);
        Questions[3].SetActive(true);
        score.monster += 1;
    }
    public void Desert()
    {
        Questions[2].SetActive(false);
        Questions[3].SetActive(true);
        score.monster += 2;
    }
    public void Tundra()
    {
        Questions[2].SetActive(false);
        Questions[3].SetActive(true);
        score.monster += 3;
    }
    public void Ocean()
    {
        Questions[2].SetActive(false);
        Questions[3].SetActive(true);
        score.monster += 4;
    }
    #endregion

    #region Question 4 (Choose your favorite dinosaur)
    public void Ankylosaurus()
    {
        Questions[3].SetActive(false);
        Questions[4].SetActive(true);
        score.monster += 1;
    }
    public void Stegosaurus()
    {
        Questions[3].SetActive(false);
        Questions[4].SetActive(true);
        score.monster += 2;
    }
    public void Spinosaurus()
    {
        Questions[3].SetActive(false);
        Questions[4].SetActive(true);
        score.monster += 3;
    }
    public void Tyrannosaurus()
    {
        Questions[3].SetActive(false);
        Questions[4].SetActive(true);
        score.monster += 4;
    }
    #endregion

    #region Question 5 (What is your eye color?)
    public void Blue()
    {
        Questions[4].SetActive(false);
        Questions[5].SetActive(true);
        score.monster += 1;
    }
    public void Green()
    {
        Questions[4].SetActive(false);
        Questions[5].SetActive(true);
        score.monster += 2;
    }
    public void Brown()
    {
        Questions[4].SetActive(false);
        Questions[5].SetActive(true);
        score.monster += 3;
    }
    public void Other()
    {
        Questions[4].SetActive(false);
        Questions[5].SetActive(true);
        score.monster += 4;
    }
    #endregion

    #region Question 6 (What is your hobby?)
    public void Running()
    {
        Questions[5].SetActive(false);
        Questions[6].SetActive(true);
        score.monster += 1;
    }
    public void Gymnastics()
    {
        Questions[5].SetActive(false);
        Questions[6].SetActive(true);
        score.monster += 2;
    }
    public void Gaming()
    {
        Questions[5].SetActive(false);
        Questions[6].SetActive(true);
        score.monster += 3;
    }
    public void Drawing()
    {
        Questions[5].SetActive(false);
        Questions[6].SetActive(true);
        score.monster += 4;
    }
    #endregion

    #region Question 7 (What is your favorite color?)
    public void Unknown1()
    {
        Questions[6].SetActive(false);
        Questions[7].SetActive(true);
        score.monster += 1;
    }
    public void Unknown2()
    {
        Questions[6].SetActive(false);
        Questions[7].SetActive(true);
        score.monster += 2;
    }
    public void Unknown3()
    {
        Questions[6].SetActive(false);
        Questions[7].SetActive(true);
        score.monster += 3;
    }
    public void Unknown4()
    {
        Questions[6].SetActive(false);
        Questions[7].SetActive(true);
        score.monster += 4;
    }
    #endregion

    #region Question 8 (What kind of animal is your favorite?)
    public void Herbivore()
    {
        Questions[7].SetActive(false);
        Questions[8].SetActive(true);
        score.monster += 1;
    }
    public void Carnivore()
    {
        Questions[7].SetActive(false);
        Questions[8].SetActive(true);
        score.monster += 2;
    }
    public void Omnivore()
    {
        Questions[7].SetActive(false);
        Questions[8].SetActive(true);
        score.monster += 3;
    }
    public void Insectivore()
    {
        Questions[7].SetActive(false);
        Questions[8].SetActive(true);
        score.monster += 4;
    }
    #endregion

    #region Question 9 (What is your fear?)
    public void Heights()
    {
        Questions[8].SetActive(false);
        Questions[9].SetActive(true);
        score.monster += 1;
    }
    public void The_Dark()
    {
        Questions[8].SetActive(false);
        Questions[9].SetActive(true);
        score.monster += 2;
    }
    public void The_Ocean()
    {
        Questions[8].SetActive(false);
        Questions[9].SetActive(true);
        score.monster += 3;
    }
    public void Snakes_and_or_Spiders()
    {
        Questions[8].SetActive(false);
        Questions[9].SetActive(true);
        score.monster += 4;
    }
    #endregion

    #region Question 10 (What power would you have if you were a superhero?)
    public void Invisibility()
    {
        Questions[9].SetActive(false);
        Questions[10].SetActive(true);
        score.monster += 1;
    }
    public void Flight()
    {
        Questions[9].SetActive(false);
        Questions[10].SetActive(true);
        score.monster += 2;
    }
    public void Super_Strength()
    {
        Questions[9].SetActive(false);
        Questions[10].SetActive(true);
        score.monster += 3;
    }
    public void Breathing_under_water()
    {
        Questions[9].SetActive(false);
        Questions[10].SetActive(true);
        score.monster += 4;
    }
    #endregion

    #region Question 11 (What is your favorite music genre?)
    public void Rock()
    {
        Questions[10].SetActive(false);
        Questions[11].SetActive(true);
        score.monster += 1;
    }
    public void Pop()
    {
        Questions[10].SetActive(false);
        Questions[11].SetActive(true);
        score.monster += 2;
    }
    public void Jazz()
    {
        Questions[10].SetActive(false);
        Questions[11].SetActive(true);
        score.monster += 3;
    }
    public void Rap()
    {
        Questions[10].SetActive(false);
        Questions[11].SetActive(true);
        score.monster += 4;
    }
    #endregion

    #region Question 12 (What is your favorite flavor?)
    public void Sweet()
    {
        Questions[11].SetActive(false);
        Results.SetActive(true);
        score.monster += 1;
    }
    public void Sour()
    {
        Questions[11].SetActive(false);
        Results.SetActive(true);
        score.monster += 2;
    }
    public void Salty()
    {
        Questions[11].SetActive(false);
        Results.SetActive(true);
        score.monster += 3;
    }
    public void Savory()
    {
        Questions[11].SetActive(false);
        Results.SetActive(true);
        score.monster += 4;
    }
    #endregion
}
*/