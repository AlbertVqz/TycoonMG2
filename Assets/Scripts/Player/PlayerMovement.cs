using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables publicas
    public Transform cameraAim;
    public float walkSpeed, runSpeed, jumpForce, rotationSpeed;
    public bool canMove;
    public GroundDetector groundDetector;

    // Variables privadas
    private Vector3 movementVector, verticalForce;
    private float speed, currentSpeed;
    private bool isGrounded;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de variables
        characterController = GetComponent<CharacterController>();
        speed = 0f;
        currentSpeed = 0f;
        movementVector = Vector3.zero;
        verticalForce = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Si nos podemos mover
        if (canMove)
        {
            Walk();
            Run();
            AlignPlayer();
            Jump();
        }

        // Gravedad y check ground
        Gravity();
        CheckGround();
    }

    // Funcion para caminar
    void Walk()
    {
        // Conseguir los inputs WASD
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");

        // Normalizamos el vector de movimiento
        movementVector = movementVector.normalized;

        // Orientamos el vector de movimiento hacia la direccion de la camara
        movementVector = cameraAim.TransformDirection(movementVector);

        // Guardar la velocidad actual con suavizado
        currentSpeed = Mathf.Lerp(currentSpeed, movementVector.magnitude * speed, 10f * Time.deltaTime);

        // Nos movemos
        characterController.Move(movementVector * currentSpeed * Time.deltaTime);
    }

    // Funcion para correr
    void Run()
    {
        // Si presionamos el boton para correr modificamos la velocidad
        if (Input.GetAxis("Run") > 0f)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }

    // Funcion para saltar
    void Jump()
    {
        // Si estamos tocando el suelo
        if (isGrounded && Input.GetAxis("Jump") > 0f)
        {
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
        }
    }

    // Funcion de gravedad
    void Gravity()
    {
        // Si no estamos tocando el suelo
        if (!isGrounded)
        {
            // Aplicamos la aceleracion de la gravedad
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        // Si estamos tocando el suelo
        else
        {
            // Aplicamos una pequeña fuerza hacia abajo
            verticalForce = new Vector3(0f, -2f, 0f);
        }

        // Aplicamos las fuerzas
        characterController.Move(verticalForce * Time.deltaTime);
    }

    // Funcion para alinear el jugador hacia el movimiento
    void AlignPlayer()
    {
        // Si nos estamos moviendo entonces alineamos al jugador
        if (characterController.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementVector), rotationSpeed * Time.deltaTime);
        }
    }

    // Funcion para detectar el suelo
    void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }

    // Funcion para devolver el valor de la velocidad actual
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
