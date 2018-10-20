using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

    [SerializeField]
    private GameObject gameController, questBox;

    private Quest quest;

    private Dialogue dialogue;

    private void Start() {
        quest = gameController.GetComponent<GameController>().FindQuestByNPC(this.gameObject.name);
        quest.questStatus = QuestStatus.NotStarted;

        dialogue = gameController.GetComponent<GameController>().FindDialogueByNPC(this.gameObject.name);
    }

    public void StartQuest(GameObject player) {
        if (quest != null) {
            quest.questStatus = QuestStatus.InProgress;

            player.GetComponent<Player>().AddNewQuest(quest);
            questBox.GetComponent<Text>().text = quest.name;
        } else {
            Debug.Log("NPC does not have a quest assigned.");
        }
    }

    public void FinishQuest(GameObject player) {

    }
}
