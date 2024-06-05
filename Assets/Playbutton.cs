using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        // Dừng toàn bộ hoạt động của game
        Time.timeScale = 0f;

        // Bắt đầu tải màn chơi mới
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene()
    {
        // Dừng toàn bộ hoạt động của game
        Time.timeScale = 0f;

        // Tải lại màn chơi hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

