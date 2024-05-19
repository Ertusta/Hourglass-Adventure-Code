using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    


    public float speed = 5f; // Karakterin hareket hýzý
    private Vector3 moveDirection; // Hareket yönünü tutacak vektör

    void Update()
    {
        // WASD tuþlarý ile giriþ al
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Giriþleri bir vektöre dönüþtür
        moveDirection = new Vector3(moveX, 0f, moveZ);

        // Hareket fonksiyonunu çaðýr
        Move();
    }



    void Move()
    {
        // Karakteri hareket ettir
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }


}

