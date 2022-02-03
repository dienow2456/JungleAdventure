using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddKnie : MonoBehaviour
{
    public Text scoreAttack;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("mat"))
        {
            gameObject.SetActive(false);
            int numAtt = PlayerPrefs.GetInt("NumberAtt");
            numAtt += 1;
            ButtonAttack.checkNum = false;
            PlayerPrefs.SetInt("NumberAtt", numAtt);
           
        }

    }
   
}
