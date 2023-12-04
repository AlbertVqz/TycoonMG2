using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorkstation : MonoBehaviour
{
    // Variables publicas
    public Transform spawnLocation;
    public GameObject resource;
    public float spawnRate;

    // Variables privadas
    private bool canSpawn = true;

    // Funcion para spawnear recursos
    public void SpawnResource()
    {
        // Si puede spawnear
        if (canSpawn)
        {
            // Spawneamos el objeto y activamos la corrutina de cooldown
            Instantiate(resource, spawnLocation.position, Quaternion.identity);
            StartCoroutine(CooldownCoroutine());
        }
    }

    // Corrutina de cooldown
    IEnumerator CooldownCoroutine()
    {
        // Esperamos el tiempo de cooldown para poder spawnear de nuevo
        canSpawn = false;
        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
    }
}
