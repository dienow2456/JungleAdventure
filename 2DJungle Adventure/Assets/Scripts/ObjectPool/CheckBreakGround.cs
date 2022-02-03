using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckBreakGround : MonoBehaviour
{
    [SerializeField]
    AudioSource blockAudio;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("?"))
        {
            if (!GameManager.mute)
                blockAudio.Play();
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            collision.gameObject.GetComponent<EdgeCollider2D>().enabled = false;

            StartCoroutine(Delay(collision.gameObject));
        }
        if(collision.CompareTag("dat"))
        {
            if (!GameManager.mute)
                blockAudio.Play();
           
            collision.gameObject.GetComponentInParent<ParticleSystem>().Play();
          
            StartCoroutine(Delay1(collision.gameObject));
        }
        if(collision.CompareTag("datvo"))
        {
            if (!GameManager.mute)
                blockAudio.Play();
            collision.gameObject.GetComponentInParent<ParticleSystem>().Play();
            StartCoroutine(Delay2(collision.gameObject));

        }
       
    }
    IEnumerator Delay(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    IEnumerator Delay1(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
        gameObject.GetComponentInParent<BoxCollider2D>().enabled = false;
    }
    IEnumerator Delay2(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
        gameObject.GetComponentInParent<EdgeCollider2D>().enabled = false;
    }
}
