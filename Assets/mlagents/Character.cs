using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    


    public float speed = 5f; // Karakterin hareket h�z�
    private Vector3 moveDirection; // Hareket y�n�n� tutacak vekt�r

    void Update()
    {
        // WASD tu�lar� ile giri� al
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Giri�leri bir vekt�re d�n��t�r
        moveDirection = new Vector3(moveX, 0f, moveZ);

        // Hareket fonksiyonunu �a��r
        Move();
    }



    void Move()
    {
        // Karakteri hareket ettir
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }


}

