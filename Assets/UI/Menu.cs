using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGame
{
    public class Menu : MonoBehaviour
    {

        public void PlayButton()
        {
            SceneManager.LoadScene("Game");
        }


        public void ContinueButton()
        {
            SceneManager.LoadScene(2);
        }

        public void SettingsButton()
        {
            SceneManager.LoadScene(3);
        }

        public void CreditsButton()
        {
            SceneManager.LoadScene(4);
        }
    }

}

