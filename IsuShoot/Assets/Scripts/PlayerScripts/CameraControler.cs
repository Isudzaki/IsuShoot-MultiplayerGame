using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private float mouseX, mouseY;
    public float sensetivitiMouse = 200f;

    public Transform PLayer;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensetivitiMouse * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensetivitiMouse * Time.deltaTime;

        PLayer.Rotate(mouseX * new Vector3(0, 1, 0));

        transform.Rotate(-mouseY * new Vector3(1, 0, 0));
    }
}
