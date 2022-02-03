using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    public float speed = 1;
    bool up;
    float i;
    

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            i = -1;
        }
        else i = 1;
        transform.Translate(i * speed * Time.deltaTime * -Vector2.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Untagged"))
        {
            up = !up;
        }
        
    }
}
