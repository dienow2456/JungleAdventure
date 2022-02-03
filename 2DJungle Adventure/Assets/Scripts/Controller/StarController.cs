using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField]
   GameObject[] star;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (  collision.CompareTag("mat"))
        {
            gameObject.SetActive(false);
            for(int i=0; i<star.Length; i++)
            {
                if (!star[i].activeSelf)
                {
                    star[i].SetActive(true);
                    break;
                }
            }
        }
    }
}
