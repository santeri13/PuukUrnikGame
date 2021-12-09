using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactable
{
    public TMPro.TextMeshProUGUI interactionText;
    public MainGameController gameController;
    public override void OnFocus()
    {
        interactionText.text = "E et Magada";
    }

    public override void OnInteract(int none)
    {
        gameController.SleepOnBed();
    }

    public override void OnLoseFocus()
    {
        interactionText.text = "";
    }

}
