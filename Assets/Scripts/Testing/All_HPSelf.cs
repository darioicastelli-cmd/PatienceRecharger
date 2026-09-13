using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_All_HPSelf : MonoBehaviour
{
    [SerializeField] private int maxHealthPoints = 5;
    private int healthPoints;

    [SerializeField] private bool isPlayer = false; // true = jugador, false = enemigo

    // Getter y Setter
    public int GetHealthPoints() => healthPoints;
    public int GetMaxHealthPoints() => maxHealthPoints;

    public void SetHealthPoints(int value)
    {
        healthPoints = Mathf.Clamp(value, 0, maxHealthPoints);
        CheckDeath();
    }

    public void TakeDamage(int damage)
    {
        SetHealthPoints(healthPoints - damage);
    }

    public void Heal(int amount)
    {
        SetHealthPoints(healthPoints + amount);
    }

    private void Start()
    {
        healthPoints = maxHealthPoints;
    }

    private void CheckDeath()
    {
        if (healthPoints <= 0)
        {
            if (isPlayer)
            {
                SceneManager.LoadScene("ZZ_Lose");
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}