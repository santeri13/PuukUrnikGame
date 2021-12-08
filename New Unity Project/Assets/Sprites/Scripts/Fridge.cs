using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Interactable
{
    public TMPro.TextMeshProUGUI interactionText;

    public override void OnFocus()
    {
        interactionText.text = "E et s��a";
    }

    public override void OnInteract()
    {

    }

    public override void OnLoseFocus()
    {
        interactionText.text = "";
    }


}
