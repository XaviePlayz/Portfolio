using System;
using UnityEngine;

[Serializable]
public class Score
{
    public string name;
    public float monster;
    public int monsterElement;

    public Score(string name, float postition, int monsterElement)
    {
        this.name = name;
        this.monster = postition;
        this.monsterElement = monsterElement;
    }
}
