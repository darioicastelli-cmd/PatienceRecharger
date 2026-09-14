using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Script_All_HPSelf playerHP; // Referencia al script de vida del jugador
    [SerializeField] private TextMeshProUGUI healthText; // Texto en pantalla

    private void Update()
    {
        if (playerHP != null && healthText != null)
        {
            healthText.text = playerHP.GetHealthPoints() + " / " + playerHP.GetMaxHealthPoints();
        }
    }
}