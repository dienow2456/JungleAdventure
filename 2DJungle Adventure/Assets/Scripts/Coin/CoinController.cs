using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("mat"))
        {

            GetComponentInParent<ParticleSystem>().Play();
            GetComponentInParent<Rigidbody2D>().isKinematic = true;
            GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
        }
       
    }

   
}
