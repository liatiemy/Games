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

	private void OnCollisionEnter2d(Collision2D c){
		//Destroi o objeto por colisão
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D c){
		print ("entrei no colider");
		//como o peixinho eh trigger nao precisa colocar c.gameobject.tag
		if (c.gameObject.tag == "SubInimigo") {
			Destroy(c.gameObject);
		}
	}




	// Update is called once per frame
	void Update () {
		//Movendo o tiro
		transform.Translate (Vector2.right * velocidade * Time.deltaTime);
	}
}
