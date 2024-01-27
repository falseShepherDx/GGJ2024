using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Error : MonoBehaviour, M_IInteractable
{
    public ItemSO item;
    public void Interact()
    {
        if (M_InventoryManager.Instance != null)
        {
            if (M_InventoryManager.Instance.Items.Count < M_InventoryManager.Instance.maxItems)
            {
                M_InventoryManager.Instance.Add(item);
                Debug.Log(item+ "added to inventory");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Inventory Full");
            }
        }
    }

    public string GetDescription()
    {
        return "ERROR";
    }
}
