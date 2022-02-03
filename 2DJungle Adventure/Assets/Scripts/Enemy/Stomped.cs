using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomped : MonoBehaviour
{
    
    bool  cham = false;
    [SerializeField]
    ParticleSystem dead;
    
    public float force;
    [SerializeField]
    Rigidbody2D rbPlayer;
    [SerializeField]
    BoxCollider2D circlyCollider, boxcollider;
    private void Start()
    {
        cham = false;
       
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillEnemy"))
        {
          
            if (cham)
            {
                StartCoroutine(Delay());
                rbPlayer.velocity = Vector2.up *( force-5);
            }
            else
            {
                cham = true;

                
                rbPlayer.velocity = Vector2.up * force;
                StartCoroutine(Delay1());
                
            }
        }

        if (collision.CompareTag("attack"))
        {
            boxcollider.enabled = false;
            circlyCollider.enabled = false;
            dead.Play();
        }
    }
    IEnumerator Delay()
    {
        dead.Play();
        boxcollider.enabled = false;
        circlyCollider.enabled = false;
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator Delay1()
    {
        
        yield return new WaitForSeconds(3f);
        cham = false;
       
           
    }
}
