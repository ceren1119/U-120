using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class Food : MonoBehaviour
    {
        [SerializeField] private Vector2 xRange;
        [SerializeField] private Vector2 yRange;
        [SerializeField] private float yPos;
        
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
            // Yeni konum icin x ve y degerlerini belirleyin
            float newX = Random.Range(xRange.x, xRange.y);
            float newZ = Random.Range(yRange.x, yRange.y);
            Vector3 newPosition = new Vector3(newX, yPos, newZ);

            transform.position = newPosition;
            gameObject.SetActive(true);
        }
    }
}



