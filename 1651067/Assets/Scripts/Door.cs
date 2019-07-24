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
    private CharacterController2D playerInventory;
    private void Start()
    {
        playerInventory = player.GetComponentInChildren<CharacterController2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(playerInventory.getCherries() >= 50 && playerInventory.getGems() >= 50) { 
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                ErrorMessage.text = "Must have more than 50 gems and 50 cherries";
            }
        }
    }
}
