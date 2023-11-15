using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    // Variables publicas
    public float radius;
    public LayerMask detectedLayers;

    // Variable privada
    private bool isGrounded;

    private void Start()
    {
        // Inicializacion de variables
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
    }

    // Funcion para detectar el suelo
    public void CheckGround()
    {
        isGrounded = Physics.CheckSphere(transform.position, radius, detectedLayers);
    }

    // Funcion para devolver el valor de isGrounded
    public bool GetIsGrounded()
    {
        return isGrounded;
    }
}
