using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using DaydreamElements.Teleport;

public class Teleporter : MonoBehaviour {

	public GameObject player;
	public LinearTeleportTransition teleportTransition;
	public Vector3 origin;
	public float speed = 2f;
	public float impulse = 0.25f;
	public float slowDown = 1.155f;
	public float distanceBeforeReset = 200f;
	Vector2 velocity = new Vector2(0f,0f);

	// Use this for initialization
	void Start () {
		player.transform.position = origin;
	}
	
	// Update is called once per frame
	void Update () {
		//skip this update and resets if we are moving from tp script
		if(teleportTransition.IsTransitioning) return;
		if(Input.GetMouseButtonDown(0) && velocity.magnitude < speed) {
			velocity += Vector2.up*impulse;
		} else {
			velocity /= slowDown;
		}

		Vector3 go = transform.TransformDirection(velocity.x, 0f, velocity.y);
		player.transform.Translate(go.x, 0f, go.z, Space.Self);
		if(transform.position.magnitude > distanceBeforeReset) {
			player.transform.position = origin;
			velocity = Vector2.zero;
		}
	}
}
