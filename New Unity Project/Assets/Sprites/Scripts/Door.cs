using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public override void OnFocus()
    {
        print("VAATAN");
    }

    public override void OnInteract()
    {
        print("KATSUSIN");
    }

    public override void OnLoseFocus()
    {
        print("EI VAATA");
    }
}
