using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveUIScript : MonoBehaviour
{
    public TextMeshProUGUI currentWaveNumText;

    void Update()
    {
        currentWaveNumText.text = WaveSpawner.currentWave.ToString();
    }
}
