using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    // Variables publicas
    // --------------------------------- Resource text

    // variables privadas
    private float currentResources;

    // Start is called before the first frame update
    void Start()
    {
        currentResources = 0f;
    }

    // Funcion para agregar recursos
    public void AddResources(float _value)
    {
        currentResources += _value;
        // ----------------------------- Update UI \(^w^)/
    }
}
