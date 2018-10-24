using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfo : MonoBehaviour {

    [SerializeField]
    private GameObject inventory, townHealthText;

    public void ToggleWindow() {
        if (inventory.activeInHierarchy) {
            inventory.SetActive(false);
        }

        gameObject.SetActive(!gameObject.activeSelf);
    }

    void Update() {
        if (this.gameObject.activeSelf) {
            float townHealthValue = GameObject.FindGameObjectWithTag("TownHealthBar").GetComponent<TownHealthBar>().GetTownHealth();

            townHealthText.GetComponent<Text>().text = "Town Health: " + string.Format("{0:0}", townHealthValue) + "%";
        }
    }
}
