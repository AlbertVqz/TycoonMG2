using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCollector : MonoBehaviour
{
    // Variables privadas
    private TextMesh textMesh;
    private float currentResources;

    // Singleton
    public static ResourceCollector Instance { get; private set; }

    private void Awake()
    {
        // Verificacion del singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de variables
        textMesh = GetComponentInChildren<TextMesh>();
        currentResources = 0f;
        UpdateText();
    }

    // Funcion para agregar recursos
    public void AddResources(float _value)
    {
        currentResources += _value;
        UpdateText();
    }

    // Funcion para actualizar el texto
    public void UpdateText()
    {
        textMesh.text = "$" + currentResources;
    }

    // Si un objeto entra en el collider trigger
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entro es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            // Enviamos los recursos a ResourceManager, vaciamos los recursos y actualizamos el texto
            ResourceManager.Instance.AddResources(currentResources);
            currentResources = 0f;
            UpdateText();
        }
    }
}
