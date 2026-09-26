using System.Collections;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject gamePlayUI;
    public GameObject Spawner;
    public GameObject partcileStart;

    public static GameManager instance;
    public bool gameStarted = false;
    Vector3 originalCampos;

    public GameObject player;

    public TMP_Text scoreText;
    public TMP_Text healthText;

    int score = 0;
    int lives = 2;

    private void Awake()
    {
        instance = this;  
    }

    private void Start()
    {
        originalCampos = Camera.main.transform.position;
    }

    public void StartGame()
    {
        gameStarted = true;

        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        Spawner.SetActive(true);
        partcileStart.SetActive(true);
    }

    public void GameOver()
    {
        player.SetActive(false);

        Invoke("ReloadLevel", 2f);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateLives()
    {
        if(lives <= 0)
        {
            GameOver();
        }
        else
        {
            lives--;
            healthText.text = "Lives : " + lives;
           
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score : " + score;
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Shake()
    {
        StartCoroutine("CameraShake");
    }

    IEnumerator CameraShake()
    {
        for(int i = 0; i < 5; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;

            Camera.main.transform.position = new Vector3(randomPos.x, randomPos.y, originalCampos.z);

            yield return null;
        }

        Camera.main.transform.position = originalCampos;
    }
}
