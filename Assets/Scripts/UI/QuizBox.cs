using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizBox : UIWindow {

    [SerializeField]
    private GameObject gameController;

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

    public Question GetCurrentQuestion() {
        return this.currentQuestion;
    }
}
