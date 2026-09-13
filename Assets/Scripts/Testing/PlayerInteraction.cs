using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions; // referencia al asset
    private InputAction interactAction;

    // distancia maxima a la que el Player puede interactuar
    public float interactionDistance = 3f;

    private void Awake()
    {
        // Buscamos la acción "Interact" dentro del mapa "Player"
        var playerMap = inputActions.FindActionMap("Player");
        interactAction = playerMap.FindAction("Interact");
    }

    private void OnEnable()
    {
        interactAction.Enable();
    }

    private void OnDisable()
    {
        interactAction.Disable();
    }
    void Update()
    {
        // comprobamos si Player presiona la tecla E (Habría que cambiarlo a la tecla de interacción) 
        if (interactAction.WasPerformedThisFrame())
        {
            Debug.Log("Se presionó la tecla E");
            // buscamos todos los objetos que hereden de "Interactable"
            Interactable[] interactables =
                FindObjectsByType<Interactable>(FindObjectsSortMode.None);

            Debug.Log("🔎 Cantidad de interactuables encontrados: " + interactables.Length);

            Interactable closest = null; // guardamos el objeto interactuable mas cercano
            float closestDistance = interactionDistance; //consideramos como distancia maxima la distancia ya definida

            // recorremos todos los objetos interactuables
            foreach (Interactable interactable in interactables)
            {
                
                float distance = Vector3.Distance(    // calculamos la distancia entre el Player y el objeto
                    transform.position,
                    interactable.transform.position
                );

                Debug.Log($"Objeto: {interactable.name}, distancia: {distance}");
                if (distance < closestDistance) // si esta mas cerca que el objeto anterior lo guardamos como el mas cercano
                {
                    closest = interactable;
                    closestDistance = distance;
                    Debug.Log($"➡️ Nuevo más cercano: {closest.name} a {closestDistance} unidades");
                }
            }

            if (closest != null)
            {
                Debug.Log("🚪 Interactuando con: " + closest.name);
                closest.Interact(); // Ejecutamos su metodo Interact
            }
            else
            {
                Debug.Log("❌ No hay interactuables dentro de la distancia " + interactionDistance);
            }
        }
    }
}