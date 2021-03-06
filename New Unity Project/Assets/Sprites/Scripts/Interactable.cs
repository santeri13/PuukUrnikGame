// INTERACTABLE SCRIPT
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public void Awake()
    {
        gameObject.layer = 7;
    }
    public abstract void OnInteract(int encounter);
    public abstract void OnFocus();
    public abstract void OnLoseFocus();
}
