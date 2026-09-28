using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchLogic : MonoBehaviour
{
    static MatchLogic Instance;
    public int maxPoints=5;
    public Text pointsText;
    public GameObject levelCompleteUI;
    public GameObject GamePanel;
    private int points=0;
    // Start is called before the first frame update

    void Start()
    {
          Instance = this;
    }
    
    void UpdatePotinsText()
    {
        pointsText.text = points + "/" + maxPoints;
        if (points == maxPoints) 
        {
            levelCompleteUI. SetActive(true);
            GamePanel.SetActive(false);
        }
    }
    public static void AddPoint()
    {
        AddPoints(1);
    }

    public static void AddPoints(int points) 
    {
        Instance.points += points;
        Instance. UpdatePotinsText();
    }

    public void Scene5()
    {
        SceneManager.LoadScene("Scene5");
    }
}

