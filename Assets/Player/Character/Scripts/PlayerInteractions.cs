using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [Header("InteractableInfo")]
    public float sphereCastRadius = 0.5f;
    public int interactableLayerIndex;
    private Vector3 raycastPos;
    //public GameObject lookObject;
    private PhysicsObject physicsObject;
    private Camera mainCamera;

    [Header("Pickup")]
    [SerializeField] private Transform pickupParent;
    public GameObject currentlyPickedUpObject;
    private Rigidbody pickupRB;

    [Header("ObjectFollow")]
    [SerializeField] private float minSpeed = 0;
    [SerializeField] private float maxSpeed = 300f;
    [SerializeField] private float maxPickupDistance = 10f;
    [SerializeField] private float maxDistance = 10f;

    private float currentSpeed = 0f;
    private float currentDist = 0f;

    [Header("Rotation")]
    public float rotationSpeed = 100f;
    Quaternion lookRot;


    public Interactable currentInteractable;


    private void Start()
    {
        mainCamera = Camera.main;
    }

    //A simple visualization of the point we're following in the scene view
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(pickupParent.position, sphereCastRadius);

        //Gizmos.color = Color.white;
        //Gizmos.DrawWireSphere(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0)) + (mainCamera.transform.forward * maxPickupDistance), sphereCastRadius);
    }

    private void HandleInteractionCheck()
    {
        //Here we check if we're currently looking at an interactable object
        raycastPos = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.SphereCast(raycastPos, sphereCastRadius, mainCamera.transform.forward, out hit, maxPickupDistance))
        {
            if (hit.collider.gameObject.layer == interactableLayerIndex && (currentInteractable == null || hit.collider.gameObject.GetInstanceID() != currentInteractable.GetInstanceID()))
            {
                if (currentInteractable != null && hit.collider.gameObject.GetInstanceID() != currentInteractable.GetInstanceID())
                {
                    currentInteractable.OnLoseFocus();
                    currentInteractable = null;
                }

                hit.collider.TryGetComponent(out currentInteractable);
                if (currentInteractable == null) hit.transform.parent.TryGetComponent(out currentInteractable); // try to check the parent
                if (currentInteractable != null)
                {
                    currentInteractable.OnFocus();
                }
            }
            else if (currentInteractable != null) // If we hover over something not on interaction layer kill current interaction
            {
                currentInteractable.OnLoseFocus();
                currentInteractable = null;
            }
        }
        else if (currentInteractable)
        {
            currentInteractable.OnLoseFocus();
            currentInteractable = null;
        }
    }

    private void HandleInteractionInput()
    {
        //Here we check if we're currently looking at an interactable object
        raycastPos = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1") && currentInteractable != null && Physics.SphereCast(raycastPos, sphereCastRadius, mainCamera.transform.forward, out hit, maxPickupDistance, 1 << interactableLayerIndex))
        {
            currentInteractable.OnInteract();
        }
    }

    //Interactable Object detections and distance check
    void Update()
    {
        HandleInteractionCheck();
        HandleInteractionInput();
        HandlePickupInput();
    }

    private void HandlePickupInput()
    {
        //if we press the button of choice
        if (Input.GetButtonDown("Fire1"))
        {
            //and we're not holding anything
            if (currentlyPickedUpObject == null)
            {
                //and we are looking an interactable object
                if (currentInteractable != null)
                {
                    if (currentInteractable.CanPickup)
                    {
                        PickUpObject();
                    }
                }

            }
            //if we press the pickup button and have something, we drop it
            else
            {
                BreakConnection();
            }
        }
    }

    //Velocity movement toward pickup parent and rotation
    private void FixedUpdate()
    {
        if (currentlyPickedUpObject != null)
        {
            currentDist = Vector3.Distance(pickupParent.position, pickupRB.position);
            currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, currentDist / maxDistance);
            currentSpeed *= Time.fixedDeltaTime;
            Vector3 direction = pickupParent.position - pickupRB.position;
            pickupRB.velocity = direction.normalized * currentSpeed;
           
            if (Input.GetKey(KeyCode.E))
            {
                //Rotation
                //lookRot = Quaternion.LookRotation(mainCamera.transform.position - pickupRB.position);
                lookRot = Quaternion.Slerp(mainCamera.transform.rotation, pickupRB.rotation, rotationSpeed * Time.fixedDeltaTime);
                pickupRB.MoveRotation(lookRot);
            }
            // Commented out so object doesnt rotate with player look direction
        }

    }

    //Release the object
    public void BreakConnection()
    {
        pickupRB.constraints = RigidbodyConstraints.None;
        currentlyPickedUpObject = null;
        physicsObject.pickedUp = false;
        currentDist = 0;
    }

    public void PickUpObject()
    {
        physicsObject = currentInteractable.GetComponentInChildren<PhysicsObject>();
        currentlyPickedUpObject = currentInteractable.gameObject;
        pickupRB = currentlyPickedUpObject.GetComponent<Rigidbody>();
        pickupRB.constraints = RigidbodyConstraints.FreezeRotation;
        physicsObject.playerInteractions = this;
        StartCoroutine(physicsObject.PickUp());
    }
}
