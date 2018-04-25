using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject player;

	Vector3 velocity = Vector3.zero;

	public float smoothTime = .15f;

	public bool YMaxEnabled = false;
	public float YMaxValue = 0;
	public bool YMinEnabled = false;
	public float YMinValue = 0;
	public bool XMaxEnabled = false;
	public float XMaxValue = 0;
	public bool XMinEnabled = false;
	public float XMinValue = 0;


	// Use this for initialization
	void Start () {
//		player = GameObject.FindGameObjectWithTag("Player");
//		transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
//		velocity = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		transform.position = player.transform.position + velocity;

		Vector3 targetPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);


		if (YMinEnabled && YMaxEnabled)
			targetPos.y = Mathf.Clamp (player.transform.position.y, YMinValue, YMaxValue);
		else if (YMinEnabled)
			targetPos.y = Mathf.Clamp (player.transform.position.y, YMinValue, player.transform.position.y);
		else if (YMaxEnabled)
			targetPos.y = Mathf.Clamp (player.transform.position.y, player.transform.position.y, YMaxValue);


		if (XMinEnabled && XMaxEnabled)
			targetPos.x = Mathf.Clamp (player.transform.position.x, XMinValue, XMaxValue);
		else if (YMinEnabled)
			targetPos.x = Mathf.Clamp (player.transform.position.x, XMinValue, player.transform.position.x);
		else if (YMaxEnabled)
			targetPos.x = Mathf.Clamp (player.transform.position.x, player.transform.position.x, XMaxValue);


//		targetPos.z = player.transform.position.z;
//
//		transform.position = Vector3.SmoothDamp (player.transform.position, targetPos, ref velocity, smoothTime);

	}
}
