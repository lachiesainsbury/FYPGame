using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        int randomNo = Random.Range(0, 300);

        if (randomNo == 0) {
            animator.SetBool("isEating", true);
        } else {
            animator.SetBool("isEating", false);
        }
	}
}
