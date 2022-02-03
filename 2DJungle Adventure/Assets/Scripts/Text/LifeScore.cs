using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeScore : MonoBehaviour
{
    public Text Life;
    private void Update()
    {
        int life = PlayerPrefs.GetInt("Hp");
        Life.text = life.ToString();
    }
}
