using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame(){
        SceneManager.LoadScene(1);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void GameOver(){
        SceneManager.LoadScene(2);
    }

    public void QuitGame(){
        Debug.Log("Quiting Game");
        Application.Quit();
    }
}
