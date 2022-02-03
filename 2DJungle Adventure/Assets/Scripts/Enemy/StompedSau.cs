using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompedSau : MonoBehaviour
{
    public static bool cham = false;
    [SerializeField]
    ParticleSystem dead;
    [SerializeField]
    GameObject sau;
    public float force;
    [SerializeField]
    Rigidbody2D rbPlayer;
    [SerializeField]
    BoxCollider2D saucollider, notdeadCollider;
    private void Start()
    {
        cham = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillEnemy"))
        {
            cham = true;
            rbPlayer.velocity = Vector2.up * force;
            StartCoroutine(Delay());

        }

        if (collision.CompareTag("attack"))
        {
            cham = true;
            
            GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * (force - 5);
            sau.transform.localRotation = Quaternion.Euler(0, sau.transform.localRotation.y, 180);
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        dead.Play();
        notdeadCollider.enabled = false;
        saucollider.enabled = false;
        yield return new WaitForSeconds(0.1f);
    }
}
