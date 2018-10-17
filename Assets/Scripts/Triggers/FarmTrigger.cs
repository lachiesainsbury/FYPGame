using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmTrigger : MonoBehaviour {
    [SerializeField]
    private GameObject inventory;
    [SerializeField]
    private Tilemap object1, foreground;

    private ActionButton actionButton;
    private GameObject player;
    
    private bool playerWithinZone;

    private FarmTile[] farmTiles;

	// Use this for initialization
	void Start () {
        actionButton = GameObject.FindGameObjectWithTag("ActionButton").GetComponent<ActionButton>();
        player = GameObject.FindGameObjectWithTag("Player");

        initializeFarmTiles();
    }

    private void initializeFarmTiles() {
        farmTiles = new FarmTile[5];

        int xCoordinate = 14;

        for (int i=0; i < farmTiles.Length; i++) {
            FarmTile newTile = new FarmTile(new Vector3Int(xCoordinate, -8, 0));
            farmTiles[i] = newTile;

            xCoordinate++;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (playerWithinZone && actionButton.GetClicked()) {
            /* PLANT CROPS */
            for (int i=0; i < farmTiles.Length; i++) {
                if (!farmTiles[i].HasCrop()) {
                    // Plant crop if player has seeds
                    Food food = GetSeedsFromInventory();

                    if (food != null) {
                        PlantSeeds(farmTiles[i], food, object1);
                    } else {
                        Debug.Log("No seeds in inventory.");
                    }

                    return;
                }
            }
            /* HARVEST CROPS */
            for (int i=0; i < farmTiles.Length; i++) {
                if (farmTiles[i].HasCrop()) {
                    farmTiles[i].HarvestCrop();
                }
            }
        }
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

    private void PlantSeeds(FarmTile farmTile, Food food, Tilemap tilemap) {
        Tile tile = Resources.Load<Tile>("Foods/Plants/" + food.growthStageOneTile);

        farmTile.PlantCrop(food, tile, object1);
    }

    public void GrowCrops() {
        for (int i=0; i < farmTiles.Length; i++) {
            if (farmTiles[i].HasCrop()) {
                farmTiles[i].GrowCrop();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        playerWithinZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        playerWithinZone = false;
    }
}
