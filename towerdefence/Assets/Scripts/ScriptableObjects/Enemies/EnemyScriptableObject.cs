using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_Type", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public float enemyHealth;
    public float emenyMovementSpeed;
    public float enemyDamage;
    [Header("Coin Reward Range On KILL")]
    public int minCoinReward;
    public int maxCoinReward;

}
