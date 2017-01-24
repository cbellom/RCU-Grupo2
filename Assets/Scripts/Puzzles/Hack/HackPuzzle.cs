using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class HackPuzzle : PuzzleUI {
    	
    [Header("Hack puzzle data")]
    [Header("Instantiate game")]
    public GameObject inputKeysPanel;
	public GameObject hackKeyPrefab;
	public GameObject particlesPrefab;

    [Header("Finish game")]
    public string finishMessageOnSuccess;
    public string finishMessageOnFaild;
    public HackKey defaultKeyToFinishGame;

    private int currentTry = 0;
    private int numberOfTries;
    private int secondsToBegin;
    private float speed;
    private HackDataGame dataGame;
    private Vector2 panelAnchoredPosition;
	private List<GameObject> listHackKeys = new List<GameObject> ();
    private FinishPuzzleUI finishMessageUI;

    void Start() {
		finishMessageUI = GameObject.FindObjectOfType<FinishPuzzleUI>();
		panelAnchoredPosition = inputKeysPanel.GetComponent<RectTransform> ().anchoredPosition;
		SetHandles ();
	}

    private void HandlePuzzleReset(DataPuzzle data){
		this.dataGame = data as HackDataGame;
		SetUpPuzzle ();
        StartCoroutine (BeginPuzzle ());
	}

	private void SetUpPuzzle(){
		ErasePuzzle ();
		CreatePuzzle ();
		ResetPanelListPosition();
	}

	private void SetHandles(){
		defaultKeyToFinishGame.TriggerEnter = HandleHackKeyTriggerEnter;
		OnFrameUpdated = HandleFrameUpdated;
		OnResetPuzzle += HandlePuzzleReset;
		OnGameOverPuzzle += HandlePuzzleGameOver;
	}

    private void HandlePuzzleGameOver()
    {
        SceneCamerasController camerasController = GameObject.FindObjectOfType<SceneCamerasController>();
        camerasController.ActiveCameraByName("Main Camera");
		ErasePuzzle ();
		ResetPanelListPositionToDefault ();
        FinishOnFaild();
    }

	private void ErasePuzzle(){
		listHackKeys.ForEach(key => Destroy(key));
	}

	void CreatePuzzle(){
        foreach (KeyCode key in dataGame.itemList) {
            GameObject obj = CreateKeyObject();
            SetUpHackKey(obj, key);
        }
	}

   private  GameObject CreateKeyObject() {
        GameObject obj = Instantiate(hackKeyPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        obj.transform.SetParent(inputKeysPanel.transform);

        return obj;        
    }

    private void SetUpHackKey(GameObject obj, KeyCode key) {
        HackKey hackKey = obj.GetComponent<HackKey>();
        if (hackKey != null) {
			hackKey.SetUp( key );
            hackKey.TriggerExit += HandleHackKeyTriggerExit;
			listHackKeys.Add(hackKey.gameObject);
        }
    }

	private void HandleHackKeyTriggerEnter(HackKey key) {
		isActive = false;
        ShowFinishMessage(finishMessageOnSuccess, GameFinisedOnSucced); 
	}
    
    private void HandleHackKeyTriggerExit(HackKey key) {
        currentTry++;
        if (currentTry > numberOfTries)
        {
			isActive = false;
			OnGameOverPuzzle += HandlePuzzleGameOver;
            ShowFinishMessage(finishMessageOnFaild, OnGameOverPuzzle);
        }
    }

    private IEnumerator BeginPuzzle(){
		yield return new WaitForSeconds (secondsToBegin);

		currentTry = 0;
        numberOfTries = dataGame.numberOfTries;
        secondsToBegin = dataGame.secondsToBegin;
        speed = dataGame.speed;
        isActive = true;
	}

    private void ResetPanelListPosition() {
        panelAnchoredPosition.y += ( (hackKeyPrefab.GetComponent<RectTransform>().sizeDelta.y + inputKeysPanel.GetComponent<VerticalLayoutGroup>().spacing ) * dataGame.itemList.Count);
        inputKeysPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(panelAnchoredPosition.x, panelAnchoredPosition.y);
    }

	private void ResetPanelListPositionToDefault() {
		inputKeysPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(panelAnchoredPosition.x, 0);
	}

	private void HandleFrameUpdated(){
		if (isActive) {
			panelAnchoredPosition.y -= Time.deltaTime * speed;
			inputKeysPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2(panelAnchoredPosition.x, panelAnchoredPosition.y);
		}
	}

	private void GameFinisedOnSucced(){
		SceneCamerasController camerasController = GameObject.FindObjectOfType<SceneCamerasController> ();
		camerasController.ActiveCameraByName ("Main Camera");
		ErasePuzzle ();
		ResetPanelListPositionToDefault ();
		Finish ();
	}
    
    private void ShowFinishMessage(string message, Action OnClosedFinishMesage)
    {
        finishMessageUI.OnClose = OnClosedFinishMesage;
        finishMessageUI.ShowMessage(message);
    }
}
