using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void ExitToMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void PlayTutorial() {
        SceneManager.LoadScene(1);
    }

    public void PlayGame() {
        SceneManager.LoadScene(2);
    }

    public void QuitGame() {
        Debug.Log("Quiting game...");
        Application.Quit();
    }
}
