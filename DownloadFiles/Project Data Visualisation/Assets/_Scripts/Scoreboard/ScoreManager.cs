using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static MonsterManager manager;
    private ScoreData sd;
    public List<GameObject> Elements = new List<GameObject>();
    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");

        manager = FindObjectOfType<MonsterManager>();
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.monster);
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        Debug.Log(json);
        PlayerPrefs.SetString("scores", json);
    }

    public void ClearHistory()
    {
        var json = PlayerPrefs.GetString("scores", "{}");

        sd = JsonUtility.FromJson<ScoreData>(json);
        sd = new ScoreData();
        SceneManager.LoadScene(0);
    }
}























