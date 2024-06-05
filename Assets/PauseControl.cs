using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    public void Pause()
    {
       
        Time.timeScale = 0;

    }
    public void home()
    {
        SceneManager.LoadScene("Lv0");
        Time.timeScale = 1;
    }
    public void Resume()
    {
        
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
