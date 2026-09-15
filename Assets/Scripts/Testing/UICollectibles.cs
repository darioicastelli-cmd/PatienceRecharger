using UnityEngine;
using TMPro;

public class UICollectibles : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Player_Inventory playerInventory;

    [Header("Textos UI")]
    [SerializeField] private TextMeshProUGUI gemText;
    [SerializeField] private TextMeshProUGUI talismanText;
    [SerializeField] private TextMeshProUGUI keyFragmentText;

    private void Start()
    {
        UpdateUI();

        // Suscribirse al evento de inventario (si lo implementaste antes)
        if (playerInventory != null)
        {
            playerInventory.OnInventoryChanged += UpdateUI;
        }
    }

    private void OnDestroy()
    {
        if (playerInventory != null)
        {
            playerInventory.OnInventoryChanged -= UpdateUI;
        }
    }

    public void UpdateUI()
    {
        if (playerInventory == null) return;

        int gems = playerInventory.GetItemCount(ItemId.Gem);
        int talismans = playerInventory.GetItemCount(ItemId.Talisman);
        int keyFragments = playerInventory.GetItemCount(ItemId.KeyFragment);

        if (gemText != null) gemText.text = $"Gems: {gems}";
        if (talismanText != null) talismanText.text = $"Talismans: {talismans}";
        if (keyFragmentText != null) keyFragmentText.text = $"Key Fragments: {keyFragments}";
    }
}
