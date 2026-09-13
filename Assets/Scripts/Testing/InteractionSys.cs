using UnityEngine;
using UnityEngine.InputSystem; // nuevo sistema

public interface IInteractableObject
{
    void Interact();
    void OnHover();
    void OnHoverExit();

}
