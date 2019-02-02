using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : UIWindow {

    [SerializeField]
    private GameObject QuizBox;

    private Text[] dialogueText;
    private Button[] dialogueButtons;

    void Start() {
        dialogueText = this.gameObject.GetComponentsInChildren<Text>();
        dialogueButtons = this.gameObject.GetComponentsInChildren<Button>();

        this.gameObject.SetActive(false);
    }

    public void UpdateDialogueBox(NPC npc) {
        dialogueText[0].fontSize = 46;
        dialogueText[0].alignment = TextAnchor.UpperLeft;
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
        dialogueText[0].fontSize = 26;
        dialogueText[0].alignment = TextAnchor.MiddleLeft;
        dialogueText[0].text = feedback;
        dialogueText[1].text = "";

        UpdateDialogueButtons(false);
    }

    private void UpdateDialogueButtons(bool notStarted) {
        dialogueButtons[0].gameObject.SetActive(!notStarted);
        dialogueButtons[1].gameObject.SetActive(notStarted);
        dialogueButtons[2].gameObject.SetActive(notStarted);
    }

    // Shopkeeper dialogue
    public void UpdateDialogueBoxShopkeeper(Shopkeeper shopkeeper) {
        dialogueText[0].fontSize = 46;
        dialogueText[0].alignment = TextAnchor.UpperLeft;
        dialogueText[0].text = shopkeeper.GetName();
        dialogueText[1].text = shopkeeper.GetDialogue();

        UpdateDialogueButtons(true);
        dialogueButtons[2].onClick.RemoveAllListeners();
        dialogueButtons[2].onClick.AddListener(delegate {
            this.gameObject.GetComponent<UIWindow>().ExitWindow();

            string[] categories = new string[] { "Vitamin D" };

            QuizBox.GetComponent<UIWindow>().OpenWindow();
            QuizBox.GetComponent<QuizBox>().UpdateQuizBox(categories);
        });
    }
}
