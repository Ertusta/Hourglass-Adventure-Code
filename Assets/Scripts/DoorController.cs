using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject clues;

    private void Start()
    {
        clues.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You only have one chance to look for clues. Be careful!");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Currently inside.");
    }

    private void OnTriggerExit(Collider other)
    {
        clues.SetActive(false);
    }
}