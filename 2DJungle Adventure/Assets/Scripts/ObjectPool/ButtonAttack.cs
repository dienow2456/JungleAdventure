using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAttack : MonoBehaviour
{
    public static bool attack, checkNum = true;
    public float speed;
    float i = 1;
    public Text numAtt, coinScore;
    int numberAttack;
    [SerializeField]
    AudioSource shotAudio;
    [SerializeField]
    GameObject imageCoin, main;
    
    public void Attack()
    {
        attack = true;
        if (!GameManager.mute)
            shotAudio.Play();
        if (numberAttack > 0)
        {
            numberAttack--;
            checkNum = false;
            PlayerPrefs.SetInt("NumberAtt", numberAttack);
        }

        else if (numberAttack <= 0)
        {
            checkNum = true;
            int coinNow = PlayerPrefs.GetInt("CoinScore");

            if (coinNow > 30)
            {
                coinNow -= 30;
                PlayerPrefs.SetInt("CoinScore", coinNow);
            }

        }
        GameObject obj = ObjectPooling.Instance.SpawnPole();
        obj.transform.rotation = Quaternion.Euler(0, 0, 0);
        obj.GetComponent<BoxCollider2D>().enabled = true;
        obj.GetComponent<Rigidbody2D>().isKinematic = true;
        if (main.transform.localScale.x < 0)
        {
            i = -1;
            obj.transform.localPosition = new Vector2(main.transform.position.x - 1, main.transform.position.y + 0.67f);
            obj.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else 
        {
            i = 1;
            obj.transform.localPosition = new Vector2(main.transform.position.x + 1, main.transform.position.y + 0.67f);
            obj.transform.rotation = Quaternion.Euler(0, 0, 0);
        } 
        obj.GetComponent<Rigidbody2D>().velocity = -Vector2.left * speed*i;
        
        
    }
    public void Update()
    {
        numberAttack = PlayerPrefs.GetInt("NumberAtt");
        if (numberAttack > 0)
        {
            checkNum = false;
        }
        if (!checkNum)
        {
            numAtt.text = PlayerPrefs.GetInt("NumberAtt").ToString();
            imageCoin.SetActive(false);
        }
        else
        {
            numAtt.text = "-30";
            imageCoin.SetActive(true);
            coinScore.text = PlayerPrefs.GetInt("CoinScore").ToString();
        }
        
    }
   
}
