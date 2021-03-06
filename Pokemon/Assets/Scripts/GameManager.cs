﻿using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class GameManager : MonoBehaviour {

	/*
		Testing if I can push stuff from git to my computer by seeing if this notes shows up - Nate
	*/
	public GameObject playerCamera;
	public GameObject battleCamera;
	public GameObject libraryCamera1;

	public GameObject player;
	public GameObject northOfPlayer;
	public GameObject eastOfPlayer;
	public GameObject southOfPlayer;
	public GameObject westOfPlayer;

	private Vector3 offsetN;
	private Vector3 offsetE;
	private Vector3 offsetS;
	private Vector3 offsetW;

	private Vector3 offsetCamera1;


	// Use this for initialization
	void Start () {
		playerCamera.SetActive (true);
		battleCamera.SetActive (false);
		libraryCamera1.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		//making invisible sprites that detect collisions follow main player
		offsetN = northOfPlayer.transform.position - player.transform.position;
		offsetE = eastOfPlayer.transform.position - player.transform.position;
		offsetS = southOfPlayer.transform.position - player.transform.position;
		offsetW = westOfPlayer.transform.position - player.transform.position;
		//Setting the offset of Camera1 to the correct postition
		offsetCamera1 = playerCamera.transform.position - player.transform.position;
	}

	void LateUpdate(){
		//Making invisible sprites that detect collisions follow main player
		northOfPlayer.transform.position = player.transform.position + offsetN;
		eastOfPlayer.transform.position = player.transform.position + offsetE;
		southOfPlayer.transform.position = player.transform.position + offsetS;
		westOfPlayer.transform.position = player.transform.position + offsetW;
		//Making the camera1 follow player.
		playerCamera.transform.position = player.transform.position + offsetCamera1;
	}
		
	public void EnterBattle(){
		playerCamera.active = false;
		battleCamera.active = true;

		player.GetComponent<PlayerMovement>().isAllowedToMove = false;
	}

	public void SolidObjectHit(Direction dir){
		switch(dir){
		case Direction.North:
			player.GetComponent<PlayerMovement> ().canMoveNorth = false;
			print ("hit North");
			break;
		case Direction.East:
			player.GetComponent<PlayerMovement> ().canMoveEast = false;
			print ("hit East");
			break;
		case Direction.South:
			player.GetComponent<PlayerMovement> ().canMoveSouth = false;
			print ("hit South");
			break;
		case Direction.West:
			player.GetComponent<PlayerMovement> ().canMoveWest = false;
			print ("hit West");
			break;
		}
	}
	public void SolidObjectLeft(){
		player.GetComponent<PlayerMovement> ().canMoveNorth = true;
		player.GetComponent<PlayerMovement> ().canMoveWest = true;
		player.GetComponent<PlayerMovement> ().canMoveSouth = true;
		player.GetComponent<PlayerMovement> ().canMoveEast = true;
		print ("Left");
	}
}
