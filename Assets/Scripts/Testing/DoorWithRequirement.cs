using UnityEngine;
using TMPro;

public class DoorWithRequirement : DoorInteractable
{
    [Header("Requisitos de inventario")]
    [SerializeField] private ItemId requiredItem;
    [SerializeField] private int requiredAmount;
    [SerializeField] private Player_Inventory playerInventory;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI requirementText; // arrastrá el texto en el inspector

    private void Start()
    {
        UpdateRequirementUI();
    }
    public override void Interact()
    {
        if (playerInventory == null)
        {
            Debug.LogError("⚠️ No se asignó el Player_Inventory en el inspector.");
            return;
        }

        int currentAmount = playerInventory.GetItemCount(requiredItem);

        if (currentAmount >= requiredAmount)
        {
            Debug.Log("Requisito cumplido, abriendo puerta...");
            base.Interact(); // esto alterna isOpen y activa la animación
        }
        else
        {
            Debug.Log($"Necesitás {requiredAmount} {requiredItem}, pero tenés {currentAmount}.");
        }
    }
    private void UpdateRequirementUI()
    {
        if (requirementText != null && playerInventory != null)
        {
            int currentAmount = playerInventory.GetItemCount(requiredItem);
            requirementText.text = $"Necesitás {requiredAmount} {requiredItem}\nTienes {currentAmount}";
        }
    }
}