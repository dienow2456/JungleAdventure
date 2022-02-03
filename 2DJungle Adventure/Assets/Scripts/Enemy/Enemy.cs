using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public  float  speed = 1;
    bool up;
    float i;
    [SerializeField]
    private GameObject lineRenderer;
    // Start is called before the first frame update
    bool cham;
    private void Start()
    {
        cham = false;
    }
    private void Update()
    {
       
            if (cham)
            {
                speed = 0;
                GetComponent<Rigidbody2D>().isKinematic = false;
                lineRenderer.SetActive(false);
            }
        
        
        if (up)
        {
            i =-1;
        }
        else i= 1;
        transform.Translate(i * speed * Time.deltaTime * -Vector2.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Untagged"))
        {
            up =true;
        }
        if (collision.CompareTag("ong_nuoc"))
        {
            up = false;
        }
        if (collision.CompareTag("Player")||collision.CompareTag("attack"))
        {
            cham = true;
        }
    }
}
