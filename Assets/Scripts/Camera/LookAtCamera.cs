using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Variable privada
    private Transform mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de variables
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Miramos hacia la camara
        transform.LookAt(mainCamera);
    }
}
