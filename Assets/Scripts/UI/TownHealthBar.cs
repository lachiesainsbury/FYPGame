using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownHealthBar : MonoBehaviour {

    private Slider slider;

    void Start() {
        slider = this.gameObject.GetComponent<Slider>();
        slider.maxValue = 100;
    }

    public void QuestCompleted() {
        slider.value += 13;
    }

    public void QuizCorrect() {
        slider.value += 4;
    }

    public void QuizIncorrect() {
        slider.value -= 4;
    }

    public float GetTownHealth() {
        return this.slider.value;
    }
}
