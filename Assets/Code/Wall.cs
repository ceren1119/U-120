using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class Wall : MonoBehaviour
    {
        public GameObject resultPanel; // Sonu� ekran�n� temsil eden bir GameObject referans�

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Snake"))
            {
                finishTheGame();
            }
        }

        private void finishTheGame()
        {
            Time.timeScale = 0f; // Oyunu durdur
            resultPanel.SetActive(true); // Sonu� ekran�n� etkinle�tir
        }
    }

}

