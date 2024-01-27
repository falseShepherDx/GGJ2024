using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Error : MonoBehaviour, M_IInteractable
{

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public string GetDescription()
    {
        return "ERROR";
    }
}
