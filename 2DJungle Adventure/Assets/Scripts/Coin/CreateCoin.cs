using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoin : MonoBehaviour
{
    [SerializeField]
    GameObject coin,dat;
    [SerializeField]
    Rigidbody2D rbCoin;
    public float speed=10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dau")||collision.CompareTag("attack"))
        {
            
            coin.SetActive(true);
            rbCoin.velocity = new Vector2(-0.1f, 1f) * speed;
            dat.SetActive(false);
        }
    }
}
