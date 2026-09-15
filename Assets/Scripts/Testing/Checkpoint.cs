using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_RespawnCC respawn = other.GetComponent<Player_RespawnCC>();
            if (respawn != null)
            {
                respawn.SetCheckpoint(transform.position);
                Debug.Log("Checkpoint actualizado en: " + transform.position);
            }
        }
    }
}