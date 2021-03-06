﻿using UnityEngine;
using System;
using System.Collections;

public class PuzzleUI : CanvasUI {
    private DataPuzzle data;
    public AudioClip sndRight;
    public AudioClip sndWrong;

    public Action<DataPuzzle> OnResetPuzzle
	{
		get;
		set;
	}

	public Action OnGameOverPuzzle
	{
		get;
		set;
	}

    public Action OnCompletePuzzle
    {
        get;
        set;
    }


    protected bool isActive = false;

	public void Active(DataPuzzle data)
    {
        this.data = data;
		isTurnOn = true;
		if(OnResetPuzzle != null)
			OnResetPuzzle(data);

        RunAnimationsInPuzzle();

    }

	protected void Finish(){
		isTurnOn = false;
        OnCompletePuzzle();
		UnLockPlayerMove ();
        RunAnimationsOutPuzzle();
        GameObject.Find("Sound").GetComponent<AudioSource>().PlayOneShot(sndRight);
    }

    protected void FinishOnFaild()
    {
        isTurnOn = false;
        UnLockPlayerMove();
        RunAnimationsOutPuzzle();
        GameObject.Find("Sound").GetComponent<AudioSource>().PlayOneShot(sndWrong);
    }

    protected void UnLockPlayerMove(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<CharacterMoveController> ().enabled = true;
	}

	private void RunAnimationsInPuzzle()  {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Animator>().SetBool("isInPuzzle", true);
        GameObject playerEye = GameObject.FindGameObjectWithTag("PlayerEye");
        playerEye.GetComponent<Animator>().SetBool("isLoading", true);
    }

    private void RunAnimationsOutPuzzle()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Animator>().SetBool("isInPuzzle", false);
        GameObject playerEye = GameObject.FindGameObjectWithTag("PlayerEye");
        playerEye.GetComponent<Animator>().SetBool("isLoading", false);
    }
}
