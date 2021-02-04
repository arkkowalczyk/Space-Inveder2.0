using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Transform[] spawners;
    [SerializeField] GameObject[] enemyType;
    [SerializeField] [Range(0, 18)] int shooterCount = 0; 
    [SerializeField] [Range(6, 24)] int taranCount = 0;

    void Start()
    {
        if (Handler.GState == Handler.GameState.play)
        {
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        int enemyNumberSpawn = shooterCount + taranCount;
        int type = 0, pos = 0;
        Vector3 line =new Vector3(0f, 1f,0f);
        Handler.enemyCount = enemyNumberSpawn;
        for (int i=0;i<enemyNumberSpawn; i++)
        {
            if (i%spawners.Length==0)
            {
                line.y-=0.75f;
                pos = 0;
            }
            if (i>=shooterCount)
            {
                type++;
            }

            Instantiate(enemyType[type],line+spawners[pos].position,spawners[pos].rotation);
            pos++;
            type = 0;
        }
    }
}
