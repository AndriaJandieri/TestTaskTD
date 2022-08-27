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
        if (CoinManager.currentAmountCoins >= towerPrefabs[index].GetComponent<Tower>().towerPrice)
        {
            GameObject tower = Instantiate(towerPrefabs[index], transform.position + offset, transform.rotation);
            coinManager.UpdateCoinAmount(-tower.GetComponent<Tower>().towerPrice);
            TougleTowerSelectionWindow(false);

            Debug.Log(CoinManager.currentAmountCoins);
        }
        else
        {
            Debug.Log("Not Enough Coins");
        }
    }
    public void TougleTowerSelectionWindow(bool _tougle)
    {
        GameObject.Find("TowerPlaces").GetComponent<CloseWindowsScript>().CloseAllWindows();
        towerSelectionWindow.SetActive(_tougle);
    }
}
