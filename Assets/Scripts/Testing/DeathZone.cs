using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_RespawnCC respawn = other.GetComponent<Player_RespawnCC>();
            if (respawn != null)
            {
                respawn.Respawn();
                Debug.Log("Jugador cayó al vacío. Respawn en último checkpoint.");
            }
        }
    }
}