using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chair : Interactable
{
    public TMPro.TextMeshProUGUI interactionText;
    public MainGameController gameController;

    public override void OnFocus()
    {
        interactionText.text = "E et Istuda";
    }

    public override void OnInteract()
    {
        gameController.Sit();
    }
    

    public override void OnLoseFocus()
    {
        interactionText.text = "";
    }
}
