using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    // Variable publica
    public UnityEvent onInteract;

    // Funcion de interaccion
    public void Interaction()
    {
        onInteract.Invoke();
    }
}
