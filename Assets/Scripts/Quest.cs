using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {

    private string name;
    private GameObject NPC;
    private Food questItem;

    public Quest(string name, GameObject NPC, Food questItem) {
        this.name = name;
        this.NPC = NPC;
        this.questItem = questItem;
    }

    public string GetName() {
        return name;
    }
}
