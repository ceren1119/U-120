using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class Wall : MonoBehaviour
    {
        public GameObject resultPanel; // Sonuç ekranýný temsil eden bir GameObject referansý

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
            resultPanel.SetActive(true); // Sonuç ekranýný etkinleþtir
        }
    }

}

