using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Untagged")||collision.CompareTag("?")||collision.CompareTag("dat"))
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            StartCoroutine(Delay());
        }
        if (collision.CompareTag("Respawn"))
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.6f);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
