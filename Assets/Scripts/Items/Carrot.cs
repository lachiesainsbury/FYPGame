using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carrot : Item {
    public Carrot() {
        icon = Resources.Load<Sprite>(path + "carrot");
    }
}
