using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{
    // Variables publicas
    public float cost;
    public string text;

    public UnityEvent onActivated;

    // Variables privadas
    private TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        // Conseguir la referencia al text mesh
        textMesh = GetComponentInChildren<TextMesh>();

        // Ponemos el texto y el costo
        textMesh.text = text + " $" + cost;
    }

    // Si un objeto entra en el collider trigger
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entro es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            // Si el jugador tiene suficientes recursos
            if (ResourceManager.Instance.GetCurrentResources() >= cost)
            {
                // Quitamos el costo de la mejora, activamos el evento y nos destruimos
                ResourceManager.Instance.RemoveResources(cost);
                onActivated.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
