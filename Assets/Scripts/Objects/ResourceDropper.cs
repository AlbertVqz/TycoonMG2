using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropper : MonoBehaviour
{
    // Variables publicas
    public GameObject[] resources;
    public float spawnTime;

    // Variables privadas
    private int dropperTier;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de variables
        isActive = true;
        dropperTier = 1;
        StartCoroutine(SpawnCoroutine());
    }

    // Funcion para instanciar un recurso
    void DropResource()
    {
        // Si el espacio en la lista no esta vacio
        if (resources[dropperTier - 1] != null)
        {
            Instantiate(resources[dropperTier - 1], transform.position, Quaternion.identity);
        }
    }

    // Funcion para cambiar el estado del dropper
    public void ChangeState(bool _state)
    {
        isActive = _state;
        // Si el estado es true o activo
        if (isActive)
        {
            StartCoroutine(SpawnCoroutine());
        }
    }

    // Funcion para mejorar el tier del dropper
    public void UpgradeDropper()
    {
        // Verificar que el siguiente nivel no supere la cantidad de recursos
        if (dropperTier + 1 <= resources.Length)
        {
            dropperTier++;
        }
    }

    // Corrutina para dropear los recursos
    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(spawnTime);
        DropResource();
        if (isActive)
        {
            StartCoroutine(SpawnCoroutine());
        }
    }
}
