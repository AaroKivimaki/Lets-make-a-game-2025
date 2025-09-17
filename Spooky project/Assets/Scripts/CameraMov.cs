using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraMov : MonoBehaviour
{
    public float sensX;
    public float sensY;
    float xRotaatio;
    float yRotaatio;
    public Transform orientaatio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float y = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotaatio += x;
        xRotaatio -= y;
        xRotaatio = Mathf.Clamp(xRotaatio, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotaatio, yRotaatio, 0);
        orientaatio.rotation = Quaternion.Euler(0, yRotaatio, 0);
    }
}
