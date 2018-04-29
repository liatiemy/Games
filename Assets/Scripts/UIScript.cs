using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	// Recebe elemento text UI
	public Text txtPontos;
	public Text txtVida;


	void Update () {
		// Atualiza o placar
		txtPontos.text = PrincipalScript.pontos.ToString();
		txtVida.text = PrincipalScript.vidas.ToString();
		//txtResultado.text = PrincipalScript.resultado.ToString ();
	}
}
