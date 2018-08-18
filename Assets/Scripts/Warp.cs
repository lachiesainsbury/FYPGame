using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    [SerializeField]
    private Transform warpTarget;

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        ScreenFader screenFader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        // Call FadeToBlack method and don't move on to the next line of code until method is finished
        yield return StartCoroutine(screenFader.FadeToBlack());

        // Move player and camera objects to the warp target
        collision.gameObject.transform.position = warpTarget.position;
        Camera.main.transform.position = warpTarget.position;

        // Call FadeToClear method and don't move on to the next line of code until method is finished
        yield return StartCoroutine(screenFader.FadeToClear());
    }
}
