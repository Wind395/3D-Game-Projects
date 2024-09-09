using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    // message disabled to player when looking at an interactable
    public string promptMessage;

    // this function will be called from our player
    public void BaseInteract() 
    {
        Interact();
    }

    protected virtual void Interact()
    {
        // we wont have any code written in this function
        // this is template function to be overridden by our subclasses 
    }
}
