using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    public List<GameObject> Questions = new List<GameObject>();
    public List<bool> AnsweredQuestions = new List<bool>();
    public Button NextButton, PreviousButton, CheckResultsButton;

    public GameObject StartScreen, SetUsername, Results;
    public GameObject QuestionBackground;
    public Text QuestionCountText;

    public Score score;
    public ScoreManager scoreManager;

    public InputField usernameInput;
    public string userName;
    public float MonsterProgress;

    public int nextquestion;
    public int currentquestion;
    public int previousquestion;

    public bool hasFinished = false;
    public bool LastQuestionAnswered = false;

    [Header("Monster Parts")]
    public List<GameObject> Elements = new List<GameObject>();
    public List<GameObject> Pattern = new List<GameObject>();
    public List<GameObject> Eyes = new List<GameObject>();
    public List<GameObject> Feet = new List<GameObject>();
    public List<GameObject> Mouth = new List<GameObject>();
    public List<GameObject> Base = new List<GameObject>();
    public List<GameObject> Secondary = new List<GameObject>();
    public List<GameObject> Tail = new List<GameObject>();
    public List<GameObject> Ears = new List<GameObject>();
    public List<GameObject> Horns = new List<GameObject>();


    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    #region QuestionCounter
    public void Update()
    {
        if (currentquestion == 12)
        {
            NextButton.interactable = false;
        }
        else
        {
            NextButton.interactable = true;
        }

        if (currentquestion == 1)
        {
            PreviousButton.interactable = false;
        }
        else
        {
            PreviousButton.interactable = true;
        }

        #region Updates Question Counter
        if (Questions[0].activeInHierarchy == true)
        {
            userName = usernameInput.text;
            hasFinished = false;
        }        
        #endregion

        #region Updates Monster Parts
        if (Results.activeInHierarchy == true)
        {
            QuestionCountText.text = "";

            #region 1-Elements
            if (WaterElement == true)
            {
                Elements[0].SetActive(true);
            }

            if (FireElement == true)
            {
                Elements[1].SetActive(true);
            }

            if (EarthElement == true)
            {
                Elements[2].SetActive(true);
            }

            if (AirElement == true)
            {
                Elements[3].SetActive(true);
            }
            #endregion

            #region 3-Patterns
            if (StripePattern == true)
            {
                Pattern[0].SetActive(true);
            }

            if (SnakePattern == true)
            {
                Pattern[1].SetActive(true);
                Pattern[2].SetActive(true);
            }

            if (Spots == true)
            {
                Pattern[3].SetActive(true);
            }

            if (Countershading == true)
            {
                Pattern[4].SetActive(true);
            }
            #endregion

            #region 5-Eyes
            if (CuddlefishEyes == true)
            {
                Eyes[0].SetActive(true);
            }

            if (CatEyes == true)
            {
                Eyes[1].SetActive(true);
            }

            if (GoatEyes == true)
            {
                Eyes[2].SetActive(true);
            }

            if (NormalEyes == true)
            {
                Eyes[3].SetActive(true);
            }
            #endregion

            #region 6-Feet
            if (Hooves == true)
            {
                Feet[0].SetActive(true);
            }
            if (CatPaws == true)
            {
                Feet[1].SetActive(true);
            }

            if (RatFeet == true)
            {
                Feet[2].SetActive(true);
            }

            if (BirdFeet == true)
            {
                Feet[3].SetActive(true);
            }
            #endregion

            #region 7-Primary Colors
            if (red == true)
            {
                //3 - Pattern
                Pattern[1].GetComponent<Image>().color = RedColorPrimary;

                //6 - Feet
                Feet[0].GetComponent<Image>().color = RedColorPrimary;
                Feet[1].GetComponent<Image>().color = RedColorPrimary;
                Feet[2].GetComponent<Image>().color = RedColorPrimary;
                Feet[3].GetComponent<Image>().color = RedColorPrimary;


                //8 - Mouth
                Mouth[0].GetComponent<Image>().color = RedColorPrimary;
                Mouth[1].GetComponent<Image>().color = RedColorPrimary;
                Mouth[2].GetComponent<Image>().color = RedColorPrimary;
                Mouth[3].GetComponent<Image>().color = RedColorPrimary;

                //9 - Base
                Base[0].GetComponent<Image>().color = RedColorPrimary;
                Base[1].GetComponent<Image>().color = RedColorPrimary;
                Base[2].GetComponent<Image>().color = RedColorPrimary;
                Base[3].GetComponent<Image>().color = RedColorPrimary;
                Secondary[0].GetComponent<Image>().color = RedColorPrimary;
                Secondary[1].GetComponent<Image>().color = RedColorPrimary;

                //10 - Tail
                Tail[0].GetComponent<Image>().color = RedColorPrimary;
                Tail[2].GetComponent<Image>().color = RedColorPrimary;
                Tail[4].GetComponent<Image>().color = RedColorPrimary;
                Tail[6].GetComponent<Image>().color = RedColorPrimary;

                //11 - Ears
                Ears[0].GetComponent<Image>().color = RedColorPrimary;
                Ears[2].GetComponent<Image>().color = RedColorPrimary;
                Ears[4].GetComponent<Image>().color = RedColorPrimary;
                Ears[6].GetComponent<Image>().color = RedColorPrimary;
            }

            if (orange == true)
            {
                //3 - Pattern
                Pattern[1].GetComponent<Image>().color = OrangeColorPrimary;

                //6 - Feet
                Feet[0].GetComponent<Image>().color = OrangeColorPrimary;
                Feet[1].GetComponent<Image>().color = OrangeColorPrimary;
                Feet[2].GetComponent<Image>().color = OrangeColorPrimary;
                Feet[3].GetComponent<Image>().color = OrangeColorPrimary;


                //8 - Mouth
                Mouth[0].GetComponent<Image>().color = OrangeColorPrimary;
                Mouth[1].GetComponent<Image>().color = OrangeColorPrimary;
                Mouth[2].GetComponent<Image>().color = OrangeColorPrimary;
                Mouth[3].GetComponent<Image>().color = OrangeColorPrimary;

                //9 - Base
                Base[0].GetComponent<Image>().color = OrangeColorPrimary;
                Base[1].GetComponent<Image>().color = OrangeColorPrimary;
                Base[2].GetComponent<Image>().color = OrangeColorPrimary;
                Base[3].GetComponent<Image>().color = OrangeColorPrimary;
                Secondary[0].GetComponent<Image>().color = OrangeColorPrimary;
                Secondary[1].GetComponent<Image>().color = OrangeColorPrimary;

                //10 - Tail
                Tail[0].GetComponent<Image>().color = OrangeColorPrimary;
                Tail[2].GetComponent<Image>().color = OrangeColorPrimary;
                Tail[4].GetComponent<Image>().color = OrangeColorPrimary;
                Tail[6].GetComponent<Image>().color = OrangeColorPrimary;

                //11 - Ears
                Ears[0].GetComponent<Image>().color = OrangeColorPrimary;
                Ears[2].GetComponent<Image>().color = OrangeColorPrimary;
                Ears[4].GetComponent<Image>().color = OrangeColorPrimary;
                Ears[6].GetComponent<Image>().color = OrangeColorPrimary;
            }

            if (yellow == true)
            {
                //3 - Pattern
                Pattern[1].GetComponent<Image>().color = YellowColorPrimary;

                //6 - Feet
                Feet[0].GetComponent<Image>().color = YellowColorPrimary;
                Feet[1].GetComponent<Image>().color = YellowColorPrimary;
                Feet[2].GetComponent<Image>().color = YellowColorPrimary;
                Feet[3].GetComponent<Image>().color = YellowColorPrimary;


                //8 - Mouth
                Mouth[0].GetComponent<Image>().color = YellowColorPrimary;
                Mouth[1].GetComponent<Image>().color = YellowColorPrimary;
                Mouth[2].GetComponent<Image>().color = YellowColorPrimary;
                Mouth[3].GetComponent<Image>().color = YellowColorPrimary;

                //9 - Base
                Base[0].GetComponent<Image>().color = YellowColorPrimary;
                Base[1].GetComponent<Image>().color = YellowColorPrimary;
                Base[2].GetComponent<Image>().color = YellowColorPrimary;
                Base[3].GetComponent<Image>().color = YellowColorPrimary;
                Secondary[0].GetComponent<Image>().color = YellowColorPrimary;
                Secondary[1].GetComponent<Image>().color = YellowColorPrimary;

                //10 - Tail
                Tail[0].GetComponent<Image>().color = YellowColorPrimary;
                Tail[2].GetComponent<Image>().color = YellowColorPrimary;
                Tail[4].GetComponent<Image>().color = YellowColorPrimary;
                Tail[6].GetComponent<Image>().color = YellowColorPrimary;

                //11 - Ears
                Ears[0].GetComponent<Image>().color = YellowColorPrimary;
                Ears[2].GetComponent<Image>().color = YellowColorPrimary;
                Ears[4].GetComponent<Image>().color = YellowColorPrimary;
                Ears[6].GetComponent<Image>().color = YellowColorPrimary;
            }

            if (green == true)
            {
                //3 - Pattern
                Pattern[1].GetComponent<Image>().color = GreenColorPrimary;

                //6 - Feet
                Feet[0].GetComponent<Image>().color = GreenColorPrimary;
                Feet[1].GetComponent<Image>().color = GreenColorPrimary;
                Feet[2].GetComponent<Image>().color = GreenColorPrimary;
                Feet[3].GetComponent<Image>().color = GreenColorPrimary;


                //8 - Mouth
                Mouth[0].GetComponent<Image>().color = GreenColorPrimary;
                Mouth[1].GetComponent<Image>().color = GreenColorPrimary;
                Mouth[2].GetComponent<Image>().color = GreenColorPrimary;
                Mouth[3].GetComponent<Image>().color = GreenColorPrimary;

                //9 - Base
                Base[0].GetComponent<Image>().color = GreenColorPrimary;
                Base[1].GetComponent<Image>().color = GreenColorPrimary;
                Base[2].GetComponent<Image>().color = GreenColorPrimary;
                Base[3].GetComponent<Image>().color = GreenColorPrimary;
                Secondary[0].GetComponent<Image>().color = GreenColorPrimary;
                Secondary[1].GetComponent<Image>().color = GreenColorPrimary;

                //10 - Tail
                Tail[0].GetComponent<Image>().color = GreenColorPrimary;
                Tail[2].GetComponent<Image>().color = GreenColorPrimary;
                Tail[4].GetComponent<Image>().color = GreenColorPrimary;
                Tail[6].GetComponent<Image>().color = GreenColorPrimary;

                //11 - Ears
                Ears[0].GetComponent<Image>().color = GreenColorPrimary;
                Ears[2].GetComponent<Image>().color = GreenColorPrimary;
                Ears[4].GetComponent<Image>().color = GreenColorPrimary;
                Ears[6].GetComponent<Image>().color = GreenColorPrimary;

            }

            if (blue == true)
            {
                //3 - Pattern
                Pattern[1].GetComponent<Image>().color = BlueColorPrimary;

                //6 - Feet
                Feet[0].GetComponent<Image>().color = BlueColorPrimary;
                Feet[1].GetComponent<Image>().color = BlueColorPrimary;
                Feet[2].GetComponent<Image>().color = BlueColorPrimary;
                Feet[3].GetComponent<Image>().color = BlueColorPrimary;


                //8 - Mouth
                Mouth[0].GetComponent<Image>().color = BlueColorPrimary;
                Mouth[1].GetComponent<Image>().color = BlueColorPrimary;
                Mouth[2].GetComponent<Image>().color = BlueColorPrimary;
                Mouth[3].GetComponent<Image>().color = BlueColorPrimary;

                //9 - Base
                Base[0].GetComponent<Image>().color = BlueColorPrimary;
                Base[1].GetComponent<Image>().color = BlueColorPrimary;
                Base[2].GetComponent<Image>().color = BlueColorPrimary;
                Base[3].GetComponent<Image>().color = BlueColorPrimary;
                Secondary[0].GetComponent<Image>().color = BlueColorPrimary;
                Secondary[1].GetComponent<Image>().color = BlueColorPrimary;

                //10 - Tail
                Tail[0].GetComponent<Image>().color = BlueColorPrimary;
                Tail[2].GetComponent<Image>().color = BlueColorPrimary;
                Tail[4].GetComponent<Image>().color = BlueColorPrimary;
                Tail[6].GetComponent<Image>().color = BlueColorPrimary;

                //11 - Ears
                Ears[0].GetComponent<Image>().color = BlueColorPrimary;
                Ears[2].GetComponent<Image>().color = BlueColorPrimary;
                Ears[4].GetComponent<Image>().color = BlueColorPrimary;
                Ears[6].GetComponent<Image>().color = BlueColorPrimary;
            }

            if (purple == true)
            {
                //3 - Pattern
                Pattern[1].GetComponent<Image>().color = PurpleColorPrimary;

                //6 - Feet
                Feet[0].GetComponent<Image>().color = PurpleColorPrimary;
                Feet[1].GetComponent<Image>().color = PurpleColorPrimary;
                Feet[2].GetComponent<Image>().color = PurpleColorPrimary;
                Feet[3].GetComponent<Image>().color = PurpleColorPrimary;


                //8 - Mouth
                Mouth[0].GetComponent<Image>().color = PurpleColorPrimary;
                Mouth[1].GetComponent<Image>().color = PurpleColorPrimary;
                Mouth[2].GetComponent<Image>().color = PurpleColorPrimary;
                Mouth[3].GetComponent<Image>().color = PurpleColorPrimary;

                //9 - Base
                Base[0].GetComponent<Image>().color = PurpleColorPrimary;
                Base[1].GetComponent<Image>().color = PurpleColorPrimary;
                Base[2].GetComponent<Image>().color = PurpleColorPrimary;
                Base[3].GetComponent<Image>().color = PurpleColorPrimary;
                Secondary[0].GetComponent<Image>().color = PurpleColorPrimary;
                Secondary[1].GetComponent<Image>().color = PurpleColorPrimary;

                //10 - Tail
                Tail[0].GetComponent<Image>().color = PurpleColorPrimary;
                Tail[2].GetComponent<Image>().color = PurpleColorPrimary;
                Tail[4].GetComponent<Image>().color = PurpleColorPrimary;
                Tail[6].GetComponent<Image>().color = PurpleColorPrimary;

                //11 - Ears
                Ears[0].GetComponent<Image>().color = PurpleColorPrimary;
                Ears[2].GetComponent<Image>().color = PurpleColorPrimary;
                Ears[4].GetComponent<Image>().color = PurpleColorPrimary;
                Ears[6].GetComponent<Image>().color = PurpleColorPrimary;
            }

            
            #endregion

            #region 8-Mouth
            if (CowMouth == true)
            {
                Mouth[0].SetActive(true);
            }

            if (WolfMouth == true)
            {
                Mouth[1].SetActive(true);
            }

            if (PigMouth == true)
            {
                Mouth[2].SetActive(true);
            }

            if (BatMouth == true)
            {
                Mouth[3].SetActive(true);
            }
            #endregion

            #region 9-Base
            if (heights == true)
            {
                if (RamHorns == true || BullHorns == true || Antlers == true)
                {
                    Base[0].SetActive(true);
                }
                else
                {
                    Base[3].SetActive(true);
                }
                Secondary[0].SetActive(true);
            }

            if (theDark == true)
            {
                if (RamHorns == true || BullHorns == true || Antlers == true)
                {
                    Base[0].SetActive(true);
                }
                else
                {
                    Base[3].SetActive(true);
                }
                Secondary[1].SetActive(true);
                Secondary[2].SetActive(true);
            }

            if (theOcean == true)
            {
                if (RamHorns == true || BullHorns == true || Antlers == true)
                {
                    Base[1].SetActive(true);
                }
                else
                {
                    Base[2].SetActive(true);
                }
                Secondary[3].SetActive(true);
            }

            if (snakesAndOrSpiders == true)
            {
                if (RamHorns == true || BullHorns == true || Antlers == true)
                {
                    Base[1].SetActive(true);
                }
                else
                {
                    Base[2].SetActive(true);
                }
                if (CowMouth == true)
                {
                    Secondary[4].SetActive(true);
                }
                if (WolfMouth == true)
                {
                    Secondary[5].SetActive(true);
                }
                if (PigMouth == true)
                {
                    Secondary[6].SetActive(true);
                }
                if (BatMouth == true)
                {
                    Secondary[7].SetActive(true);
                }
            }
            #endregion

            #region 10-Tails
            if (FoxTail == true)
            {
                Tail[0].SetActive(true);
                Tail[1].SetActive(true);
                if (StripePattern == true)
                {
                    Tail[8].SetActive(true);
                }
                if (SnakePattern == true)
                {
                    Tail[9].SetActive(true);
                }
                if (Spots == true)
                {
                    Tail[10].SetActive(true);
                }

            }

            if (BirdTail == true)
            {
                Tail[2].SetActive(true);
                Tail[3].SetActive(true);
            }


            if (DragonTail == true)
            {
                Tail[4].SetActive(true);
                Tail[5].SetActive(true);
            }


            if (FishTail == true)
            {
                Tail[6].SetActive(true);
                Tail[7].SetActive(true);
            }

            #endregion

            #region 11-Ears
            if (TigerEars == true)
            {
                Ears[0].SetActive(true);
                Ears[1].SetActive(true);

            }

            if (WolfEars == true)
            {
                Ears[2].SetActive(true);
                Ears[3].SetActive(true);
            }

            if (GoatEars == true)
            {
                Ears[4].SetActive(true);
                Ears[5].SetActive(true);
            }

            if (RabbitEars == true)
            {
                Ears[6].SetActive(true);
            }
            #endregion

            #region 12-Horns
            if (RamHorns == true)
            {
                Horns[0].SetActive(true);
            }

            if (NoHorns == true)
            {
                Horns[1].SetActive(true);
            }

            if (BullHorns == true)
            {
                Horns[2].SetActive(true);
            }

            if (Antlers == true)
            {
                Horns[3].SetActive(true);
            }
            #endregion           

            #region 2-Seasons
            if (autumn == true)
            {
                //1 - Elements
                Elements[0].GetComponent<Image>().color = autumnColorSecondary;
                Elements[1].GetComponent<Image>().color = autumnColorSecondary;
                Elements[2].GetComponent<Image>().color = autumnColorSecondary;
                Elements[3].GetComponent<Image>().color = autumnColorSecondary;

                //3 - Pattern
                Pattern[0].GetComponent<Image>().color = autumnColorSecondary;
                Pattern[2].GetComponent<Image>().color = autumnColorSecondary;
                Pattern[3].GetComponent<Image>().color = autumnColorSecondary;
                Pattern[4].GetComponent<Image>().color = autumnColorSecondary;

                //9 - Base
                Secondary[2].GetComponent<Image>().color = autumnColorSecondary;
                Secondary[3].GetComponent<Image>().color = autumnColorSecondary;

                //10 - Tail
                Tail[1].GetComponent<Image>().color = autumnColorSecondary;
                Tail[3].GetComponent<Image>().color = autumnColorSecondary;
                Tail[5].GetComponent<Image>().color = autumnColorSecondary;
                Tail[7].GetComponent<Image>().color = autumnColorSecondary;

                //10 - Tail Patterns
                Tail[8].GetComponent<Image>().color = autumnColorSecondary;
                Tail[9].GetComponent<Image>().color = autumnColorSecondary;
                Tail[10].GetComponent<Image>().color = autumnColorSecondary;

                //11 - Ears
                Ears[1].GetComponent<Image>().color = autumnColorSecondary;
                Ears[3].GetComponent<Image>().color = autumnColorSecondary;
                Ears[5].GetComponent<Image>().color = autumnColorSecondary;
            }

            if (winter == true)
            {
                //1 - Elements
                Elements[0].GetComponent<Image>().color = winterColorSecondary;
                Elements[1].GetComponent<Image>().color = winterColorSecondary;
                Elements[2].GetComponent<Image>().color = winterColorSecondary;
                Elements[3].GetComponent<Image>().color = winterColorSecondary;

                //3 - Pattern
                Pattern[0].GetComponent<Image>().color = winterColorSecondary;
                Pattern[2].GetComponent<Image>().color = winterColorSecondary;
                Pattern[3].GetComponent<Image>().color = winterColorSecondary;
                Pattern[4].GetComponent<Image>().color = winterColorSecondary;

                //9 - Base
                Secondary[2].GetComponent<Image>().color = winterColorSecondary;
                Secondary[3].GetComponent<Image>().color = winterColorSecondary;

                //10 - Tail
                Tail[1].GetComponent<Image>().color = winterColorSecondary;
                Tail[3].GetComponent<Image>().color = winterColorSecondary;
                Tail[5].GetComponent<Image>().color = winterColorSecondary;
                Tail[7].GetComponent<Image>().color = winterColorSecondary;

                //10 - Tail Patterns
                Tail[8].GetComponent<Image>().color = winterColorSecondary;
                Tail[9].GetComponent<Image>().color = winterColorSecondary;
                Tail[10].GetComponent<Image>().color = winterColorSecondary;

                //11 - Ears
                Ears[1].GetComponent<Image>().color = winterColorSecondary;
                Ears[3].GetComponent<Image>().color = winterColorSecondary;
                Ears[5].GetComponent<Image>().color = winterColorSecondary;
            }

            if (spring == true)
            {
                //1 - Elements
                Elements[0].GetComponent<Image>().color = springColorSecondary;
                Elements[1].GetComponent<Image>().color = springColorSecondary;
                Elements[2].GetComponent<Image>().color = springColorSecondary;
                Elements[3].GetComponent<Image>().color = springColorSecondary;

                //3 - Pattern
                Pattern[0].GetComponent<Image>().color = springColorSecondary;
                Pattern[2].GetComponent<Image>().color = springColorSecondary;
                Pattern[3].GetComponent<Image>().color = springColorSecondary;
                Pattern[4].GetComponent<Image>().color = springColorSecondary;

                //9 - Base
                Secondary[2].GetComponent<Image>().color = springColorSecondary;
                Secondary[3].GetComponent<Image>().color = springColorSecondary;

                //10 - Tail
                Tail[1].GetComponent<Image>().color = springColorSecondary;
                Tail[3].GetComponent<Image>().color = springColorSecondary;
                Tail[5].GetComponent<Image>().color = springColorSecondary;
                Tail[7].GetComponent<Image>().color = springColorSecondary;

                //10 - Tail Patterns
                Tail[8].GetComponent<Image>().color = springColorSecondary;
                Tail[9].GetComponent<Image>().color = springColorSecondary;
                Tail[10].GetComponent<Image>().color = springColorSecondary;

                //11 - Ears
                Ears[1].GetComponent<Image>().color = springColorSecondary;
                Ears[3].GetComponent<Image>().color = springColorSecondary;
                Ears[5].GetComponent<Image>().color = springColorSecondary;
            }

            if (summer == true)
            {
                //1 - Elements
                Elements[0].GetComponent<Image>().color = summerColorSecondary;
                Elements[1].GetComponent<Image>().color = summerColorSecondary;
                Elements[2].GetComponent<Image>().color = summerColorSecondary;
                Elements[3].GetComponent<Image>().color = summerColorSecondary;

                //3 - Pattern
                Pattern[0].GetComponent<Image>().color = summerColorSecondary;
                Pattern[2].GetComponent<Image>().color = summerColorSecondary;
                Pattern[3].GetComponent<Image>().color = summerColorSecondary;
                Pattern[4].GetComponent<Image>().color = summerColorSecondary;

                //9 - Base
                Secondary[2].GetComponent<Image>().color = summerColorSecondary;
                Secondary[3].GetComponent<Image>().color = summerColorSecondary;

                //10 - Tail
                Tail[1].GetComponent<Image>().color = summerColorSecondary;
                Tail[3].GetComponent<Image>().color = summerColorSecondary;
                Tail[5].GetComponent<Image>().color = summerColorSecondary;
                Tail[7].GetComponent<Image>().color = summerColorSecondary;

                //10 - Tail Patterns
                Tail[8].GetComponent<Image>().color = summerColorSecondary;
                Tail[9].GetComponent<Image>().color = summerColorSecondary;
                Tail[10].GetComponent<Image>().color = summerColorSecondary;

                //11 - Ears
                Ears[1].GetComponent<Image>().color = summerColorSecondary;
                Ears[3].GetComponent<Image>().color = summerColorSecondary;
                Ears[5].GetComponent<Image>().color = summerColorSecondary;
            }
            #endregion
        }
        #endregion

        //(Resets Quiz)
        #region Finished

        if (Results.activeInHierarchy == true)
        {
            if (LastQuestionAnswered == true)
            {
                hasFinished = true;
                LastQuestionAnswered = false;
            }

        }
        if (Questions[11].activeInHierarchy == true)
        {
            NextButton.gameObject.SetActive(false);
            CheckResultsButton.gameObject.SetActive(true);
        }
        if (hasFinished == true)
        {
            scoreManager.AddScore(new Score(name: userName, postition: MonsterProgress, monsterElement: MonsterElementIndex));
            scoreManager.SaveScore();
            hasFinished = false;
        }

        if (StartScreen.activeInHierarchy == true || SetUsername.activeInHierarchy == true)
        {
            currentquestion = 1;
            nextquestion = 0;
            previousquestion = -1;

            QuestionBackground.SetActive(false);
            NextButton.gameObject.SetActive(false);
            PreviousButton.gameObject.SetActive(false);

            //1 - Elements
            AnsweredQuestions[0] = false;
            WaterElement = false;
            FireElement = false;
            EarthElement = false;
            AirElement = false;

            //2 - Seasons
            AnsweredQuestions[1] = false;

            //3 - Patterns
            AnsweredQuestions[2] = false;
            StripePattern = false;
            SnakePattern = false;
            Spots = false;
            Countershading = false;

            //4 - Dino
            AnsweredQuestions[3] = false;

            //5 - Eyes
            AnsweredQuestions[4] = false;
            CuddlefishEyes = false;
            CatEyes = false;
            GoatEyes = false;
            NormalEyes = false;

            //6 - Feet
            AnsweredQuestions[5] = false;
            Hooves = false;
            CatPaws = false;
            RatFeet = false;
            BirdFeet = false;

            //7 - Color
            AnsweredQuestions[6] = false;
            red = false;
            orange = false;
            yellow = false;
            green = false;
            blue = false;
            purple = false;

            //8 - Mouth
            AnsweredQuestions[7] = false;
            CowMouth = false;
            WolfMouth = false;
            PigMouth = false;
            BatMouth = false;

            //9 - Base
            AnsweredQuestions[8] = false;
            heights = false;
            theDark = false;
            theOcean = false;
            snakesAndOrSpiders = false;

            //10 - Tail
            AnsweredQuestions[9] = false;
            FoxTail = false;
            BirdTail = false;
            DragonTail = false;
            FishTail = false;

            //11 - Ears
            AnsweredQuestions[10] = false;
            TigerEars = false;
            WolfEars = false;
            GoatEars = false;
            RabbitEars = false;

            //12 - Horns
            AnsweredQuestions[11] = false;
            RamHorns = false;
            NoHorns = false;
            BullHorns = false;
            Antlers = false;
        }
        
        if (Questions[0].activeInHierarchy == true)
        {
            QuestionBackground.SetActive(true);
            NextButton.gameObject.SetActive(true);
            PreviousButton.gameObject.SetActive(true);
        }
        else if (Results.activeInHierarchy == true)
        {
            NextButton.gameObject.SetActive(false);
            PreviousButton.gameObject.SetActive(false);
        }

        if (Questions[11].activeInHierarchy == true)
        {
            NextButton.gameObject.SetActive(false);
            CheckResultsButton.gameObject.SetActive(true);
        }
        else if (StartScreen.activeInHierarchy == false && SetUsername.activeInHierarchy == false)
        {
            if (Results.activeInHierarchy == false)
            {
                NextButton.gameObject.SetActive(true);
                CheckResultsButton.gameObject.SetActive(false);
            }
            else
            {
                NextButton.gameObject.SetActive(false);
                CheckResultsButton.gameObject.SetActive(false);
            }
        }
        #endregion
    }
    #endregion

    public void NextQuestion()
    {
        NextButton.interactable = false;
        if (AnsweredQuestions[nextquestion] == true)
        {
            NextButton.interactable = true;
            if (CheckResultsButton.gameObject.activeInHierarchy == false)
            {
                currentquestion++;
                nextquestion++;
                previousquestion++;
                Questions[nextquestion].SetActive(true);
                Questions[previousquestion].SetActive(false);
                QuestionCountText.text = "Question " + currentquestion.ToString() + "/12";
            }
            else
            {
                Questions[11].SetActive(false);
                Results.SetActive(true);
                CheckResultsButton.gameObject.SetActive(false);
                PreviousButton.gameObject.SetActive(false);
            }
        }
        else
        {
            NextButton.interactable = false;
        }
    }
    public void PreviousQuestion()
    {
        currentquestion--;

        Questions[previousquestion].SetActive(true);
        Questions[nextquestion].SetActive(false);
        QuestionCountText.text = "Question " + currentquestion.ToString() + "/12";

        previousquestion--;
        nextquestion--;
    }

    #region Question 1 (Choose an element)
    [Header("Elements")]
    public int MonsterElementIndex;
    public bool WaterElement;
    public bool FireElement;
    public bool EarthElement;
    public bool AirElement;
    public void Water()
    {
        AnsweredQuestions[0] = true;
        MonsterElementIndex = 0;
        WaterElement = true;
        FireElement = false;
        EarthElement = false;
        AirElement = false;
    }
    public void Fire()
    {
        AnsweredQuestions[0] = true;
        MonsterElementIndex = 1;
        WaterElement = false;
        FireElement = true;
        EarthElement = false;
        AirElement = false;
    }
    public void Earth()
    {
        AnsweredQuestions[0] = true;
        MonsterElementIndex = 2;
        WaterElement = false;
        FireElement = false;
        EarthElement = true;
        AirElement = false;
    }
    public void Air()
    {
        AnsweredQuestions[0] = true;
        MonsterElementIndex = 3;
        WaterElement = false;
        FireElement = false;
        EarthElement = false;
        AirElement = true;
    }
    #endregion

    #region Question 2 (Choose your favorite season)
    [Header("Season")]
    public bool autumn;
    public bool winter;
    public bool spring;
    public bool summer;

    [SerializeField] private Color autumnColorSecondary;
    [SerializeField] private Color winterColorSecondary;
    [SerializeField] private Color springColorSecondary;
    [SerializeField] private Color summerColorSecondary;

    public void Autumn()
    {
        AnsweredQuestions[1] = true;
        autumn = true;
        winter = false;
        spring = false;
        summer = false;
    }
    public void Winter()
    {
        AnsweredQuestions[1] = true;
        autumn = false;
        winter = true;
        spring = false;
        summer = false;
    }
    public void Spring()
    {
        AnsweredQuestions[1] = true;
        autumn = false;
        winter = false;
        spring = true;
        summer = false;
    }
    public void Summer()
    {
        AnsweredQuestions[1] = true;
        autumn = false;
        winter = false;
        spring = false;
        summer = true;
    }
    #endregion

    #region Question 3 (Choose your favorite biome)
    [Header("Pattern")]
    public bool StripePattern;
    public bool SnakePattern;
    public bool Spots;
    public bool Countershading;
    public void Forest()
    {
        AnsweredQuestions[2] = true;
        StripePattern = true;
        SnakePattern = false;
        Spots = false;
        Countershading = false;
    }
    public void Desert()
    {
        AnsweredQuestions[2] = true;
        StripePattern = false;
        SnakePattern = true;
        Spots = false;
        Countershading = false;
    }
    public void Tundra()
    {
        AnsweredQuestions[2] = true;
        StripePattern = false;
        SnakePattern = false;
        Spots = true;
        Countershading = false;
    }
    public void Ocean()
    {
        AnsweredQuestions[2] = true;
        StripePattern = false;
        SnakePattern = false;
        Spots = false;
        Countershading = true;
    }
    #endregion

    #region Question 4 (Choose your favorite dinosaur)
    public void Ankylosaurus()
    {
        AnsweredQuestions[3] = true;
    }
    public void Stegosaurus()
    {
        AnsweredQuestions[3] = true;
    }
    public void Spinosaurus()
    {
        AnsweredQuestions[3] = true;
    }
    public void Tyrannosaurus()
    {
        AnsweredQuestions[3] = true;
    }
    #endregion

    #region Question 5 (What is your eye color?)
    [Header("Eyes")]
    public bool NormalEyes;
    public bool CatEyes;
    public bool CuddlefishEyes;
    public bool GoatEyes;
    public void Blue()
    {
        AnsweredQuestions[4] = true;
        NormalEyes = true;
        CatEyes = false;
        CuddlefishEyes = false;
        GoatEyes = false;
    }
    public void Green()
    {
        AnsweredQuestions[4] = true;
        NormalEyes = false;
        CatEyes = true;
        CuddlefishEyes = false;
        GoatEyes = false;
    }
    public void Brown()
    {
        AnsweredQuestions[4] = true;
        NormalEyes = false;
        CatEyes = false;
        CuddlefishEyes = true;
        GoatEyes = false;
    }
    public void Other()
    {
        AnsweredQuestions[4] = true;
        NormalEyes = false;
        CatEyes = false;
        CuddlefishEyes = false;
        GoatEyes = true;
    }
    #endregion

    #region Question 6 (What is your hobby?)
    [Header("Feet")]
    public bool Hooves;
    public bool CatPaws;
    public bool RatFeet;
    public bool BirdFeet;
    public void Running()
    {
        AnsweredQuestions[5] = true;
        Hooves = true;
        CatPaws = false;
        RatFeet = false;
        BirdFeet = false;
    }
    public void Gymnastics()
    {
        AnsweredQuestions[5] = true;
        Hooves = false;
        CatPaws = true;
        RatFeet = false;
        BirdFeet = false;
    }
    public void Gaming()
    {
        AnsweredQuestions[5] = true;
        Hooves = false;
        CatPaws = false;
        RatFeet = true;
        BirdFeet = false;
    }
    public void Drawing()
    {
        AnsweredQuestions[5] = true;
        Hooves = false;
        CatPaws = false;
        RatFeet = false;
        BirdFeet = true;
    }
    #endregion

    #region Question 7 (What is your favorite color?)
    [Header("Color")]
    public bool red;
    public bool orange;
    public bool yellow;
    public bool green;
    public bool blue;
    public bool purple;

    [SerializeField] private Color RedColorPrimary;
    [SerializeField] private Color OrangeColorPrimary;
    [SerializeField] private Color YellowColorPrimary;
    [SerializeField] private Color GreenColorPrimary;
    [SerializeField] private Color BlueColorPrimary;
    [SerializeField] private Color PurpleColorPrimary;

    public void RedColor()
    {
        AnsweredQuestions[6] = true;
        red = true;
        orange = false;
        yellow = false;
        green = false;
        blue = false;
        purple = false;
    }
    public void OrangeColor()
    {
        AnsweredQuestions[6] = true;
        red = false;
        orange = true;
        yellow = false;
        green = false;
        blue = false;
        purple = false;
    }
    public void YellowColor()
    {
        AnsweredQuestions[6] = true;
        red = false;
        orange = false;
        yellow = true;
        green = false;
        blue = false;
        purple = false;
    }
    public void GreenColor()
    {
        AnsweredQuestions[6] = true;
        red = false;
        orange = false;
        yellow = false;
        green = true;
        blue = false;
        purple = false;
    }
    public void BlueColor()
    {
        AnsweredQuestions[6] = true;
        red = false;
        orange = false;
        yellow = false;
        green = false;
        blue = true;
        purple = false;
    }
    public void PurpleColor()
    {
        AnsweredQuestions[6] = true;
        red = false;
        orange = false;
        yellow = false;
        green = false;
        blue = false;
        purple = true;
    }


    #endregion

    #region Question 8 (What kind of animal is your favorite?)
    [Header("Mouth")]
    public bool CowMouth;
    public bool WolfMouth;
    public bool PigMouth;
    public bool BatMouth;
    public void Herbivore()
    {
        AnsweredQuestions[7] = true;
        CowMouth = true;
        WolfMouth = false;
        PigMouth = false;
        BatMouth = false;
    }
    public void Carnivore()
    {
        AnsweredQuestions[7] = true;
        CowMouth = false;
        WolfMouth = true;
        PigMouth = false;
        BatMouth = false;
    }
    public void Omnivore()
    {
        AnsweredQuestions[7] = true;
        CowMouth = false;
        WolfMouth = false;
        PigMouth = true;
        BatMouth = false;
    }
    public void Insectivore()
    {
        AnsweredQuestions[7] = true;
        CowMouth = false;
        WolfMouth = false;
        PigMouth = false;
        BatMouth = true;
    }
    #endregion

    #region Question 9 (What is your fear?)
    [Header("Base")]
    public bool heights;
    public bool theDark;
    public bool theOcean;
    public bool snakesAndOrSpiders;
    public void Heights()
    {
        AnsweredQuestions[8] = true;
        heights = true;
        theDark = false;
        theOcean = false;
        snakesAndOrSpiders = false;

    }
    public void The_Dark()
    {
        AnsweredQuestions[8] = true;
        heights = false;
        theDark = true;
        theOcean = false;
        snakesAndOrSpiders = false;
    }
    public void The_Ocean()
    {
        AnsweredQuestions[8] = true;
        heights = false;
        theDark = false;
        theOcean = true;
        snakesAndOrSpiders = false;
    }
    public void Snakes_and_or_Spiders()
    {
        AnsweredQuestions[8] = true;
        heights = false;
        theDark = false;
        theOcean = false;
        snakesAndOrSpiders = true;
    }
    #endregion

    #region Question 10 (What power would you have if you were a superhero?)
    [Header("Tails")]
    public bool FoxTail;
    public bool BirdTail;
    public bool DragonTail;
    public bool FishTail;
    public void Invisibility()
    {
        AnsweredQuestions[9] = true;
        FoxTail = true;
        BirdTail = false;
        DragonTail = false;
        FishTail = false;
    }
    public void Flight()
    {
        AnsweredQuestions[9] = true;
        FoxTail = false;
        BirdTail = true;
        DragonTail = false;
        FishTail = false;
    }
    public void Super_Strength()
    {
        AnsweredQuestions[9] = true;
        FoxTail = false;
        BirdTail = false;
        DragonTail = true;
        FishTail = false;
    }
    public void Breathing_under_water()
    {
        AnsweredQuestions[9] = true;
        FoxTail = false;
        BirdTail = false;
        DragonTail = false;
        FishTail = true;
    }
    #endregion

    #region Question 11 (What is your favorite music genre?)
    [Header("Ears")]
    public bool TigerEars;
    public bool WolfEars;
    public bool GoatEars;
    public bool RabbitEars;
    public void Rock()
    {
        AnsweredQuestions[10] = true;
        TigerEars = true;
        WolfEars = false;
        GoatEars = false;
        RabbitEars = false;
    }
    public void Pop()
    {
        AnsweredQuestions[10] = true;
        TigerEars = false;
        WolfEars = true;
        GoatEars = false;
        RabbitEars = false;
    }
    public void Jazz()
    {
        AnsweredQuestions[10] = true;
        TigerEars = false;
        WolfEars = false;
        GoatEars = true;
        RabbitEars = false;
    }
    public void Rap()
    {
        AnsweredQuestions[10] = true;
        TigerEars = false;
        WolfEars = false;
        GoatEars = false;
        RabbitEars = true;
    }
    #endregion

    #region Question 12 (What is your favorite flavor?)
    [Header("Horns")]
    public bool RamHorns;
    public bool NoHorns;
    public bool BullHorns;
    public bool Antlers;
    public void Sweet()
    {
        LastQuestionAnswered = true;
        AnsweredQuestions[11] = true;
        RamHorns = true;
        NoHorns = false;
        BullHorns = false;
        Antlers = false;
    }
    public void Sour()
    {
        LastQuestionAnswered = true;
        AnsweredQuestions[11] = true;
        RamHorns = false;
        NoHorns = true;
        BullHorns = false;
        Antlers = false;
    }
    public void Salty()
    {
        LastQuestionAnswered = true;
        AnsweredQuestions[11] = true;
        RamHorns = false;
        NoHorns = false;
        BullHorns = true;
        Antlers = false;
    }
    public void Savory()
    {
        LastQuestionAnswered = true;
        AnsweredQuestions[11] = true;
        RamHorns = false;
        NoHorns = false;
        BullHorns = false;
        Antlers = true;
    }
    #endregion
}