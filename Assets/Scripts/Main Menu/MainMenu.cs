using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private GameObject townHealthText;

    static private float townHealth = 0;

    public void ExitToMainMenu(GameObject townHealthBar) {
        townHealth = townHealthBar.GetComponent<TownHealthBar>().GetTownHealth();
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

    private void Update() {
        if (townHealthText != null) {
            townHealthText.GetComponent<Text>().text = "Previous Town Health: " + string.Format("{0:0}", townHealth) + "%";
        }
    }
}
