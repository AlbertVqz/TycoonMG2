using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Variables publicas
    public PlayerMovement playerMovement;
    public GroundDetector groundDetector;

    // Variables privadas
    private float speed;
    private bool isGrounded;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de variables
        speed = 0f;
        isGrounded = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetParameters();
        CheckSpeed();
        CheckGround();
    }

    // Funcion para actualizar los parametros del animator
    void SetParameters()
    {
        animator.SetFloat("Speed", speed);
        animator.SetBool("isGrounded", isGrounded);
    }

    // Funcion para conseguir la velocidad actual del jugador
    public void CheckSpeed()
    {
        speed = playerMovement.GetCurrentSpeed();
    }

    // Funcion para verificar si estamos tocando el suelo
    public void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }
}
