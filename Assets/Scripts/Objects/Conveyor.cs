using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    // Variables publicas
    public float speed;

    // Variables privadas
    private Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de variables
        movementVector = transform.forward * speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        // Si el objeto que colisiona es un recurso
        if (collision.gameObject.CompareTag("Resource"))
        {
            // Lo movemos en direccion de la cinta
            Transform collidedObject = collision.gameObject.transform;
            collidedObject.position = new Vector3(collidedObject.position.x + movementVector.x * Time.deltaTime,
                                                  collidedObject.position.y + movementVector.y * Time.deltaTime,
                                                  collidedObject.position.z + movementVector.z * Time.deltaTime);
        }
    }
}
