using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1; // Configurable desde el Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto con el que chocamos tiene el script de vida
        Script_All_HPSelf hp = other.GetComponent<Script_All_HPSelf>();

        if (hp != null)
        {
            // Aplicamos daño usando el método TakeDamage
            hp.TakeDamage(damageAmount);

            // Desactivamos el proyectil para que no siga dañando
            gameObject.SetActive(false);
        }
    }
}