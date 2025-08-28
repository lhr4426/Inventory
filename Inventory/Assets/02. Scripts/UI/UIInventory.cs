using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Transform itemParent;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Button backButton;

    private Character player;
    private Dictionary<Item, UISlot> itemSlots = new();
    
    public void Init(Character player)
    {
        this.player = player;
        itemCount.text = player.data.items.Count.ToString();
        
        for (int i = 0; i < player.data.items.Count; i++)
        {
            GameObject go = Instantiate(slotPrefab, itemParent);
            go.GetComponent<UISlot>().SetItem(player.data.items[i]);
            itemSlots.Add(player.data.items[i], go.GetComponent<UISlot>());
        }
    }

    public void RefreshSlot(Item item)
    {
        if (itemSlots.ContainsKey(item))
        {
            itemSlots[item].RefreshUI();
        }
        else return;
    }

    public void AddItem(Item item)
    {
        GameObject go = Instantiate(slotPrefab, itemParent);
        go.GetComponent<UISlot>().SetItem(item);
        
        itemCount.text = (int.Parse(itemCount.text) + 1).ToString();
    }
    
    private void Start()
    {
        backButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);
    }
}
