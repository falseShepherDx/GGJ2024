using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class M_InventoryUI : MonoBehaviour
{
  public List<GameObject> itemIcons;
  public static M_InventoryUI Instance;
  private int selectedIndex = 0; 
  private void Awake()
  {
    Instance = this;
  }

  public void UpdateUI()
  {
    float scrollInput = Input.GetAxis("Mouse ScrollWheel");

    if (scrollInput != 0)
    {
      selectedIndex += Mathf.RoundToInt(scrollInput);
      selectedIndex = Mathf.Clamp(selectedIndex, 0, M_InventoryManager.Instance.Items.Count - 1);
      Debug.Log("Selected item: " + M_InventoryManager.Instance.Items[selectedIndex].itemName);
    }
    Transform slotsParent = transform;
    for (int i = 0; i < M_InventoryManager.Instance.Items.Count; i++)
    {
      if (i < slotsParent.childCount)
      {
        Image iconImage = slotsParent.GetChild(i).GetComponent<Image>();
        if (iconImage != null)
        {
          iconImage.sprite = M_InventoryManager.Instance.Items[i].icon;
          
        }
        if (i == selectedIndex)
        {
          
          iconImage.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
          iconImage.color = Color.yellow;
        }
        else
        {
         
          iconImage.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); 
          iconImage.color = Color.white;
        }
      }
      else
      {
        Debug.LogWarning("Not enough slots for all items in the inventory!");
      }
    }
   
  }
  }
