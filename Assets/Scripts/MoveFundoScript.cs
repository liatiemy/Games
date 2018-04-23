using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFundoScript : MonoBehaviour {

	public float limiteX;
	public float velocidade;


	// Update is called once per frame
	void Update () {
	
		transform.Translate (Vector2.left * velocidade * Time.deltaTime);

		if(transform.position.x<=limiteX){
			transform.position = new Vector2 (0.0f,limiteX * -1);
		}
	}
}
