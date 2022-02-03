using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompedNhen : MonoBehaviour
{
    
    public float force;
    [SerializeField]
    Rigidbody2D rbPlayer;
    [SerializeField]
    BoxCollider2D circlyCollider, boxcollider;
    [SerializeField]
    ParticleSystem dead;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillEnemy"))
        {          
               
                rbPlayer.velocity = Vector2.up * force;
                StartCoroutine(Delay());

        }

        if (collision.CompareTag("attack"))
        {
            GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * (force - 5);

            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        dead.Play();
        boxcollider.enabled = false;
        circlyCollider.enabled = false;
        yield return new WaitForSeconds(0.1f);
    }
    

    }

