using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class KeyInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    //private int index; // For the array to the dialogue 
    public bool playerInRange;// If the player is in range to the npc (true) if not (false)
    //public GameObject contButton;
    public PlayerMovementJK movement;
    public GameObject interactButton;
    public GameObject itemInteracted;
    public bool playerHasKey = false;
    //public string[] invent;
    //private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            interactButton.SetActive(true);
        }
        else if (!playerInRange)
        {
            interactButton.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        { 
            itemInteracted.SetActive(false);
            interactButton.SetActive(false);
            playerHasKey = true;

        }


    }
    
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    // This method is uded to make playerInRange turn to false when player is away the NPC
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
