using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotDead : MonoBehaviour
{
    [SerializeField]
    AudioSource  impact;
    [SerializeReference]
    BoxCollider2D deadCollider;
    [SerializeField]
    GameObject rua, notdead, player;
    
    public Text Life;
    public static bool dead = false;
    [SerializeField]
    ParticleSystem brockenHp;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("mat"))
        {
            dead = true;
            if (!GameManager.mute)
                impact.Play();
            int hp = PlayerPrefs.GetInt("Hp");

            if (hp >= 0)
                --hp;
            brockenHp.Play();
            Life.text = hp.ToString();
            PlayerPrefs.SetInt("Hp", hp);
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        GetComponent<BoxCollider2D>().enabled = false;
       
        rua.layer = 9;
        notdead.layer = 9;
        deadCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        dead = false;
        yield return new WaitForSeconds(1.5f);
      
        rua.layer = 8;
        notdead.layer = 0;
        GetComponent<BoxCollider2D>().enabled = true;
        deadCollider.enabled = true;
    }
}
