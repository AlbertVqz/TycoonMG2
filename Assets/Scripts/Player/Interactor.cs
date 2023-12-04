using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    // Variable publica
    public float radius;

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    // Funcion de interaccion
    void Interact()
    {
        // Checar que el jugador presione la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractableObject _interactableObject = null;
            float _distanceFromObject = radius + 1f;

            // Buscamos los objetos interactuables en la cercania
            RaycastHit[] _objects = Physics.SphereCastAll(transform.position, radius, transform.forward);

            // Si la esfera colisiono con objetos
            if (_objects != null)
            {
                // Buscamos el objeto interactuable mas cercano
                foreach (RaycastHit _collidedObject in _objects)
                {
                    // Si el objeto es un objeto interactuable
                    if (_collidedObject.collider.gameObject.GetComponent<InteractableObject>() != null)
                    {
                        // Verificamos si esta mas cerca que el anterior
                        if (Vector3.Distance(transform.position, _collidedObject.collider.gameObject.transform.position) < _distanceFromObject)
                        {
                            // Guardamos el objeto y su distancia al player
                            _distanceFromObject = Vector3.Distance(transform.position, _collidedObject.collider.gameObject.transform.position);
                            _interactableObject = _collidedObject.collider.gameObject.GetComponent<InteractableObject>();
                        }
                    }
                }

                // Si encontramos un objeto interactuable, interactuamos con el
                if (_interactableObject != null)
                {
                    _interactableObject.Interaction();
                }
            }
        }
    }
}
