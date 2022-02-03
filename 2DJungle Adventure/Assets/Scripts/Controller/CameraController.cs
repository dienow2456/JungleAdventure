using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smooothing = 5f;
    public float dich = 60f;
    Vector3 offset;
    Vector3 offset1;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(1f, target.position.y, -10f);
        offset1 = new Vector3(target.position.x, 1f, -10f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (target.position.x >= -1f&& target.position.x < dich)
        {
           
            if (target.position.y >= 1.9f)
            {

                Vector3 camPos1 = new Vector3(target.position.x + offset.x, target.position.y + offset1.y, -10f);
                transform.position = Vector3.Lerp(transform.position, camPos1, smooothing * Time.deltaTime);
            }
            else if (target.position.y < 1.9f)
            {
                Vector3 campos1 = new Vector3(target.position.x + offset.x, 0, -10f);
                transform.position = Vector3.Lerp(transform.position, campos1, smooothing * Time.deltaTime);
            }
        }
        else if (target.position.x < -1f)
        {
            
            if (target.position.y >= 1.9f)
            {
               
                Vector3 camPos1 = new Vector3(0, target.position.y + offset1.y, -10f);  
                transform.position = Vector3.Lerp(transform.position, camPos1, smooothing * Time.deltaTime);
            }
            else if (target.position.y < 1.9f)
            {
                Vector3 campos1 = new Vector3(0, 0, -10f);
                transform.position = Vector3.Lerp(transform.position, campos1, smooothing * Time.deltaTime);
            }
        }
        else if (target.position.x >= dich)
        {
            
            if (target.position.y >= 1.9f)
            {

                Vector3 camPos1 = new Vector3(dich, target.position.y + offset1.y, -10f);
                transform.position = Vector3.Lerp(transform.position, camPos1, smooothing * Time.deltaTime);
            }
            else if (target.position.y < 1.9f)
            {
                Vector3 campos1 = new Vector3(dich, 0, -10f);
                transform.position = Vector3.Lerp(transform.position, campos1, smooothing * Time.deltaTime);
            }
        }
        
    }
}
