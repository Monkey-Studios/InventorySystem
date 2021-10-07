using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    public override void Interact()
    {
        base.Interact();
        Pickup();
    }

    public override void Interact(Interactor interactor)
    {
        base.Interact(interactor);
        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picked up " + transform.name);

        if (itemObject.useOnPickup)
        {
            Use();
        }
        else
        {
            Store();
        }
    }

    void Store()
    {
        if(interactor != null)
        {
            interactor.PutInStorage(itemObject, quantity);
            Destroy(gameObject);
        }
    }

    void Use()
    {
        if(itemObject.consumable)
        {
            quantity--;
            if(quantity <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
