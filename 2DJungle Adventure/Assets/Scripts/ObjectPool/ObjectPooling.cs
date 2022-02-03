using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    public GameObject knife;
    [SerializeField]
    public List<GameObject> Knife;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        Knife = new List<GameObject>();
        
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(knife, transform);
            obj.SetActive(false);
            Knife.Add(obj);

           
        }
    }
    public GameObject SpawnPole()
    {

        for (int i = 0; i < Knife.Count; i++)
        {
            if (!Knife[i].activeSelf)
            {
                Knife[i].SetActive(true);
                Knife[i].GetComponentInChildren<SpriteRenderer>().color = Color.white;
                Knife[i].GetComponentInChildren<Rigidbody2D>().velocity = Vector2.zero;
                return Knife[i];
            }
        }
        GameObject obj = Instantiate(knife, transform);
        Knife.Add(obj);
        obj.SetActive(true);
        return obj;

    }

   
}
