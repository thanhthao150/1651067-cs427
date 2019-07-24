using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject player;
    [SerializeField] private Text ErrorMessage;
    [SerializeField] private int desiredCherries = 50;
    [SerializeField] private int desiredGems = 50;
    private CharacterController2D playerInventory;
    private void Start()
    {
        playerInventory = player.GetComponentInChildren<CharacterController2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(playerInventory.getCherries() >= desiredCherries && playerInventory.getGems() >= desiredGems) { 
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                ErrorMessage.text = "Error: Must have more than "+ desiredGems.ToString() + " gems" +" and " + desiredCherries.ToString() + " cherries";
            }
        }
    }
}
