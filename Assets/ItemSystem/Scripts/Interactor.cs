using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Inventory attachedInventory;

    Transform actorCamera
    LayerMask layerMask;

    [SerializeField]
    private float maxDistanceFromCameraToObjects = 100f;

    [SerializeField]
    private float interactableDistance = 3f;
    private float distanceToInteractable;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    public void Interact()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            actorCamera = Camera.main.tansform;
        }
    }
}
