using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    EnemyAi eAi;
    public EnemyAi EAi
    {
        set { eAi = value; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Handler.ScoreCount -= (eAi.CCount * 2);

            GameObject h = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(h, 2f);
        }
    }
}
