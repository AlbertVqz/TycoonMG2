using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Variables publicas
    public float sensibility;
    public Transform cameraAimY;
    public Transform targetObject;

    // Variables privadas
    private float xRotation, yRotation;
    private bool canRotate;

    private void Start()
    {
        // Inicializacion de variables
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Si podemos rotar entonces rotamos
        if (canRotate)
        {
            Rotate();
        }

        // Seguimos al objetivo
        FollowTarget();
    }

    // Funcion para rotar la camara
    void Rotate()
    {
        // Conseguir los inputs de mouse
        xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensibility;
        yRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * sensibility;

        // Ponemos limite en la rotacion en Y
        yRotation = Mathf.Clamp(yRotation, -65, 65);

        // Rotamos la camara
        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        cameraAimY.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
    }

    // Funcion para seguir al objeto target
    void FollowTarget()
    {
        transform.position = targetObject.position;
    }
}
