using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float scrollStrength = 1;

    [SerializeField] Material notActiveTrigger;
    [SerializeField] Material activeTrigger;

    [HideInInspector] public GameObject active;
    void OnGUI()
    {
        transform.position -= Vector3.up * scrollStrength * Input.GetAxis("Mouse ScrollWheel");
    }
    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mousePos.y;
        mousePos.y = 0;

        mousePos.x -= Screen.width / 2;
        mousePos.z -= Screen.height / 2;
        if ((mousePos.x * 0.01f * speed) * (mousePos.x * 0.01f * speed) > 2 ||
            (mousePos.z * 0.01f * speed) * (mousePos.z * 0.01f * speed) > 2)
            transform.position -= mousePos * 0.01f * speed * Time.deltaTime;

        Ray ray;
        RaycastHit hit1;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit1))
        {

            if (hit1.collider.gameObject.layer == 13)
            {
                if (active != hit1.collider.gameObject)
                {
                    if (active)
                    {
                        active.GetComponent<Renderer>().material = notActiveTrigger;
                    }
                    active = hit1.collider.gameObject;
                }
                active.GetComponent<Renderer>().material = activeTrigger;
            }
            else
                active.GetComponent<Renderer>().material = notActiveTrigger;
        }
    }
}