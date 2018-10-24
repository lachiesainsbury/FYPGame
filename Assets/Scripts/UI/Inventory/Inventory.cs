using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private const int numberOfInventorySlots = 6;
    private GameObject[] inventorySlots;

    [SerializeField]
    private GameObject inventorySlotPrefab, questInfo;

    [SerializeField]
    private Transform inventorySlotsGroup;

    // Use this for initialization
    void Start () {
        inventorySlots = new GameObject[numberOfInventorySlots];

        for (int i=0; i < numberOfInventorySlots; i++) {
            GameObject newInventorySlot = Instantiate(inventorySlotPrefab);
            newInventorySlot.transform.SetParent(inventorySlotsGroup, false);

            inventorySlots[i] = newInventorySlot;
        }

        this.gameObject.SetActive(false);
	}

    public void ToggleWindow() {
        if (questInfo.activeInHierarchy) {
            questInfo.SetActive(false);
        }

        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void AddItem(Food food) {
        foreach (GameObject slot in inventorySlots) {
            InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();

            if (!inventorySlot.HasItem()) {
                inventorySlot.AddItem(food);
                return;
            }
        }

        Debug.Log("Inventory is full.");
    }

    public GameObject[] GetInventorySlots() {
        return inventorySlots;
    }

    public bool IsFull() {
        foreach (GameObject slot in inventorySlots) {
            InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();

            if (!inventorySlot.HasItem()) {
                return false;
            }
        }

        return true;
    }
}
