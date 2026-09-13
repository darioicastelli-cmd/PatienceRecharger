using UnityEngine;
using UnityEngine.SceneManagement;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public void LoadScene (string SceneName)
    {
        SceneManager.LoadScene (SceneName);
    }

    public void QuitGame()
    {
        Application.Quit ();
    }
}
