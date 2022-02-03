﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLevel1 : MonoBehaviour
{
    public AdsManager adsManager;
    [SerializeField]
    GameObject  shopItem, baoloi;
    public static bool gamePause;
    public static int count;
    [SerializeField]
    GameObject gameoverPage, pause;
    public static bool completeLv1;
    [SerializeField]
    AudioSource thatvong, click;

    private void Start()
    {
        completeLv1 = false;
        gamePause = false;
    }
    private void Update()
    {
        int hp = PlayerPrefs.GetInt("Hp");
        if (hp < 0)
        {
            gameoverPage.SetActive(true);
            Time.timeScale = 0;
            if (!GameManager.mute)
                thatvong.Play();
            PlayerPrefs.SetInt("Hp", 0);
        }

        if (gamePause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        if (PlayerController.isComplete)
        {
            completeLv1 = true;
            count = PlayerController.count;

        }
    }
    public void OutSetting()
    {
       
        shopItem.SetActive(false);
    }
    public void ShopItem()
    {
        shopItem.SetActive(true);
    }
    public void Buy5Knife()
    {
        int coin = PlayerPrefs.GetInt("CoinScore");
        if (coin >= 10)
        {
            int knife = PlayerPrefs.GetInt("NumberAtt");
            knife += 5;
            coin -= 10;
            PlayerPrefs.SetInt("NumberAtt", knife);
            PlayerPrefs.SetInt("CoinScore", coin);
        }
        else
        {
            baoloi.SetActive(true);
            StartCoroutine(Delay());
        }
    }
    public void Buy1Life()
    {
        int coin = PlayerPrefs.GetInt("CoinScore");
        if (coin >= 10)
        {
            int life = PlayerPrefs.GetInt("Hp");
            life += 1;
            coin -= 10;
            PlayerPrefs.SetInt("Hp", life);
            PlayerPrefs.SetInt("CoinScore", coin);
        }
        else
        {
            baoloi.SetActive(true);
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
        if (!IAPShop.checkBuyAds)
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
    public void Pause()
    {
        if (!GameManager.mute)
            click.Play();
        gamePause = true;
        pause.SetActive(true);

    }
    public void Continue()

    {
        if (!GameManager.mute)
            click.Play();
        gamePause = false;
        pause.SetActive(false);

    }
}
