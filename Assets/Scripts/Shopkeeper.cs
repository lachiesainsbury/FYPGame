using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour {

    [SerializeField]
    private string name, dialogue, category;

    public string GetName() {
        return this.name;
    }

    public string GetDialogue() {
        return this.dialogue;
    }

    public string GetCategory() {
        return this.category;
    }
}
