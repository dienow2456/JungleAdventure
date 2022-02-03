using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatCoins : MonoBehaviour
{
    public Text CoinScore;
    public Text Life;
    
    [SerializeField]
    AudioSource ting, starAuido;

    public static int demCoins;
    int coin;
    int life;
   
    private void Start()
    {
        demCoins = 0;
        coin = PlayerPrefs.GetInt("CoinScore");
        CoinScore.text =coin.ToString();
        life = PlayerPrefs.GetInt("Hp");
        Life.text = life.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coins"))
        {
            if (!GameManager.mute)
                ting.Play();
            demCoins++;
            collision.gameObject.SetActive(false);
            coin++;
            PlayerPrefs.SetInt("CoinScore", coin);
            CoinScore.text = PlayerPrefs.GetInt("CoinScore").ToString();
        }

        if(collision.CompareTag("devo"))
        {
            collision.gameObject.GetComponent<Animator>().enabled = true;
            
        }

       

        if (collision.CompareTag("star"))
        {
            if (!GameManager.mute)
                starAuido.Play();

            collision.gameObject.SetActive(false);
           
        }
    }

   
}
