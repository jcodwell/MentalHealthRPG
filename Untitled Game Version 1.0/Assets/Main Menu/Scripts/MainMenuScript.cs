using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{
    public string newGame;
    public GameObject mainmenu;
    public GameObject optionmenu;



    public void PlayGame ()
    {
        SceneManager.LoadScene(newGame);
    }

    public void OptionsMenu()
    {
        gameObject.SetActive(false);
        optionmenu.SetActive(true);
    }

    public void BackButton()
    {
        gameObject.SetActive(true);
        optionmenu.SetActive(false);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
