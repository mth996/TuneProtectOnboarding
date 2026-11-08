using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDesk : MonoBehaviour
{
    public GameObject KeyBoard;
    public GameObject KeyBoardOrganized;
    public GameObject KeyBoardButton;
    public GameObject Mouse;
    public GameObject MouseOrganized;
    public GameObject MouseButton;
    public GameObject Books;
    public GameObject BooksOrganized;
    public GameObject BooksButton;
    public GameObject EndPanel;

    // Start is called before the first frame update
    public void awake()
    {
        
        Books.SetActive(true);
        KeyBoard.SetActive(true);
        Mouse.SetActive(true);
        BooksButton.SetActive(true);
        KeyBoardButton.SetActive(false);
        MouseButton.SetActive(false);
        BooksOrganized.SetActive(false);
        KeyBoardOrganized.SetActive(false);
        MouseOrganized.SetActive(false);
        EndPanel.SetActive(false);
    }

    // Update is called once per frame
    public void CleanBook()
    {
        Books.SetActive(false);
        KeyBoard.SetActive(true);
        Mouse.SetActive(true);
        BooksButton.SetActive(false);
        KeyBoardButton.SetActive(true);
        MouseButton.SetActive(false);
        BooksOrganized.SetActive(true);
        KeyBoardOrganized.SetActive(false);
        MouseOrganized.SetActive(false);
    }


    public void CleanKeyboard()
    {
        Books.SetActive(false);
        KeyBoard.SetActive(false);
        Mouse.SetActive(true);
        BooksButton.SetActive(false);
        KeyBoardButton.SetActive(false);
        MouseButton.SetActive(true);
        BooksOrganized.SetActive(true);
        KeyBoardOrganized.SetActive(true);
        MouseOrganized.SetActive(false);
    }

    public void CleanMouse()
    {
        Books.SetActive(false);
        KeyBoard.SetActive(false);
        Mouse.SetActive(false);
        BooksButton.SetActive(false);
        KeyBoardButton.SetActive(false);
        MouseButton.SetActive(false);
        BooksOrganized.SetActive(true);
        KeyBoardOrganized.SetActive(true);
        MouseOrganized.SetActive(true);
        StartCoroutine(Fade());
    }


    IEnumerator Fade()
    {
        yield return new WaitForSeconds(.8f);
        EndPanel.SetActive(true);

    }


}
