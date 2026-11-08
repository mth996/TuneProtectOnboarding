using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gamePanel;
    // Start is called before the first frame update
    public void Awake()
    {
        mainMenu.SetActive(true);
        gamePanel.SetActive(false);
    }

    // Update is called once per frame
    public void Sg()
    {
        mainMenu.SetActive(false);
        gamePanel.SetActive(true);
        Debug.Log("workinggg");
    }
}
