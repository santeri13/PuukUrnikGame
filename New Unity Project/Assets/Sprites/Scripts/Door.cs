using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable

{
    public AudioClipGroop DoorOpenAudio;
    public AudioClipGroop DoorCloseAuido;
    public Animator animator;
    public TMPro.TextMeshProUGUI interactionText;
    private bool IsOpen = false;

    public override void OnFocus()
    {
        interactionText.text = "E et katsuda";
    }

    public override void OnInteract()
    {
        if (IsOpen)
        {
            IsOpen = false;
            DoorOpenAudio.Play();
        }
        else
        {
            IsOpen = true;
            DoorCloseAuido.Play();
        }
        
    }

    public override void OnLoseFocus()
    {
        interactionText.text = "";
    }

  
}