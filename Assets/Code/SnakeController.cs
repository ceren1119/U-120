using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class SnakeController : MonoBehaviour
    {
        [SerializeField] private GameObject finishPanel;
        [SerializeField] private Transform bodyParent;
        [SerializeField] private float startOffset;
        
        public float MoveSpeed = 1;
        public float SteerSpeed = 40;
        public float BodySpeed = 1;
        public int Gap = 5;

        public GameObject BodyPrefab;
        private List<GameObject> BodyParts = new List<GameObject>();
        private List<Vector3> PositionsHistory = new List<Vector3>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Body"))
            {
                Time.timeScale = 0;
                finishPanel.SetActive(true);
            }
        }

        // Update is called once per frame
        void Update()
        {
            // move forward
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            // steer
            float steerDirection = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

            // store position history
            PositionsHistory.Insert(0, transform.position - transform.forward * startOffset);

            // move body parts
            int index = 0;
            foreach (GameObject body in BodyParts)
            {
                Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)];
                Vector3 moveDirection = point - body.transform.position;
                body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
                body.transform.LookAt(point);
                index++;
            }

        }

        public void GrowSnake()
        {
            GameObject body = Instantiate(BodyPrefab, bodyParent);
            body.GetComponent<Body>().Initiate();
            BodyParts.Add(body);
        }
    }
}




