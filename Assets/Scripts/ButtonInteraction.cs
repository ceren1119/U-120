using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public float interactionDistance = 2f;
    public AudioClip buttonSound;

    private bool isPromptShowing = false;
    private AudioSource audioSource;
    private bool isButtonPressed = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player object not found. The 'Player' tag might be missing.");
            return;
        }
        
        // Check if the player is within the interaction distance
        if (Vector3.Distance(transform.position, player.transform.position) <= interactionDistance)
        {
            // Show prompt if it's not already showing
            if (!isPromptShowing)
            {
                ShowPrompt();
            }

            // Check for button press
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isButtonPressed)
                {
                    // Play button sound
                    PlayButtonSound();
                    
                    // Perform button action (e.g., open a door, trigger an event)
                    PerformButtonAction();

                    // Prevent further interaction with the button
                    isButtonPressed = true;
                }
            }
        }
        else
        {
            // Hide prompt if the player is not within the interaction distance
            if (isPromptShowing)
            {
                HidePrompt();
                isButtonPressed = false;
            }
        }
    }

    private void ShowPrompt()
    {
        // Show the "Press E" prompt on the screen
        Debug.Log("Press E");
        isPromptShowing = true;
    }

    private void HidePrompt()
    {
        // Hide the "Press E" prompt from the screen
        Debug.Log("Hide Prompt");
        isPromptShowing = false;
    }

    private void PlayButtonSound()
    {
        // Play the button sound
        if (audioSource != null && buttonSound != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }
    }

    private void PerformButtonAction()
    {
        // This is where you define what the button does when pressed
        Debug.Log("Button pressed!");
        // Add your custom logic here
    }
}
