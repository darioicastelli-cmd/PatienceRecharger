using UnityEngine;
using TMPro;
using System.Collections;

public class DoorWithRequirement : DoorInteractable
{
    [Header("Requisitos de inventario")]
    [SerializeField] private ItemId requiredItem;
    [SerializeField] private int requiredAmount;
    [SerializeField] private Player_Inventory playerInventory;

    [Header("UI en la puerta")]
    [SerializeField] private TextMeshProUGUI requirementText; // texto fijo en la puerta

    [Header("UI de aviso general")]
    [SerializeField] private GameObject warningPanel;         // panel de aviso
    [SerializeField] private TextMeshProUGUI warningText;     // texto dentro del panel

    private void Start()
    {
        UpdateRequirementUI();
        if (playerInventory != null)
            playerInventory.OnInventoryChanged += UpdateRequirementUI;
    }

    public override void Interact()
    {
        if (playerInventory == null)
        {
            Debug.LogError("No se asignó el Player_Inventory en el inspector.");
            return;
        }

        int currentAmount = playerInventory.GetItemCount(requiredItem);

        if (currentAmount >= requiredAmount)
        {
            Debug.Log("Requisito cumplido, abriendo puerta...");
            base.Interact(); // abre la puerta
        }
        else
        {
            Debug.Log($"Necesitás {requiredAmount} {requiredItem}, pero tenés {currentAmount}.");

            //Mostrar cartel en pantalla y ocultarlo luego de 3 segundos
            if (warningPanel != null && warningText != null)
            {
                warningPanel.SetActive(true);
                warningText.text = $"No tienes la cantidad necesaria de {requiredItem} para abrir esta puerta.";
                StartCoroutine(HideWarningAfterDelay(3f));
            }
        }
    }

    private void UpdateRequirementUI()
    {
        int currentAmount = playerInventory.GetItemCount(requiredItem);
        if (requirementText != null && playerInventory != null)
        {
            requirementText.text = $"Necesitás {requiredAmount} {requiredItem}, \nTienes {currentAmount}.";
        }
    }

    // corrutina para timer del cartel
    private IEnumerator HideWarningAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        warningPanel.SetActive(false);
    }
}
