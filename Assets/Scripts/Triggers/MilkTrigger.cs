using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkTrigger : MonoBehaviour {
    [SerializeField]
    private GameObject inventory, quizBox;

    private ActionButton actionButton;

    private bool playerWithinZone;

	// Use this for initialization
	void Start () {
        actionButton = GameObject.FindGameObjectWithTag("ActionButton").GetComponent<ActionButton>();
    }
	
	// Update is called once per frame
	void Update () {
        if (playerWithinZone && actionButton.GetClicked()) {
            ShowQuiz();
        }
	}

    public void ShowQuiz() {
        // Display quiz box
        quizBox.GetComponent<UIWindow>().OpenWindow();
        quizBox.GetComponent<QuizBox>().UpdateQuizBox();
    }

    public void MilkCow() {
        Debug.Log("Milked");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        playerWithinZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        playerWithinZone = false;
    }

    public bool IsPlayerWithinZone() {
        return playerWithinZone;
    }
}
