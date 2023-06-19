using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public playerMovement playerMovement;
    private void OnTriggerEnter(Collider other)
    {
        if(CompareTag("Fly")){
            // Get the PlayerMovement script from the player object
            playerMovement = other.GetComponent<playerMovement>();

            // Call a method on the PlayerMovement script to enable flying
            playerMovement.EnableFlying();

            // Disable the power-up object
            //gameObject.SetActive(false);
        }
        if(CompareTag("Clear")){
            playerMovement = other.GetComponent<playerMovement>();
            // Call a method on the PlayerMovement script to clear effects
            playerMovement.ClearEffects();
        }
    }  
}
