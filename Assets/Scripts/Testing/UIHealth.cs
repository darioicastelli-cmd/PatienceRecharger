using UnityEngine;
using TMPro;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private Script_All_HPSelf playerHP; // Referencia al script de vida del jugador
    [SerializeField] private TextMeshProUGUI healthText; // Texto en pantalla

    private void Update()
    {
        if (playerHP != null && healthText != null)
        {
            healthText.text = "HP: " + playerHP.GetHealthPoints() + " / " + playerHP.GetMaxHealthPoints();
        }
    }
}