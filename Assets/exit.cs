using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void QuitGame()
    {

        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();

    }
}