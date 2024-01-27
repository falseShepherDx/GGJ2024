using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Door : MonoBehaviour,M_IInteractable
{
 
    public void Interact()
    {
        //door opening animation.blabla
    }

    public string GetDescription()
    {
        return "Open Door";
    }
}
