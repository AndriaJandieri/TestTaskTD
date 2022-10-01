using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    //public TextMeshProUGUI _coinsText;
    public TextMeshProUGUI coinsText;

    public static int currentAmountCoins;

    // Start is called before the first frame update
    void Start()
    {
        //coinsText = _coinsText;
        currentAmountCoins = 100;
        UpdateCoinAmount(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // UpdateCoinAmount(-tower.GetComponent<Tower>());
        }
        //_coinsText.text = currentAmountCoins.ToString();
    }

    public void UpdateCoinAmount(int _amount)
    {
        currentAmountCoins = currentAmountCoins + _amount;
        coinsText.text = currentAmountCoins.ToString();

        //if (currentAmountCoins < 0)
        //{
        //    coinsText.text = "0";
        //}
    }
}
