using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

    [SerializeField]
    private GameObject gameController, questBox;

    private Quest quest;

    public void AssignQuest(GameObject player) {
        quest = new Quest("Carrots", this.gameObject, gameController.GetComponent<GameController>().FindFoodByName("Carrot"));

        player.GetComponent<Player>().AddNewQuest(quest);

        questBox.GetComponent<Text>().text = quest.GetName();
    }
}
