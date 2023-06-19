using UnityEngine;

public class ButtonSpam : MonoBehaviour
{
    public float interactionDistance = 2f;
    public GameObject buttonSoundSourcePrefab;
    public float buttonMoveDistance = 0.1f;
    public float buttonMoveTime = 1f;
    public GameObject door;
    
    private bool isPromptShowing = false;
    private bool isButtonPressed = false;

    private GameObject buttonSoundSource;
    private Vector3 initialPos;
    
    private void Start()
    {
        initialPos = transform.position;
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
                    
                    // Start the button movement coroutine
                    StartCoroutine(ButtonMovementCoroutine());

                    // Prevent further interaction with the button
                    //isButtonPressed = true;
                }
            }
        }
        else
        {
            // Hide prompt if the player is not within the interaction distance
            if (isPromptShowing)
            {
                HidePrompt();
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
        // Instantiate the button sound source prefab if it doesn't exist
        if (buttonSoundSource == null && buttonSoundSourcePrefab != null)
        {
            buttonSoundSource = Instantiate(buttonSoundSourcePrefab, transform.position, Quaternion.identity);
        }

        // Play the button sound
        if (buttonSoundSource != null)
        {
            AudioSource audioSource = buttonSoundSource.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    private void PerformButtonAction()
    {
        Debug.Log("Button pressed!");

        if (door != null)
        {
            Destroy(door);
        }
    }
    
    private System.Collections.IEnumerator ButtonMovementCoroutine()
    {
        float elapsedTime = 0f;
        Vector3 targetPosition = initialPos + -transform.up * buttonMoveDistance;

        while (elapsedTime < buttonMoveTime)
        {
            transform.position = Vector3.Lerp(initialPos, targetPosition, elapsedTime / buttonMoveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;

        while (elapsedTime < buttonMoveTime)
        {
            transform.position = Vector3.Lerp(targetPosition, initialPos, elapsedTime / buttonMoveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = initialPos;
    }
}
