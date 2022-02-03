using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCoinNow : MonoBehaviour
{
    public Text score;
    private void Update()
    {
        int coin = PlayerPrefs.GetInt("CoinScore");
        score.text = coin.ToString();
    }
}
