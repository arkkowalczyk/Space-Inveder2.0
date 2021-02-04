using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed, shootSpeed, bulletForce;
    [SerializeField] Transform leftBorder, rightBorder;
    [SerializeField] GameObject bulletPref;

    public float ShootSpeed
    {
        get { return shootSpeed; }
        set { shootSpeed = value; }
    }

    Vector2 direction = new Vector2(0f,0f);
    Rigidbody2D rb;
    
    float shotDelay = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveLeft()
    {
        direction.x = -1f;
        
    }
    public void MoveRight()
    {
        direction.x = 1f;
    }
    public void StopMove()
    {
        direction.x = 0f;
    }
    private void Update()
    {
        shotDelay += Time.deltaTime;
        if (shotDelay >= shootSpeed)
        {
            Shooting();
            shotDelay = 0;
        }
    }
    private void FixedUpdate()
    {
        Moving();
    }
    void Moving()
    {
        if (CheckBorders()) {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime); 
        }
    }
    bool CheckBorders()
    {
        float nextPos = rb.position.x + direction.x * speed * Time.fixedDeltaTime;
        if (nextPos<=leftBorder.position.x)
        {
            return false;
        }
        else if(nextPos >= rightBorder.position.x)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    void Shooting()
    {
        GameObject b = Instantiate(bulletPref, transform.position, transform.rotation);
        Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
        brb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
    }
}
