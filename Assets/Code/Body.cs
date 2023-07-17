using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] private Collider collider;

    public void Initiate()
    {
        StartCoroutine(OpenCollider());
    }
    
    private IEnumerator OpenCollider()
    {
        yield return new WaitForSeconds(1f);
        collider.enabled = true;
    }
}
