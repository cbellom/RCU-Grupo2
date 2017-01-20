﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HackPuzzle : PuzzleUI {

	[Header("Hack puzzle settings")]
	public int numberOfTries;
	public int secondsToBegin;
	public float speed;
	[Header("Hack puzzle data")]
	public GameObject inputKeysPanel;
	public GameObject hackKeyPrefab;
	public List<KeyCode> listKeys = new List<KeyCode> ();

	private int currentTry = 0;
	private Vector2 panelAnchoredPosition;
	private List<HackKey> listHackKeys = new List<HackKey> ();


	void Start() {
		panelAnchoredPosition = inputKeysPanel.GetComponent<RectTransform> ().anchoredPosition;

		OnFrameUpdated += HandleFrameUpdated;
		OnResetPuzzle += HandlePuzzleReset;
		OnGameOverPuzzle += HandlePuzzleGameOver;
	}

	void HandlePuzzleReset(){
		ErasePuzzle ();
		CreatePuzzle ();
		StartCoroutine (BeginPuzzle ());
	}

	void HandlePuzzleGameOver(){
		Reset ();			
	}

	void ErasePuzzle(){
		listHackKeys.ForEach(key => Destroy(key));
	}

	void CreatePuzzle(){
		
	}

	IEnumerator BeginPuzzle(){
		yield return new WaitForSeconds (secondsToBegin);

		currentTry = 0;
		isActive = true;
	}

	void HandleFrameUpdated(){
		if (isActive) {
			panelAnchoredPosition.y -= Time.deltaTime * speed;
			inputKeysPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2(panelAnchoredPosition.x, panelAnchoredPosition.y);
		}
	}
}
