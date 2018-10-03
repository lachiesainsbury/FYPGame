using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item {

    // Item paths within the Resources folder
    protected const string path = "Items/";

    protected Sprite icon;

    public Item() {
        icon = null;
    }

    public Sprite GetIcon() {
        return icon;
    }
}
