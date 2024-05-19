using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuzaklar : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sorryy :((");
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag == "Tuzak")
        {
            other.gameObject.GetComponent<PlayerManager>().getDamage(20);
        }
    }
}
