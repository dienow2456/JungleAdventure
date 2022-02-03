using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rbcoin;

    GameObject main;
    Vector2 mainVector;
    float timeStamp;
    bool flyMain;
    
    private void Update()
    {
        if (flyMain)
        {
            mainVector = -(transform.position - main.transform.position).normalized;
            
            rbcoin.velocity = new Vector2(mainVector.x, mainVector.y) * 35f * (Time.time / timeStamp);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Magnet"))
        {
            timeStamp = Time.time;
            main = GameObject.Find("Spine GameObject (main) (1)");
            flyMain = true;

        }
    }
}
