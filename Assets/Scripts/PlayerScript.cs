using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	public float velocidade;
	public float impulso;
	Animator animator;
	public GameObject player;
	public Camera cam;
	public int vida;
	public GameObject imagemGameOver;
	public GameObject imagemWin;
	//Transform eh o unico  componente do Sensor (GameObject)
	public Transform chaoVerificador;
	bool estaoNoChao;


	SpriteRenderer spriteRender;
	Rigidbody2D rb;
	Vector3 posicaoInicialCamera;
	public float danoTempo = 1f;

	float intervalo = 0.9f;
	// Use this for initialization
	void Start () {
		//Interface para os componentes
		spriteRender = player.GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D> ();
		animator = player.GetComponent<Animator> ();	
		posicaoInicialCamera = cam.transform.position;
	}

	// Update is called once per frame
	void Update () {

		//Mover
		float mover_x = Input.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;
		transform.Translate (mover_x, 0.0f, 0.0f);

		//Verificar colisao com o chao
		estaoNoChao = Physics2D.Linecast(transform.position, 
			chaoVerificador.position, 
			1 << LayerMask.NameToLayer("Piso"));
		//print (estaoNoChao);

		//Pular
		if (Input.GetButtonDown ("Jump") && estaoNoChao == true) {
			pular();
//		 
		}

		//Orientacao
		if (Input.GetAxisRaw("Horizontal") > 0){
			player.transform.eulerAngles = new Vector2 (0.0f, 0.0f);
//			spriteRender.flipX = false;
		} else if (Input.GetAxisRaw("Horizontal") < 0){
			player.transform.eulerAngles = new Vector2 (0.0f, 180.0f);
//			spriteRender.flipX = true;
		}

//		//Reproduz animacao
		animator.SetFloat("pMover", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
		animator.SetBool("pPular", estaoNoChao);
		animator.SetBool ("pFire", Input.GetButton("Fire1"));

		//Camera
		cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z);
	}


	void OnCollisionEnter2D(Collision2D c){
		//Subtrai vida quando for atingido pelo projetil
		if (c.gameObject.tag == "SubInimigo") {
			PrincipalScript.vidas--;
			if (PrincipalScript.vidas <= 0) {
				StartCoroutine (GameOver ());	
			} else {
				StartCoroutine (perdeVida ());
			}
				Destroy (c.gameObject);


		}

		//Se a vaqueira cai no abismo
		if (c.gameObject.tag == "abismo" /*&& transform.position.y <= c.gameObject.transform.position.y*/) {
			print ("cai no abismo");
			PrincipalScript.vidas--;
			if (PrincipalScript.vidas <= 0) {
				StartCoroutine (GameOver());				
			} else {
				SceneManager.LoadScene ("Game1");	
			}
		}

		//QUando a vaqueira ganha o jogo
		if (c.gameObject.tag == "Finish") {
			print ("entrei no finish");
				//PrincipalScript.resultado = "YOU WIN";
			StartCoroutine(Win());	
		}
	} 

	IEnumerator perdeVida(){
		print ("Deve piscar");
//		Physics2D.IgnoreLayerCollision(9, 10,true);
//		for (float i = 0; i < danoTempo; i += 0.2f){
			spriteRender.enabled = false;
			yield return new WaitForSeconds(0.1f);
			spriteRender.enabled = true;
			yield return new WaitForSeconds(0.2f);
//		}
//		Physics2D.IgnoreLayerCollision(9, 10, false);
	}



	void pular(){
			rb.velocity = new Vector2 (0.0f, impulso);
		}



	IEnumerator perdeSangue(){


		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (intervalo);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (intervalo);
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (intervalo);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (intervalo); 


	}

	IEnumerator GameOver(){		
		imagemGameOver.SetActive(true);
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("Start", LoadSceneMode.Single);


	}

	IEnumerator Win(){
		imagemWin.SetActive (true);
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Start", LoadSceneMode.Single);

	}


	

}