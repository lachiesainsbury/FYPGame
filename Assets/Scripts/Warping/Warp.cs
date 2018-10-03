using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    [SerializeField]
    private Transform warpTarget;

    private ActionButton actionButton;
    private bool playerWithinZone, warping;

    private void Start() {
        actionButton = GameObject.FindGameObjectWithTag("ActionButton").GetComponent<ActionButton>();
    }

    private void Update() {
        if (playerWithinZone && !warping && actionButton.GetClicked()) {
            warping = true;

            // Get player object by tag and call WarpPlayer function
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            StartCoroutine(WarpPlayer(player));
        }
    }

    private IEnumerator WarpPlayer(Player player) {
        ScreenFader screenFader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        // Call FadeToBlack method and don't move on to the next line of code until method is finished
        yield return StartCoroutine(screenFader.FadeToBlack());

        // Move player and camera objects to the warp target
        player.gameObject.transform.position = warpTarget.position;
        Camera.main.transform.position = warpTarget.position;

        // Call FadeToClear method and don't move on to the next line of code until method is finished
        yield return StartCoroutine(screenFader.FadeToClear());
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        playerWithinZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        playerWithinZone = false;
        warping = false;
    }
}
