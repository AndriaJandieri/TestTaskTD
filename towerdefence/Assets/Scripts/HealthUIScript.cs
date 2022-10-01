using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUIScript : MonoBehaviour
{
    public TextMeshProUGUI currentHealthText;
    public GameObject uiStats;
    public SceneLoader sceneManager;
    public AudioSource audioSource;
    public float currentHealth = 100f;
    public static bool isGameOver;

    public Animator uiAnim;
    void Start()
    {
        isGameOver = false;
        uiAnim = uiStats.GetComponent<Animator>();
        if (!audioSource)
        {
            try
            {
                audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogWarning("AUDIO IS NOT AVAIABLE: Because You Starting From GameScene(Scene-1) Instead of StartScene(Scene-0)");
            }
        }
        else
        {
            return;
        }
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !isGameOver)
        {
            currentHealth = currentHealth - other.GetComponent<Enemy>().enemyDamage;
            currentHealthText.text = currentHealth.ToString();

            if (currentHealth > 0) uiAnim.SetTrigger("CastleTakeDamage");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                currentHealthText.text = currentHealth.ToString();
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        StartCoroutine(LoadStartScene());
        isGameOver = true;
        if (audioSource)
        {
            audioSource.Stop();
        }
        uiAnim.Play("GameOverScreen");
        
    }

    public void GameVictory()
    {
        Debug.Log("Victory");
        StartCoroutine(LoadStartScene());
        isGameOver = true;
        if (audioSource)
        {
            audioSource.Stop();
        }
        uiAnim.Play("GameOverScreenVictory");
        
    }

    IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(5);
        if (audioSource)
        {
            audioSource.Play();
        }

        Debug.Log("Going To StartScene");
        sceneManager.LoadSceneWithIndex(0);
    }
}
