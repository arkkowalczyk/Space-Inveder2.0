using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Scors
{
    public int score;
    public int[] hs=new int[10];
    public int gamesPlayed;

    public Scors(EnemyAi enemyAi)
    {
        gamesPlayed = enemyAi.iloscGier;
        score = Handler.ScoreCount;
        for (int i = 0; i < 10; i++)
        {
            if (enemyAi.leaderboard[i]!=0) {
                hs[i] = enemyAi.leaderboard[i];
            }
        }
    }
}
