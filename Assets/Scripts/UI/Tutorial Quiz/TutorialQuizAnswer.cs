using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialQuizAnswer : MonoBehaviour {

    [SerializeField]
    [TextArea]
    private string feedback;

    [SerializeField]
    private GameObject nextFrame;

    public void submitAnswer() {
        transform.parent.parent.GetComponent<UIWindow>().Navigate(nextFrame);

        nextFrame.GetComponentInChildren<Text>().text = feedback;
    }
}
