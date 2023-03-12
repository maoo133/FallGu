using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookFallGuys : MonoBehaviour
{
    float mouseSense = 1;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        float rotateX = Input.GetAxis("Mouse X") * mouseSense;
        float rotateY = Input.GetAxis("Mouse Y") * mouseSense;
        Vector3 rotPlayer = transform.rotation.eulerAngles;
        
        rotPlayer.y += rotateX;
        
        transform.rotation = Quaternion.Euler(rotPlayer);
    }
}
