using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class Talking : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialougeText;
    public string[] dialogue; // I assume this will be used for custom text
    private int index; // For the array to the dialogue 
    public float wordSpeed; // The speed of the text
    public bool playerInRange;// If the player is in range to the npc (true) if not (false)
    public GameObject contButton;
    public PlayerMovementJK movement;
    private Coroutine typingCoroutine;
    public GameObject interactButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && !dialoguePanel.activeInHierarchy)
        {
            interactButton.SetActive(true);
        }
        else if (!playerInRange)
        {
            interactButton.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        { // If Player is in range and press space it will active the dialogue box
            if (!dialoguePanel.activeInHierarchy)// If the dialogue panel is not active
            {
                dialoguePanel.SetActive(true); // Turns on the dialogue
                movement.enabled = false; // disable the movement by disabling the movement script
                typingCoroutine = StartCoroutine(Typing()); // Type out the dialogue
                contButton.SetActive(true); //Turns on the continue button 
                interactButton.SetActive(false); // Turns off the interact button above the npc while it's talking

            }

        }

        if (dialougeText.text == dialogue[index]) // If the all the text is completed
        {
            contButton.SetActive(true); // Active the continue button
        }
        /*  else
          {

              contButton.SetActive(false); 
          } */


    }
    public void zeroText()

    {
        dialougeText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        movement.enabled = true;
    }
    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialougeText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

    }
    public void Nextline()
    {
        //contButton.SetActive(false);
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }


        if (index < dialogue.Length - 1)
        {
            index++;
            dialougeText.text = "";
            typingCoroutine = StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }
    // This method is used to make playerInRange turn to true when the player is near the NPC
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
            zeroText();
        }
    }
}
