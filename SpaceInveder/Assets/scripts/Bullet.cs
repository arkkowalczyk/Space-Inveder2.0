using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    void Update()
    {
        if (transform.position.y > 5f) Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            GameObject h = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(h, 2f);
        }
    }
}
