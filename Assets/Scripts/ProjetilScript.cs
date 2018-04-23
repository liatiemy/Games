using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour {

	public float velocidade;

	// Use this for initialization
	void Start () {
		
		//Destroi caso o objeto nao acerte nada
		Destroy (gameObject, 3.0f);
		
	}
		
	// Update is called once per frame
	void Update () {
		//Movendo o tiro
		transform.Translate (Vector2.right * velocidade * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D c) {
		
		if (c.gameObject.tag == "SubInimigo") {

		

			Destroy (c.gameObject);
			Destroy (gameObject);
			//PontuacaoScript.score++;

		}

	}

}
