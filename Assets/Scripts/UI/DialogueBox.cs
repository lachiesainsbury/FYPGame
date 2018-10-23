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

        if (npc.GetQuest().questStatus == QuestStatus.NotStarted) {
            UpdateDialogueButtons(dialogueButtons, true);
        } else {
            UpdateDialogueButtons(dialogueButtons, false);
        }
    }

    private void UpdateDialogueButtons(Button[] dialogueButtons, bool notStarted) {
        dialogueButtons[0].gameObject.SetActive(!notStarted);
        dialogueButtons[1].gameObject.SetActive(notStarted);
        dialogueButtons[2].gameObject.SetActive(notStarted);
    }
}
