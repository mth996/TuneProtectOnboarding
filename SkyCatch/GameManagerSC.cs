using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerSC : MonoBehaviour
{
    public Text scoreText;
    public GameObject winScreen;
    public GameObject loseScreen;

    private int score = 0;
    public int winScore = 50; // Adjust this to your desired win condition
    public int loseScore = 0; // Adjust this to your desired lose condition

    public static GameManagerSC Instance; // Singleton instance
    public ItemSpawner itemSpawner; // Reference to the ItemSpawner script


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        UpdateScore();
    }

    public void UpdateScore(int points = 1)
    {
        score += points;
        scoreText.text = "Score: " + score;

        // Check win and lose conditions
        if (score >= winScore)
        {
            // Handle win condition
            winScreen.SetActive(true);
            itemSpawner.StopSpawning();
        }
        else if (score <= loseScore) 
        {
            // Handle lose condition
            loseScreen.SetActive(true);
            itemSpawner.StopSpawning();
        }
    }
    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
