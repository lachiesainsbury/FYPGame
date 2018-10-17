using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmTile {

    private Vector3Int coordinates;
    private Food crop;
    private Tilemap tilemap;
    private int growthStage;

    public FarmTile(Vector3Int coordinates) {
        crop = null;
        this.coordinates = coordinates;
    }

    public void PlantCrop(Food crop, Tile tile, Tilemap tilemap) {
        this.crop = crop;
        this.tilemap = tilemap;

        tilemap.SetTile(coordinates, tile);
        growthStage = 1;
    }

    public void GrowCrop() {
        if (growthStage < 4) {
            Tile tile = GetNextGrowthTile();

            if (tile != null) {
                tilemap.SetTile(coordinates, tile);
                growthStage++;
            }
        } else {
            Debug.Log("Crop is fully grown");
        }
    }

    public void HarvestCrop() {

    }

    private Tile GetNextGrowthTile() {
        switch (growthStage) {
            case 1:
                return Resources.Load<Tile>("Foods/Plants/" + crop.growthStageTwoTiles[0]);

            case 2:
                return Resources.Load<Tile>("Foods/Plants/" + crop.growthStageThreeTiles[0]);

            case 3:
                return Resources.Load<Tile>("Foods/Plants/" + crop.growthStageFourTiles[0]);
        }

        return null;
    }

    public Vector3Int GetCoordinates() {
        return coordinates;
    }

    public bool HasCrop() {
        if (crop == null) {
            return false;
        } else {
            return true;
        }
    }
}