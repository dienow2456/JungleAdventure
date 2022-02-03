using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public AdsManager adsManager;
    [SerializeField]
    GameObject setting, shopItem, baoloi;
    public void Setting()
    {
        setting.SetActive(true);
    } 
    public void OutSetting()
    {
        setting.SetActive(false);
        shopItem.SetActive(false);
    }
    public void ShopItem()
    {
        shopItem.SetActive(true);
    }
    public void Buy5Knife()
    { 
        int coin= PlayerPrefs.GetInt("CoinScore");
        if (coin >= 10)
        {
            int knife = PlayerPrefs.GetInt("NumberAtt");
            knife += 5;
            coin -= 10;
            PlayerPrefs.SetInt("NumberAtt", knife);
            PlayerPrefs.SetInt("CoinScore",  coin);
        }
        else
        {
            baoloi.SetActive( true);
            StartCoroutine(Delay());
        }
    }
    public void Buy1Life()
    { 
        int coin= PlayerPrefs.GetInt("CoinScore");
        if (coin >= 10)
        {
            int life = PlayerPrefs.GetInt("Hp");
            life += 1;
            coin -= 10;
            PlayerPrefs.SetInt("Hp", life);
            PlayerPrefs.SetInt("CoinScore",  coin);
        }
        else
        {
            baoloi.SetActive( true);
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        baoloi.SetActive(false);
    }
    public void SeeVideoRewardKnife()
    {
        if(!IAPShop.checkBuyAds)
            adsManager.PlayAdsReward();
        int knife = PlayerPrefs.GetInt("NumberAtt");
        knife += 5;
        PlayerPrefs.SetInt("NumberAtt", knife);
    }
    public void SeeVideoRewardLife()
    {
        if (!IAPShop.checkBuyAds)
            adsManager.PlayAdsReward();
        int knife = PlayerPrefs.GetInt("Hp");
        knife += 1;
        PlayerPrefs.SetInt("Hp", knife);
    }
}
