using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player, cameraTrans;
	
    void Update(){
        cameraTrans.LookAt(player);
    }
}