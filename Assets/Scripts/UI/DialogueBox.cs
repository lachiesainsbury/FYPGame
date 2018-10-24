using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : UIWindow {

    private Text[] dialogueText;
    private Button[] dialogueButtons;

    void Start() {
        dialogueText = this.gameObject.GetComponentsInChildren<Text>();
        dialogueButtons = this.gameObject.GetComponentsInChildren<Button>();

        this.gameObject.SetActive(false);
    }

    public void UpdateDialogueBox(NPC npc) {
        dialogueText[0].text = npc.GetNPCName();
        dialogueText[1].text = npc.GetDialogueLine();

        if (npc.GetQuest().questStatus == QuestStatus.NotStarted && !GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().HasQuest()) {
            UpdateDialogueButtons(true);
            dialogueButtons[2].onClick.RemoveAllListeners();
            dialogueButtons[2].onClick.AddListener(delegate {
                npc.StartQuest(GameObject.FindGameObjectWithTag("Player"));
                this.gameObject.GetComponent<UIWindow>().ExitWindow();
            });
        } else {
            UpdateDialogueButtons(false);
        }
    }

    public void UpdateDialogueBoxFeedback(string feedback) {
        dialogueText[0].text = "";
        dialogueText[1].text = feedback;

        UpdateDialogueButtons(false);
    }

    private void UpdateDialogueButtons(bool notStarted) {
        dialogueButtons[0].gameObject.SetActive(!notStarted);
        dialogueButtons[1].gameObject.SetActive(notStarted);
        dialogueButtons[2].gameObject.SetActive(notStarted);
    }
}
