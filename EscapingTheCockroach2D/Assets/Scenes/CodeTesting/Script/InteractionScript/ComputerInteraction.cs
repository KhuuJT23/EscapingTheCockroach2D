using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class ComputerInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    //private int index; // For the array to the dialogue 
    public bool playerInRange;// If the player is in range to the npc (true) if not (false)
    //public GameObject contButton;
    public PlayerMovementJK movement;
    public GameObject interactButton;
    public GameObject itemInteracted;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject[] pages;
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
            page1.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        { 
            interactButton.SetActive(false);
            page1.SetActive(true);

        }


    }
    public void ClosingPage()
    {
        page3.SetActive(false);

    }
    public void NextPage12()
    {
        page1.SetActive(false);
        page2.SetActive(true);

    }
    public void NextPage23()
    {
        page2.SetActive(false);
        page3.SetActive(true);
    }
    public void previousPage21()
    {
        page2.SetActive(false);
        page1.SetActive(true);
    }
    public void previousPage32()
    {
        page3.SetActive(false);
        page2.SetActive(true);
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
