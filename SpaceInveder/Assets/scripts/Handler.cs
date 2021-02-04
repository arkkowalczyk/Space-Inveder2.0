using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Handler 
{ 
    public enum GameState {menu, play, over}

    private static GameState gState ;
    public static GameState GState
    {
        get { return gState; }
        set
        {
            gState = value;
            if (gState == GameState.over)
            {
                Reset();
            }
        }
    }
    public static int enemyCount = 0;
    public static int[,] enemyGrid = new int[6, 6];

    private static int scoreCount = 0;
    public static int ScoreCount
    {
        get { return scoreCount; }
        set { 
            scoreCount = value;
            if (scoreCount < 0) scoreCount = 0;
        }
    }
    
    static void Reset()
    {
        enemyCount = 0;
        scoreCount = 0;
        for (int i=0;i>6;i++)
        {
            for (int j = 0; j > 6; j++)
            {
                enemyGrid[i, j] = 0;
            }
        }
    }
}
