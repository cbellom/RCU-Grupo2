using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class FinishPuzzleUI : CanvasUI
{
    [SerializeField]
    private float secondsDuration;
    [SerializeField]
    private Text helpLabel;

    public Action OnClose
    {
        get;
        set;
    }


    void Start()
    {
        OnKeyPressed += HanldeOnKeyPressed;
    }

    public void ShowMessage(string message)
    {
        helpLabel.text = message;
        isTurnOn = true;

        StartCoroutine(Close());
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(secondsDuration);

        isTurnOn = false;
        if (OnClose != null) OnClose();
    }

    public void HideMessage()
    {
        helpLabel.text = "";
        isTurnOn = false;
    }
    

    private void HanldeOnKeyPressed()
    {
        if (!isTurnOn)
            ShowMessage("On Finish Game Message");
        else
            HideMessage();
    }
}
