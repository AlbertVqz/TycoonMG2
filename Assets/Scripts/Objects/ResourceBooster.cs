using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBooster : MonoBehaviour
{
    // Variable publica
    public float multiplier;

    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos que el objeto que entro en el trigger sea un recurso
        if (other.gameObject.GetComponent<Resource>() != null)
        {
            other.gameObject.GetComponent<Resource>().value *= multiplier;
        }
    }
}
