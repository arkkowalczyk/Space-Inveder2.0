using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction = new Vector2(1f,0f);
    float maxleft, maxright, attackDelay = 0f, delay=0f;
    int down = 0, gridX, gridY, cCount, maxEnemy;

    public int iloscGier;
    public int[] leaderboard = new int[10];

    public int CCount
    {
        get
        {
            ColumnCheck();
            return cCount;
        }
    }

    enum EnemyType {shooter, taran}
    [SerializeField] EnemyType enemyType;
    [SerializeField] Transform left, right;
    [SerializeField] GameObject bulletPref;
    [SerializeField] float speed, minTime, maxTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxleft = left.position.x;
        maxright = right.position.x;
        maxEnemy = Handler.enemyCount;
        attackDelay = Random.Range(minTime, maxTime);

        Grid();

        Wyniki();

    }
    void Wyniki()
    {
        Scors scors = HIghScors.Load();
        iloscGier = scors.gamesPlayed;
        for (int i = 0; i < 10; i++)
        {
            leaderboard[i] = scors.hs[i];
        }
    }
    void Update()
    {
        StatBoost();

        switch (enemyType)
        {
            case EnemyType.shooter:
                if (CanAttack())
                {
                    ShooterAttack();
                }
                break;
            case EnemyType.taran:
                if (CanAttack())
                {
                    TaranAttack();
                }
                break;
        }
    }
    private void FixedUpdate()
    {
        Movement();

        if (rb.position.y<-4f)
        {
            GameOver();
        }
    }
    void StatBoost()
    {
        minTime -= (maxEnemy - Handler.enemyCount) / 100f;
        maxTime -= (maxEnemy - Handler.enemyCount) / 100f;
        speed += (maxEnemy - Handler.enemyCount) / 100f;
        maxEnemy = Handler.enemyCount;
    }
    void Movement()
    {
        if (check())
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
        if (down==2)
        {
            rb.MovePosition(rb.position + new Vector2(0f,-0.5f));
            down = 0;
        }
    }
    bool check()
    {
        float next = rb.position.x + direction.x * speed * Time.fixedDeltaTime;
        if (next <=maxleft)
        {
            direction.x = -direction.x;
            down++;
            return false;
        }
        else if (next >= maxright)
        {
            direction.x = -direction.x;
            down++;
            return false;
        }
        else
        {
            return true;
        }
    }
    bool CanAttack()
    {
        delay += Time.deltaTime;
        if (delay >= attackDelay)
        {
            delay = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
    void ShooterAttack()
    {
        GameObject b = Instantiate(bulletPref, transform.position, transform.rotation);
        Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
        EnemyBullet eb = b.GetComponent<EnemyBullet>();
        eb.EAi = this;
        brb.AddForce(-transform.up * 5f, ForceMode2D.Impulse);
        Destroy(b, 3f);
    }
    void TaranAttack()
    {
        if (Handler.enemyGrid[gridX, gridY+1]==0)
        {
            direction.x = 0;
            direction.y = -1;
            speed *= 4;
            attackDelay = 100f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            Death();
        }
        if (collision.CompareTag("Player"))
        {
            ColumnCheck();
            Handler.ScoreCount -= (cCount * 2);
            Death();
        }
    }
    void Death()
    {
        Handler.enemyGrid[gridX, gridY] = 0;
        Handler.enemyCount--;
        Handler.ScoreCount++;

        Destroy(this.gameObject);

        if (Handler.enemyCount==0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        int ph1, ph2 = Handler.ScoreCount;
        for(int i = 0; i < 10; i++)
        {
            if (leaderboard[i] < ph2)
            {
                ph1 = leaderboard[i];
                leaderboard[i] = ph2;
                ph2 = ph1;
            }
        }
        iloscGier++;
        HIghScors.SaveScore(this);
        FindObjectOfType<Show>().Points();
        FindObjectOfType<Show>().Change();

        Handler.GState = Handler.GameState.over;
    }
    public void ColumnCheck()
    {
        for (int i=0; i<6; i++)
        {
            if (Handler.enemyGrid[gridX,i]==1)
            {
                cCount++;
            }
        }
    }
    void Grid()
    {
        switch (transform.position.x)
        {
            case -2.25f:
                gridX = 0;
                break;
            case -1.5f:
                gridX = 1;
                break;
            case -0.75f:
                gridX = 2;
                break;
            case -0f:
                gridX = 3;
                break;
            case 0.75f:
                gridX = 4;
                break;
            case 1.5f:
                gridX = 5;
                break;
        }
        switch (transform.position.y)
        {
            case 3.75f:
                gridY = 0;
                break;
            case 3f:
                gridY = 1;
                break;
            case 2.25f:
                gridY = 2;
                break;
            case 1.5f:
                gridY = 3;
                break;
            case 0.75f:
                gridY = 4;
                break;
            case 0f:
                gridY = 5;
                break;
        }
        Handler.enemyGrid[gridX, gridY] = 1;
    }
}
