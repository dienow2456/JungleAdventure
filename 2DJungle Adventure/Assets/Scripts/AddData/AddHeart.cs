using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHeart : MonoBehaviour
{
    public Text life;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("mat"))
        {
            gameObject.SetActive(false); 
            int hp = PlayerPrefs.GetInt("Hp");
            hp += 1;
            PlayerPrefs.SetInt("Hp", hp);
            life.text = PlayerPrefs.GetInt("Hp").ToString();
        }
        
    }
}
