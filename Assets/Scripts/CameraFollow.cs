using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float movementSpeed = 0.5f;

    private Camera camera;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        camera.orthographicSize = (Screen.height / 100f);

        if (target) {
            transform.position = Vector3.Lerp(transform.position, target.position, movementSpeed) + new Vector3(0, 0, -10);
        }
	}
}
