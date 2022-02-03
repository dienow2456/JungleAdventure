using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UDP;

public class IAPShop : MonoBehaviour, IInitListener, IPurchaseListener
{
   
    public static bool checkClickRemoveAds=false;
    public static bool check=false;
    [SerializeField]
    GameObject remove;
    public static bool checkBuyAds = false;
   public void RemoveAds()
    {
        checkClickRemoveAds = true;
        checkBuyAds = true;
        StoreService.Purchase("removeads", "", this);
        remove.SetActive(false);
    }

    private void Awake()
    {
        if (checkClickRemoveAds)
            remove.SetActive(false);
        if (!check)
        {
            StoreService.Initialize(this);
           
        }
    
    }
    public void OnInitialized(UserInfo userInfo)
    {
        Debug.Log("Initialization succeeded");
        StoreService.QueryInventory(this);
        check = true;
    }

    public void OnInitializeFailed(string message)
    {
        Debug.Log("Initialization failed: " + message);
    }

    

    public void OnPurchase(PurchaseInfo purchaseInfo)
    {
        if (purchaseInfo.ProductId == "removeads")
        {
            checkBuyAds = true;
        }
        
    }

    public void OnPurchaseFailed(string message, PurchaseInfo purchaseInfo)
    {
        Debug.Log("Purchase Failed: " + message);
    }

    public void OnPurchaseRepeated(string productId)
    {
        throw new System.NotImplementedException();
    }

    public void OnPurchasePending(string message, PurchaseInfo purchaseInfo)
    {
        throw new System.NotImplementedException();
    }

    public void OnPurchaseConsume(PurchaseInfo purchaseInfo)
    {
       
    }

    public void OnPurchaseConsumeFailed(string message, PurchaseInfo purchaseInfo)
    {
        throw new System.NotImplementedException();
    }

    public void OnQueryInventory(Inventory inventory)
    {
        Debug.Log("Query inventory succeeded");
        
    }

    public void OnQueryInventoryFailed(string message)
    {
        Debug.Log("Query Inventory failed");
    }
}
