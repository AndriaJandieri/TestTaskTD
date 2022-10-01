using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceScript : MonoBehaviour
{
    public CoinManager coinManager;
    public GameObject towerSelectionWindow;
    public GameObject[] towerPrefabs;

    Vector3 offset = new Vector3(0, 0.3f, -0.1f);


    public void BuildSelectedTower(int index)
    {        
        GameObject tower = Instantiate(towerPrefabs[index], transform.position + offset, transform.rotation);
        int towerPrice = tower.GetComponent<Tower>().towerPrice;

        if (CoinManager.currentAmountCoins >=towerPrice )
        {            
            coinManager.UpdateCoinAmount(-tower.GetComponent<Tower>().towerPrice);
            TougleTowerSelectionWindow(false);
        }
        else
        {
            Destroy(tower);
            Debug.Log("Not Enough Coins" + CoinManager.currentAmountCoins);
        }
    }
    public void TougleTowerSelectionWindow(bool _tougle)
    {
        GameObject.Find("TowerPlaces").GetComponent<CloseWindowsScript>().CloseAllWindows();
        towerSelectionWindow.SetActive(_tougle);
    }
}
