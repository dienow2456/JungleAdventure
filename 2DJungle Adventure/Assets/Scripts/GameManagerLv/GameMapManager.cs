using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMapManager : MonoBehaviour
{

    public static int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5=0,count6=0;
    [SerializeField]
    GameObject[] star1, star2, star3,star4,star5,star6, youhere;
    [SerializeField]
    GameObject[] buttonLevel1, buttonLevel2, buttonLevel3, buttonLevel4, buttonLevel5, buttonLevel6;
    private Vector3 touchStart;
    public Camera cam;
    public float groundZ;
    public static bool completeLv1 = false, completeLv2 = false, completeLv3 = false,completeLv4 = false,completeLv5 = false,completeLv6 = false;

    private void Start()
    {
        youhere[0].SetActive(true);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = GetWorldPosition(groundZ);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - GetWorldPosition(groundZ);

            Camera.main.transform.position =new Vector3(Camera.main.transform.localPosition.x+ direction.x, 0, Camera.main.transform.position.z);
        }
        if (Camera.main.transform.localPosition.x <= 0)
        {
            Camera.main.transform.position = new Vector3(0, 0, -10);
        }
    }

    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
    private void LateUpdate()
    {
        if (GameManagerLevel1.completeLv1 )
        {
            completeLv1 = true;
            
            if (GameManager.clickLv1)
            {
                youhere[0].SetActive(false);
                youhere[1].SetActive(true);
            }
            if (count1 < GameManagerLevel1.count)
            {
                count1 = GameManagerLevel1.count;
                for (int i=0; i<count1; i++)
                {
                    if (!star1[i].activeSelf)
                    {
                        star1[i].SetActive(true);
                    }
                }
            }
            GameManagerLevel1.completeLv1 = false;
        }
        for (int i = 0; i < count1; i++)
        {
            if (!star1[i].activeSelf)
            {
                star1[i].SetActive(true);
            }
        }
        if (GameManagerlv2.completeLv2)
        {
            completeLv2 = true;

            if (GameManager.clickLv2)
            {
                youhere[0].SetActive(false);
                youhere[1].SetActive(false);
                youhere[2].SetActive(true);
            }
            if (count2 < GameManagerlv2.count)
            {
                count2 = GameManagerlv2.count;
                for (int i = 0; i < count2; i++)
                {
                    if (!star2[i].activeSelf)
                    {
                        star2[i].SetActive(true);
                    }
                }
            }
            GameManagerlv2.completeLv2 = false;
        }
        for (int i = 0; i < count2; i++)
        {
            if (!star2[i].activeSelf)
            {
                star2[i].SetActive(true);
            }
        }
        if (GameManagerLv3.completeLv3)
        {
            completeLv3 = true;

            if (GameManager.clickLv3)
            {
                youhere[0].SetActive(false);
                youhere[1].SetActive(false);
                youhere[2].SetActive(false);
                youhere[3].SetActive(true);
            }
            if (count3 < GameManagerLv3.count)
            {
                count3 = GameManagerLv3.count;
                for (int i = 0; i < count3; i++)
                {
                    if (!star3[i].activeSelf)
                    {
                        star3[i].SetActive(true);
                    }
                }
            }
            GameManagerLv3.completeLv3 = false;
        }
        for (int i = 0; i < count3; i++)
        {
            if (!star3[i].activeSelf)
            {
                star3[i].SetActive(true);
            }
        }
        if (GameManagerlv4.completeLv4)
        {
            completeLv4 = true;

            if (GameManager.clickLv4)
            {
                youhere[0].SetActive(false);
                youhere[1].SetActive(false);
                youhere[2].SetActive(false);
                youhere[3].SetActive(false);
                youhere[4].SetActive(true);
            }
            if (count4 < GameManagerlv4.count)
            {
                count4 = GameManagerlv4.count;
                for (int i = 0; i < count4; i++)
                {
                    if (!star4[i].activeSelf)
                    {
                        star4[i].SetActive(true);
                    }
                }
            }
            GameManagerlv4.completeLv4 = false;
        }
        for (int i = 0; i < count4; i++)
        {
            if (!star4[i].activeSelf)
            {
                star4[i].SetActive(true);
            }
        }
        if (GameManagerLv5.completeLv5)
        {
            completeLv5 = true;

            if (GameManager.clickLv5)
            {
                youhere[0].SetActive(false);
                youhere[1].SetActive(false);
                youhere[2].SetActive(false);
                youhere[3].SetActive(false);
                youhere[4].SetActive(false);
                youhere[5].SetActive(true);
            }
            if (count5 < GameManagerLv5.count)
            {
                count5 = GameManagerLv5.count;
                for (int i = 0; i < count5; i++)
                {
                    if (!star5[i].activeSelf)
                    {
                        star5[i].SetActive(true);
                    }
                }
            }
            GameManagerLv5.completeLv5 = false;
        }
        if (GameManagerlv6.completeLv6)
        {
            completeLv6 = true;

            if (GameManager.clickLv6)
            {
                youhere[0].SetActive(false);
                youhere[1].SetActive(false);
                youhere[2].SetActive(false);
                youhere[3].SetActive(false);
                youhere[4].SetActive(false);
                youhere[5].SetActive(false);
                youhere[6].SetActive(true);
            }
            if (count6 < GameManagerlv6.count)
            {
                count6 = GameManagerlv6.count;
                for (int i = 0; i < count6; i++)
                {
                    if (!star6[i].activeSelf)
                    {
                        star6[i].SetActive(true);
                    }
                }
            }
            GameManagerLv5.completeLv5 = false;
        }
        for (int i = 0; i < count5; i++)
        {
            if (!star5[i].activeSelf)
            {
                star5[i].SetActive(true);
            }
        }
        for (int i = 0; i < count6; i++)
        {
            if (!star6[i].activeSelf)
            {
                star6[i].SetActive(true);
            }
        }
        if (completeLv1)
        {
            buttonLevel1[1].SetActive(true);
            buttonLevel2[0].SetActive(true);
        }
        if (completeLv2)
        {
            buttonLevel2[1].SetActive(true);
            buttonLevel3[0].SetActive(true);
        }
        if (completeLv3)
        {
            buttonLevel3[1].SetActive(true);
            buttonLevel4[0].SetActive(true);
        }
        if (completeLv4)
        {
            buttonLevel4[1].SetActive(true);
            buttonLevel5[0].SetActive(true);
        }
        if (completeLv5)
        {
            buttonLevel5[1].SetActive(true);
            buttonLevel6[0].SetActive(true);
        }
        if (completeLv6)
        {
            buttonLevel6[1].SetActive(true);
            
        }
    }
}
