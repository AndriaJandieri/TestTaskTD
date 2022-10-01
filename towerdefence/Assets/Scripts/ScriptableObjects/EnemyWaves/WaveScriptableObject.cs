using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave_Color", menuName = "Wave")]

public class WaveScriptableObject : ScriptableObject
{
    public GameObject[] enemyListInWaves;

    public float distanceBetweenEnemiesInWaves;
    public float waveDuration;
}
