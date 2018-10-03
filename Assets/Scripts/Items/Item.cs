using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item {

    protected const string path = "Items/";

    protected Image icon;

    public Image GetIcon() {
        return icon;
    }
}
