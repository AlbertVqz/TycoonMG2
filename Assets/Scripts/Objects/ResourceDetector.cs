using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDetector : MonoBehaviour
{
    // Si un objeto entra en el collider
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto es un recurso
        if (other.gameObject.CompareTag("Resource"))
        {
            ResourceCollector.Instance.AddResources(other.gameObject.GetComponent<Resource>().value);
            Destroy(other.gameObject);
        }
    }
}
