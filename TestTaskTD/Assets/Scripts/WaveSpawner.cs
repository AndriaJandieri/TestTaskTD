using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum WaveState { FirstWave, SecondWave, ThirdWave }
    public WaveState waveState;

    public WaveScriptableObject[] waveScriptableObjects;

    [SerializeField] private float distanceBetweenEnemiesInWaves;
    

    [SerializeField] private GameObject[] enemyListInWaves;

    [SerializeField] private float waveDuration;

    [SerializeField] private float countdownTime;

    private bool isActiveSpawner;

    public static int currentWave;

    void Start()
    {
        isActiveSpawner = true;
        waveState = WaveState.FirstWave;
        RenewWaveState();
        SpawnWave();
        currentWave = 1;
        countdownTime = waveDuration;

    }

    void Update()
    {
        if (countdownTime <= 0&& isActiveSpawner)
        {
            //currentWave++;
            if (currentWave == 1)
            {
                waveState = WaveState.SecondWave;
                currentWave++;
                RenewWaveState();
                SpawnWave();
                countdownTime = waveDuration;
                return;
            }

            if (currentWave == 2)
            {
                waveState = WaveState.ThirdWave;                
                currentWave++;
                RenewWaveState();
                SpawnWave();
                countdownTime = waveDuration;
                return;
            }
            if (currentWave >= 3)
            {
                Debug.Log("No More Waves Will Spawn");
                isActiveSpawner = false;
            }
        }

        countdownTime -= Time.deltaTime;
    }

    public void SpawnWave()
    {
        float dist = 0f;
        foreach (GameObject enemy in enemyListInWaves)
        {

            Instantiate(enemy, transform.position + new Vector3(-dist, 0, 0), Quaternion.identity);
            dist += distanceBetweenEnemiesInWaves;
        }
        dist = 0f;
    }

    public void RenewWaveState()
    {

        switch (waveState)
        {
            case WaveState.FirstWave:
                Debug.Log("It's 1 Wave");
                enemyListInWaves = waveScriptableObjects[0].enemyListInWaves;
                distanceBetweenEnemiesInWaves = waveScriptableObjects[0].distanceBetweenEnemiesInWaves;
                waveDuration = waveScriptableObjects[0].waveDuration;
                break;
            case WaveState.SecondWave:
                Debug.Log("It's 2 Wave");
                enemyListInWaves = waveScriptableObjects[1].enemyListInWaves;
                distanceBetweenEnemiesInWaves = waveScriptableObjects[1].distanceBetweenEnemiesInWaves;
                waveDuration = waveScriptableObjects[1].waveDuration;
                break;
            case WaveState.ThirdWave:
                Debug.Log("It's 3 Wave");
                enemyListInWaves = waveScriptableObjects[2].enemyListInWaves;
                distanceBetweenEnemiesInWaves = waveScriptableObjects[2].distanceBetweenEnemiesInWaves;
                waveDuration = waveScriptableObjects[2].waveDuration;
                break;
            default:
                Debug.Log("Wave Is Not Declared");
                break;

        }
    }
}
