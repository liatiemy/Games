using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubInimigoScript : MonoBehaviour {

    public GameObject alvo;
	public float velocidade;
	Animator animator;
//	public GameObject atingido;
	bool foiAtingido;

	void Start () {
        // Atribui o alvo a ser perseguido
		alvo = GameObject.FindGameObjectWithTag("Player"); 
		animator = GetComponent<Animator> ();	        
	}
		
	void Update () {
		foiAtingido = false;
        // Persegue o alvo
        transform.position = Vector2.Lerp(
            transform.position, alvo.transform.position, 
            velocidade * Time.deltaTime
            );

		animator.SetBool("pAtingido", foiAtingido);
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "projetil") {
			PrincipalScript.pontos++;
			foiAtingido = true;
			print (foiAtingido);
//			Invoke("killZombie", 5);
			Destroy (c.gameObject);
			Destroy (gameObject);
			}
		}
	void killZombie()
	{
		Destroy (gameObject);
		print ("entrei no killZombie");

	}
}

	/*
	void OnTriggerEnter2D(Collider2D c){
		
		//como o peixinho eh trigger nao precisa colocar c.gameobject.tag
		if (c.gameObject.tag == "projetil") {
			print ("passei aqui");
			Destroy (gameObject);
			Destroy(c.gameObject);

		}
	}*/


		

