using UnityEngine;

// Esta clase representa una puerta que puede ser activada por un sistema de interacción.
public class DoorInteractable : Interactable
{
    // Agrupa en el Inspector los valores que controlan la animación de la puerta.
    [Header("Animación de la puerta")]
    //toma el punto pivote que deifinimos
    [SerializeField] private Transform pivot;
    // Indica cuántos grados gira la puerta cuando se abre.
    [SerializeField] private float openAngle = 90f;
    // Indica cuántos grados por segundo puede girar la puerta.
    [SerializeField] private float rotationSpeed = 180f;
    // Permite decidir desde el Inspector si la escena empieza con la puerta abierta.
    [SerializeField] private bool startsOpen;

    // Guarda la rotación local original para poder cerrar la puerta con precisión.
    private Quaternion closedRotation;
    // Guarda la rotación local que corresponde al estado abierto.
    private Quaternion openRotation;
    // Guarda el estado lógico actual de la puerta.
    private bool isOpen;
    // Evita que una interacción ocurra antes de terminar la inicialización.
    private bool isInitialized;

    // Se ejecuta una vez cuando el objeto entra en la escena.
    private void Awake()
    {
        if (pivot == null)
        {
            Debug.LogError("No se asignó el DoorPivot en el inspector.");
            return;
        }

        // Usamos la rotación absoluta del pivot
        closedRotation = pivot.rotation;
        openRotation = closedRotation * Quaternion.Euler(0f, openAngle, 0f);
        isOpen = startsOpen;
        isInitialized = true;
        pivot.rotation = isOpen ? openRotation : closedRotation;
    }

    // Cambia la puerta entre abierta y cerrada.
    public override void Interact()
    {
        // Ignora llamadas prematuras por seguridad.
        if (!isInitialized)
        {
            return;
        }

        // Invierte el estado actual para alternar entre abrir y cerrar.
        isOpen = !isOpen;
        // Informa en la consola qué interacción detectó el alumno.
        Debug.Log($"[Raycast] La puerta {(isOpen ? "se está abriendo" : "se está cerrando")}.");
    }

    // Se ejecuta una vez por frame y suaviza el giro visual de la puerta.
    private void Update()
    {
        if (!isInitialized) return;

        Quaternion targetRotation = isOpen ? openRotation : closedRotation;
        pivot.rotation = Quaternion.RotateTowards(
            pivot.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    public bool IsOpen => isOpen;
}