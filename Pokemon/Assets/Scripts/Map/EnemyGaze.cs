﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGaze : MonoBehaviour {

	private GameManager gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.GetComponent<PlayerMovement> ()) {
			gm.EnterBattle();
		}
	}
}
