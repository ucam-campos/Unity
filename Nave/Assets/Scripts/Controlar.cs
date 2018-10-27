﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limite {
	public float xMax; 
	public float xMin; 
	public float yMax; 
	public float yMin; 
}
	
public class Controlar : MonoBehaviour {
	private int velocidade = 6;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Mover ();
	}

	void Mover(){
		float movHor = Input.GetAxis("Horizontal");
		float movVer = Input.GetAxis("Vertical");
		Vector3 movimento = new Vector3(movHor, 0, movVer);
		rb.velocity = (movimento*velocidade);
		float limitarX = Mathf.Clamp (rb.position.x, -6.0f, 6.0f);
		float limitarZ = Mathf.Clamp (rb.position.z, -1.0f, 17.0f);
		rb.position = new Vector3 (limitarX, 0, limitarZ);
	}
}
