using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class M_InventoryManager : MonoBehaviour
{
    public static M_InventoryManager Instance;
    public List<ItemSO> Items = new List<ItemSO>();
    public int maxItems = 3;
    

    private void Awake()
    {
        Instance = this;
        
        
    }

    private void Update()
    {
        // Debug.Log(Items.Count);
    }

    public void Add(ItemSO item)
    {
            Items.Add(item);
            
            
    }

    public void Remove(ItemSO item)
    {
        Items.Remove(item);
        
    }

 
    
    
   
}
