using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizBox : UIWindow {

    [SerializeField]
    private GameObject gameController, dialogueBox;

    // Zones
    [SerializeField]
    private GameObject farmZone, milkZone;

    private List<Question> questions;

    private Text questionText;
    private Button[] optionButtons;
    private Question currentQuestion;

    void Start() {
        questionText = this.gameObject.GetComponentInChildren<Text>();
        optionButtons = this.gameObject.GetComponentsInChildren<Button>();

        this.gameObject.SetActive(false);
    }

    public void UpdateQuizBox() {
        questions = gameController.GetComponent<GameController>().GetQuestionContainer().questions;

        currentQuestion = questions[Random.Range(0, questions.Count)];

        questionText.text = currentQuestion.value;

        for (int i=0; i < currentQuestion.options.Length; i++) {
            optionButtons[i].GetComponentInChildren<Text>().text = currentQuestion.options[i].value;
            optionButtons[i].gameObject.SetActive(true);
        }

        for (int i = currentQuestion.options.Length; i < optionButtons.Length; i++) {
            optionButtons[i].GetComponentInChildren<Text>().text = "";
            optionButtons[i].gameObject.SetActive(false);
        }
    }

    public void SubmitQuizAnswer(Button selected) {
        string selectedAnswer = selected.GetComponentInChildren<Text>().text;
        string feedback = "";

        foreach (Option option in currentQuestion.options) {
            if (option.value.Equals(selectedAnswer)) {
                feedback = option.response;

                if (option.correct.Equals("true")) {
                    AnswerStatus(true, feedback);
                    return;
                }
            }
        }

        AnswerStatus(false, feedback);
    }

    private void AnswerStatus(bool correct, string feedback) {
        ExitWindow();

        TownHealthBar townHealthBar = GameObject.FindGameObjectWithTag("TownHealthBar").GetComponent<TownHealthBar>();

        if (correct) {
            townHealthBar.QuizCorrect();

            // Check to determine which zone the player is in and act accordingly
            FarmTrigger farmTrigger = farmZone.GetComponent<FarmTrigger>();
            MilkTrigger milkTrigger = milkZone.GetComponent<MilkTrigger>();

            if (farmTrigger.IsPlayerWithinZone()) {
                farmTrigger.GrowCrops();
            } else if (milkTrigger.IsPlayerWithinZone()) {
                milkTrigger.MilkCow();
            }
        } else {
            townHealthBar.QuizIncorrect();
        }

        DisplayFeedback(feedback);
    }

    private void DisplayFeedback(string feedback) {
        dialogueBox.GetComponent<UIWindow>().OpenWindow();
        dialogueBox.GetComponent<DialogueBox>().UpdateDialogueBoxFeedback(feedback);
    }
}
