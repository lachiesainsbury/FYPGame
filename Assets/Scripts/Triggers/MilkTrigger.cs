using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkTrigger : MonoBehaviour {
    [SerializeField]
    private GameObject inventory, quizBox, gameController;

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
        string[] categories = { "Calcium" };

        // Display quiz box
        quizBox.GetComponent<UIWindow>().OpenWindow();
        quizBox.GetComponent<QuizBox>().UpdateQuizBox(categories);
    }

    public void MilkCow() {
        Food milk = gameController.GetComponent<GameController>().FindFoodByName("Milk");
        milk.itemType = ItemType.Food;

        inventory.GetComponent<Inventory>().OpenWindow();
        inventory.GetComponent<Inventory>().AddItem(milk);
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
