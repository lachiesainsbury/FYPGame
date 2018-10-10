using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmTrigger : MonoBehaviour {
    [SerializeField]
    private GameObject inventory;
    [SerializeField]
    private Tilemap tileDecoration1, object1, object2, foreground;
    [SerializeField]
    private Sprite farmland;

    private ActionButton actionButton;
    private GameObject player;
    
    private bool playerWithinZone;

	// Use this for initialization
	void Start () {
        actionButton = GameObject.FindGameObjectWithTag("ActionButton").GetComponent<ActionButton>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (playerWithinZone && actionButton.GetClicked()) {
            // Calculate the players direction and get the coordinates of the cell one space in front of them
            Vector3Int playerDirection = player.GetComponent<Player>().GetPlayerDirection();
            Vector3Int targetCell = tileDecoration1.WorldToCell(player.transform.position + playerDirection);

            if (IsValidFarmland(-8, targetCell, object1)) {
                Food food = GetSeedsFromInventory();

                if (food != null) {
                    PlantSeeds(food, targetCell, object1);
                } else {
                    Debug.Log("No seeds in inventory.");
                }

            } else if (IsValidFarmland(-9, targetCell, object2)) {
                Food food = GetSeedsFromInventory();

                if (food != null) {
                    PlantSeeds(food, targetCell, object2);
                } else {
                    Debug.Log("No seeds in inventory.");
                }
            }

            // If any fully grown crops in zone THEN harvest

        }
	}

    private bool IsValidFarmland(int y, Vector3Int targetCell, Tilemap tilemap) {
        // Check if the cell is farm land
        if (farmland.Equals(tileDecoration1.GetSprite(targetCell))) {
            // Check if the cell is on a valid growing row
            if (targetCell.y == y) {
                // Check if the cell does not currently contain a crop
                if (tilemap.GetTile(targetCell) == null) {
                    return true;
                }
            }
        }

        return false;
    }

    private Food GetSeedsFromInventory() {
        foreach (GameObject slot in inventory.GetComponent<Inventory>().GetInventorySlots()) {
            InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();

            if (inventorySlot.HasItem()) {
                Food food = inventorySlot.GetItem();

                if (food.foodType == FoodType.Seeds) {
                    inventorySlot.ClearSlot();

                    return food;
                }
            }
        }

        return null;
    }

    private void PlantSeeds(Food food, Vector3Int targetCell, Tilemap tilemap) {
        Tile tile = Resources.Load<Tile>("Foods/Plants/" + food.growthStageOneTile);

        tilemap.SetTile(targetCell, tile);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        playerWithinZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        playerWithinZone = false;
    }
}
