using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDat : MonoBehaviour
{
    [SerializeField]
    GameObject datvo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("attack"))
        {
            datvo.SetActive(false);
            GetComponentInParent<ParticleSystem>().Play();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
