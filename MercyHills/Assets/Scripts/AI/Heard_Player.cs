using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heard_Player : MonoBehaviour
{
    [SerializeField] PlayerDetector heardPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            heardPlayer._detectedPlayer = other.gameObject.GetComponent<Controller>();
        }
    }
}
