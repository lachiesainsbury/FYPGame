using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour {

    [SerializeField]
    private GameObject shop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            shop.SetActive(false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        shop.SetActive(true);
    }
}
