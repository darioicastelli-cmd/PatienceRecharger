using UnityEngine;

public class Player_RespawnCC : MonoBehaviour
{
    private Vector3 lastCheckpoint;
    private Script_All_HPSelf healthSystem;
    private CharacterController cc;

    private void Start()
    {
        healthSystem = GetComponent<Script_All_HPSelf>();
        cc = GetComponent<CharacterController>();

        // Por defecto, el primer checkpoint es la posición inicial del jugador
        lastCheckpoint = transform.position;
    }

    public void SetCheckpoint(Vector3 checkpointPos)
    {
        lastCheckpoint = checkpointPos;
    }

    public void Respawn()
    {
        if (cc != null)
        {
            cc.enabled = false; // desactivar CharacterController para mover
            transform.position = lastCheckpoint;
            cc.enabled = true;  // reactivar
        }
        else
        {
            transform.position = lastCheckpoint;
        }

        // Quitar 1 punto de vida
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(1);
        }
    }
}