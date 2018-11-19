﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destruir : MonoBehaviour {
	public int vida;
	public Text pontuacao;
	public GameObject explosaoAsteroide;
	public GameObject explosaoPlayer;
	private Jogo jogo;
	private static int pontos = 0;

	void Start(){
		jogo = GameObject.FindGameObjectWithTag ("GameController")
						 .GetComponent<Jogo> ();
		pontuacao = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Text>();
	}

	void OnTriggerEnter(Collider outro){
		if(!outro.CompareTag("ColliderLimite")){
			vida--;
			
			if(gameObject.CompareTag("Boss")){
				Instantiate (explosaoAsteroide, transform.position, transform.rotation);
			}

			if(vida == 0){
				Destroy (this.gameObject);
				Instantiate (explosaoAsteroide, transform.position, transform.rotation);
				pontos++;
				pontuacao.text = "Pontos: "+pontos;
			}
		
			if (outro.CompareTag ("Player")) {
				jogo.FinalizarJogo ();
				Instantiate (explosaoPlayer, outro.transform.position, outro.transform.rotation);
			}

			Destroy (outro.gameObject);	
		}
	}
}
