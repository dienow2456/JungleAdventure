using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeScore : MonoBehaviour
{
    public Text kniffe;
    private void Update()
    {
        int knife = PlayerPrefs.GetInt("NumberAtt");
        kniffe.text = knife.ToString();
    }
}
