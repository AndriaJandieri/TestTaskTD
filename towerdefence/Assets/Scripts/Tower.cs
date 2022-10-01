using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerScriptableObject towerScriptableObject;

    public int towerPrice;
    [SerializeField] float towerAttackRange;
    [SerializeField] private float towerShootInterval;
    /*[SerializeField] private*/public float towerDamage;

    public HealthUIScript healthUIScript;
    public static bool isVictory;

    public Transform bulletLauncherPos;
    public GameObject bulletPrefab;
    [SerializeField] private Transform target;

    private void Awake()
    {
        InitializeTower();
    }
    void Start()
    {
        isVictory = false;
        healthUIScript = GameObject.Find("CastleEntrance").GetComponent<HealthUIScript>();
        

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("FireToEnemy", 0f, towerShootInterval);

    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q)) UpdateTarget();

        if (target == null)
        {
            return;
        }
    }
    void InitializeTower()
    {
        towerPrice = towerScriptableObject.towerPrice;
        towerAttackRange = towerScriptableObject.towerAttackRange;
        towerShootInterval = towerScriptableObject.towerShootInterval;
        towerDamage = towerScriptableObject.towerDamage;
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0 && WaveSpawner.currentWave == 3 && !isVictory)
        {
            healthUIScript.GameVictory();
            isVictory = true;
        }

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position + new Vector3(0, 0, -2f), enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= towerAttackRange)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void FireToEnemy()
    {
        if (target != null)
        {
            GameObject bulletFiring = (GameObject)Instantiate(bulletPrefab, bulletLauncherPos.position, bulletLauncherPos.rotation);

            Bullet bullet = bulletFiring.GetComponent<Bullet>();
            bulletFiring.GetComponent<Bullet>().bulletDamage = towerDamage;

            if (bullet != null)
            {
                bullet.SeekToEnemy(target);
            }
            //Debug.Log(this.name + "Fires");
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, 0, -1.1f), towerAttackRange);
    }
}
