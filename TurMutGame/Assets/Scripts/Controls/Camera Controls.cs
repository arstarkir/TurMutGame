using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] float speed = 1;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mousePos.y;
        mousePos.y = 0;

        mousePos.x -= Screen.width / 2;
        mousePos.z -= Screen.height / 2;

        gameObject.transform.position -= mousePos*0.01f*speed*Time.deltaTime;
    }
}
