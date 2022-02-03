using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoxoController : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField]
    AudioSource jump;
    [SerializeField]
    Rigidbody2D rbMain;
    [SerializeField]
    Animator animLoxo;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rbMain.velocity = new Vector2(0, 1f) * speed;
            if (!GameManager.mute)
                jump.Play();
            StartCoroutine(Run());
        }
    }

    IEnumerator Run()
    {
        animLoxo.SetBool("state", true);
        yield return new WaitForSeconds(0.3f); 
        
        
        animLoxo.SetBool("state", false);
       
    }

    
}
