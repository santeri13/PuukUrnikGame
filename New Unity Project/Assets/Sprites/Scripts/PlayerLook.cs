using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    [SerializeField] private bool canInteract = true;

    [SerializeField] private Vector3 interactionRayPoint = default;
    [SerializeField] private float interactionDistance = default;
    [SerializeField] private LayerMask interactionLayer = default;
    private Interactable currentInteractable;
    public Camera cam;



    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
        if (canInteract)
        {
            HandelIeractionCheck();
            HandelInteractionInput();
            
        }
    }
    private void HandelIeractionCheck()
    {
        if(Physics.Raycast(cam.ViewportPointToRay(interactionRayPoint),out RaycastHit hit, interactionDistance))
        {
            print(hit.collider);
            if (hit.collider.gameObject.layer == 7 && (currentInteractable == null || hit.collider.gameObject.GetInstanceID()!= currentInteractable.GetInstanceID()))
            {
                
                currentInteractable = hit.collider.gameObject.GetComponent<Interactable>();
                
                if (currentInteractable)
                {
                    
                    currentInteractable.OnFocus();
                }
            }
        }
        else if (currentInteractable)
        {
            currentInteractable.OnLoseFocus();
            currentInteractable = null;
        }
    }
    private void HandelInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null && Physics.Raycast(cam.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance, interactionLayer))
        {
            currentInteractable.OnInteract();
        }
            
        

        
    }
}
