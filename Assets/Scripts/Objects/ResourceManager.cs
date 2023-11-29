using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    // Variables publicas
    public Text resourceText;

    // variables privadas
    private float currentResources;

    // Singleton
    public static ResourceManager Instance { get; private set; }

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
        currentResources = 0f;
        UpdateUI();
    }

    // Funcion para agregar recursos
    public void AddResources(float _value)
    {
        currentResources += _value;
        UpdateUI();
    }

    // Funcion para quitar recursos
    public void RemoveResources(float _value)
    {
        currentResources -= _value;
        UpdateUI();
    }

    // Funcion para devolver la cantidad de recursos actuales
    public float GetCurrentResources()
    {
        return currentResources;
    }

    // Funcion para actualizar el UI
    public void UpdateUI()
    {
        resourceText.text = "Cash: $" + currentResources;
    }
}
