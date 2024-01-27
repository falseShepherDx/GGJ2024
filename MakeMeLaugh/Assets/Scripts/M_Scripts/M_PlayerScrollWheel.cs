using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class M_PlayerScrollWheel : MonoBehaviour
{
    
    public static int selectedIndex=0;

    private void Update()
    {
        Inputs();
        
    }

    public void Inputs()
    {
        // Check for number key presses (1, 2, 3, ...)
        for (int i = 0; i < M_InventoryManager.Instance.maxItems; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                selectedIndex = i;
                Debug.Log("Selected item: " + M_InventoryManager.Instance.Items[selectedIndex].itemName);
                Debug.Log("Index: " + selectedIndex);
            }
        }
    }
 
    
    }
   
    

