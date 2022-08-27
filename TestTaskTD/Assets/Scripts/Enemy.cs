using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyScriptableObject enemyScriptableObject;
    [SerializeField] private Slider healthBar;

    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemyMovementSpeed;
    public float enemyDamage;
    public int minCoinReward, maxCoinReward;

    private void Awake()
    {
        healthBar = GetComponentInChildren<Slider>();
        InitializeEnemy();
    }

    private void Start()
    {        

    }
    void InitializeEnemy()
    {
        enemyHealth = enemyScriptableObject.enemyHealth;
        enemyMovementSpeed = enemyScriptableObject.emenyMovementSpeed;
        enemyDamage = enemyScriptableObject.enemyDamage;
        minCoinReward = enemyScriptableObject.minCoinReward;
        maxCoinReward = enemyScriptableObject.maxCoinReward;
        healthBar.maxValue = enemyHealth;
        healthBar.value = healthBar.maxValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            healthBar.value = healthBar.value - other.GetComponent<Bullet>().bulletDamage;
            if (healthBar.value <= 0)
            {
                GameObject.Find("CoinManager").GetComponent<CoinManager>().UpdateCoinAmount(Random.Range(minCoinReward,maxCoinReward));
                Destroy(gameObject);
            }
        }
    }
}
