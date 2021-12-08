using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable1 : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent Events;

    public virtual void Awake()
    {
        gameObject.layer = 7;
    }
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                Events.Invoke();
            }

        }
    }
    private void OnTriggerEnter(Collider Collider3D)
    {
        if (Collider3D.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is in range");
        }
    }
    private void OnTriggerExit(Collider Collider3D)
    {
        if (Collider3D.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is not in range");
        }
    }
}
