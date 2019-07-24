using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private CharacterController2D storage;
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void backHome()
    {
        SceneManager.LoadScene("Menu");

    }
   
}
