using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MiniGame
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button restartButton;
        
        private void Awake()
        {
            startButton.onClick.AddListener(PlayButtonOnClick);
            restartButton.onClick.AddListener(RestartButtonOnClick);
        }

        private void Start()
        {
            Time.timeScale = 0;
        }

        private void PlayButtonOnClick()
        {
            Time.timeScale = 1;
        }

        private void RestartButtonOnClick()
        {
            SceneManager.LoadScene(0);
        }
    }

}

