using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatvoController : MonoBehaviour
{
    [SerializeField]
    AudioSource vo;
    [SerializeField]
    GameObject[] datvo;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(CheckVodat());
            
        }
    }

    IEnumerator CheckVodat()
    {
        for (int i = 0; i < datvo.Length; i++)
        {
            if (datvo[i].activeSelf)
            {
                datvo[i].SetActive(false);
                datvo[i].GetComponentInParent<ParticleSystem>().Play();
                if (!GameManager.mute)
                    vo.Play();
                break;
            }
        }
        if (!datvo[datvo.Length - 1].activeSelf)
        {
            GetComponentInParent<EdgeCollider2D>().enabled = false;
        }
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.6f);
        GetComponent<BoxCollider2D>().enabled = true;
        if (!datvo[datvo.Length - 1].activeSelf)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
