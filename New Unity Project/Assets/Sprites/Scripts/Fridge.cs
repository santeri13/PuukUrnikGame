using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Interactable
{
    public TMPro.TextMeshProUGUI interactionText;
    public MainGameController gameController;

    public override void OnFocus()
    {
        interactionText.text = "E et süüa";
    }

    public override void OnInteract()
    {
        gameController.Eat();
    }

    public override void OnLoseFocus()
    {
        interactionText.text = "";
    }


}
