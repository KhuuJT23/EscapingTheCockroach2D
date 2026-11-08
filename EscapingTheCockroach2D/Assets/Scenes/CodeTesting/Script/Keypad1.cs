
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Keypad1 : MonoBehaviour
{
    public GameObject keypadPanel;
    public TMP_InputField codeInput;
    public TMP_Text messageText;
    public PlayerMovementJK movement;

    public GameObject door;

    public string correctCode = "1234";

    public bool playerInRange;
    public GameObject InButt;

    void Update()
    {
        if(playerInRange)
        {
            InButt.SetActive(true);
        }else if(!playerInRange)
        {
            InButt.SetActive(false);
        }
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            keypadPanel.SetActive(true);
            messageText.text = "";
            movement.enabled = false;
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            keypadPanel.SetActive(false);
            movement.enabled = true;
        }
    }

    public void CheckCode()
    {
        if (codeInput.text == correctCode)
        {
            messageText.text = "Access Granted!";

            SceneManager.LoadScene("YouWin");

            keypadPanel.SetActive(false);
        }
        else
        {
            messageText.text = "Incorrect Code! Try again";
            codeInput.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            keypadPanel.SetActive(false);
        }
    }
}
