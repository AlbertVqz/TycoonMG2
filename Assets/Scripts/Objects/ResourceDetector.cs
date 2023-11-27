using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDetector : MonoBehaviour
{
    // Variable publica
    public ResourceManager resourceManager;

    // Si un objeto entra en el collider
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto es un recurso
        if (other.gameObject.CompareTag("Resource"))
        {
            resourceManager.AddResources(other.gameObject.GetComponent<Resource>().value);
            Destroy(other.gameObject);
        }
    }
}
