using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    //Exteneded version of a private variable that can be edited in the inspector
    protected ItemObject itemObject;

    [SerializeField]
    protected int quantity = 1;

    protected Interactor interactor;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    //You can have multiple public functions provided one of them has a perameter contained in the brackets
    public virtual void Interact(Interactor interactor)
    {
        Debug.Log("Interacting with " + transform.name + ". (Interactor passed)");
        this.interactor = interactor;
    }
}
