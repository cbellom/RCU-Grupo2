﻿using UnityEngine;
using UnityEngine.UI;
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
        ResetPanelListPosition();
        StartCoroutine (BeginPuzzle ());
	}

	void HandlePuzzleGameOver(){
		Reset ();			
	}

	void ErasePuzzle(){
		listHackKeys.ForEach(key => Destroy(key));
	}

	void CreatePuzzle(){
        foreach (KeyCode key in listKeys) {
            GameObject obj = CreateKeyObject();
            SetUpHackKey(obj, key);
        }
	}

    GameObject CreateKeyObject() {
        GameObject obj = Instantiate(hackKeyPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        obj.transform.SetParent(inputKeysPanel.transform);

        return obj;        
    }

    void SetUpHackKey(GameObject obj, KeyCode key) {
        HackKey hackKey = obj.GetComponent<HackKey>();
        if (hackKey != null) {
            hackKey.SetUp( key );
            hackKey.TriggerExit += HandleHackKeyTriggerExit;
            hackKey.TriggerStay += HandleHackKeyTriggerStay;
            listHackKeys.Add(hackKey);
        }
    }

    private void HandleHackKeyTriggerStay(HackKey key) {
        Debug.Log("stay " + key.key.ToString());
    }

    private void HandleHackKeyTriggerExit(HackKey key) {
        Debug.Log("exit " + key.key.ToString());
        currentTry++;
        if (currentTry > numberOfTries)
        {
            isActive = false;
        }
    }

    IEnumerator BeginPuzzle(){
		yield return new WaitForSeconds (secondsToBegin);

		currentTry = 0;
		isActive = true;
	}

    private void ResetPanelListPosition() {
        panelAnchoredPosition.y += ( (hackKeyPrefab.GetComponent<RectTransform>().sizeDelta.y + inputKeysPanel.GetComponent<VerticalLayoutGroup>().spacing) * listKeys.Count);
        inputKeysPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(panelAnchoredPosition.x, panelAnchoredPosition.y);
    }

	void HandleFrameUpdated(){
		if (isActive) {
			panelAnchoredPosition.y -= Time.deltaTime * speed;
			inputKeysPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2(panelAnchoredPosition.x, panelAnchoredPosition.y);
		}
	}
}
