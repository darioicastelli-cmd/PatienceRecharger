using UnityEngine;

public class Script_Player_Collectibles : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonidoOrb;
    public AudioClip sonidoKey;
    public AudioClip sonidoDiary;

    // Contadores
    public int orbCount = 0;
    public int keyCount = 0;
    public int diaryCount = 0;

    // Totales
    public int orbTotal = 30;
    public int keyTotal = 10;
    public int diaryTotal = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible_Orb"))
        {
            orbCount++;
            audioSource.PlayOneShot(sonidoOrb);
            Debug.Log("El jugador consiguió un Orbe. Total: " + orbCount);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Collectible_Key"))
        {
            keyCount++;
            audioSource.PlayOneShot(sonidoKey);
            Debug.Log("El jugador consiguió una Llave. faltan: " + (keyTotal-keyCount));
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Collectible_Diary"))
        {
            diaryCount++;
            audioSource.PlayOneShot(sonidoDiary);
            Debug.Log("El jugador consiguió un Diario. Progreso: " + diaryCount+ " de "+diaryTotal);
            Destroy(other.gameObject);
        }
    }
}