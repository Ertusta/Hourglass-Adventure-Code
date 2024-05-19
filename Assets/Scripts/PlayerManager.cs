using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[5];
    public int totalClock = 5;
    public int clockCount = 0;
    private GameObject currentItem;

    public GameObject deadScreen;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key pressed");
            if (currentItem != null)
            {
                Debug.Log("Picking up item: " + currentItem.name);
                addInventory(currentItem);
                currentItem.SetActive(false);
                currentItem = null;
            }
        }
    }

    //Inventory codes and for test purposes Debug.Logs
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with object: " + other.name);
        if (other.CompareTag("SandClock"))
        {
            currentItem = other.gameObject;
            Debug.Log("SandClock detected and assigned to currentItem");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SandClock"))
        {
            if (currentItem == other.gameObject)
            {
                currentItem = null;
                Debug.Log("Exited trigger of SandClock, currentItem set to null");
            }
        }
    }

    public void addInventory(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                clockCount++;
                inventory[i] = item;
                Debug.Log("Item added to inventory at slot " + i+1);

                if (clockCount == totalClock)
                {
                    Debug.Log("All clocks collected, level cleared!");
                    // GO TO WIN SCENE SINCE ALL THE CLOCKS ARE COLLECTED !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                }

                return;
            }
        }

        for (int i = 0; i < inventory.Length; i++)
        {
            Debug.Log(inventory[i] != null ? inventory[i].name : "Empty slot");
        }
    }
    
    //Player will start the level again when he/she is dead
    public float health = 100;
    public Transform bloodParticle;
    public bool dead = false;
    
    public void getDamage(float damage)
    {
        Instantiate(bloodParticle, transform.position, Quaternion.identity);
        if ((health - damage) >= 0)
        {
            health = health - damage;
        }
        else
        {
            health = 0;
        }
        isDead();   // every damage check if it is dead
    }
    
    void isDead()
    {
        if (health <= 0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity),3f);
            dead = true;
            deadScreen.SetActive(true);
            SceneManager.LoadScene("Level 3 - Parkur");
        }
    }
    
}
