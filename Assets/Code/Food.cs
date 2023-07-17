using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class Food : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out SnakeController snakeController))
            {
                snakeController.GrowSnake();
                gameObject.SetActive(false);

                RespawnFood();
            }
        }

        private void RespawnFood()
        {
            // Yeni konum için x ve y deðerlerini belirleyin
            float newX = Random.Range(-15.000f, 1.00f);
            float newZ = Random.Range(14.00f, 24.0f);
            Vector3 newPosition = new Vector3(newX, 17.098f, newZ);

            transform.position = newPosition;
            gameObject.SetActive(true);
        }
    }
}



