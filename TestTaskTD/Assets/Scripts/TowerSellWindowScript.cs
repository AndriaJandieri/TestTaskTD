using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSellWindowScript : MonoBehaviour
{
    public GameObject towerSellWindow;

    public void tougleToweSellWindow(bool _tougle)
    {
        towerSellWindow.SetActive(_tougle);
    }

    public void SellTower()
    {
        GameObject.Find("CoinManager").GetComponent<CoinManager>().UpdateCoinAmount(GetComponent<Tower>().towerPrice/2);
        tougleToweSellWindow(false);
        Destroy(gameObject);
    }
}
