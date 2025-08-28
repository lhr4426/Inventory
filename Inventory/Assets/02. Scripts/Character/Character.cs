using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public CharacterData data;
    public Dictionary<EquipType, Item> equipItems = new ();
    public Dictionary<EquipType, Image> equipImages = new ();
    [SerializeField] private Image topImage;
    [SerializeField] private Image bottomImage;

    public void Init()
    {
        if (data.equipItems != null)
        {
            foreach (var item in data.equipItems)
            {
                equipItems.Add(item.equipType, item);
            }
        }
        
        equipImages.Add(EquipType.Top, topImage);
        equipImages.Add(EquipType.Bottom, bottomImage);
    }
    
    public void AddItem(Item item)
    {
        data.items.Add(item);
        UIManager.Instance.Inventory.AddItem(item);
    }

    public void Equip(Item item)
    {
        if (equipItems.ContainsKey(item.equipType))
        {
            UnEquip(equipItems[item.equipType]);
        }
        
        equipItems[item.equipType] = item;
        switch (item.equipType)
        {
            case EquipType.Top:
                equipImages[item.equipType].sprite = Resources.Load<Sprite>("Item/top");
                break;
            case EquipType.Bottom:
                equipImages[item.equipType].sprite = Resources.Load<Sprite>("Item/bottom");
                break;
        }
        equipImages[item.equipType].color = item.color;
        equipImages[item.equipType].gameObject.SetActive(true);

        switch (item.statType)
        {
            case StatType.Attack:
                data.attack += (int)item.statValue;
                break;
            case StatType.Defence:
                data.attack += (int)item.statValue;
                break;
            case StatType.Hp :
                data.attack += (int)item.statValue;
                break;
            case StatType.Critical :
                data.attack += (int)item.statValue;
                break;
        }
        UIManager.Instance.Status.RefreshUI();
        
        data.equipItems.Add(item);
        item.isEquipped = true;
    }

    public void UnEquip(Item item)
    {
        if (equipItems.ContainsKey(item.equipType))
        {
            equipItems[item.equipType].isEquipped = false;
            equipItems.Remove(item.equipType);
            data.equipItems.Remove(item);
        }
        
        equipImages[item.equipType].sprite = null;
        equipImages[item.equipType].color = Color.white;
        equipImages[item.equipType].gameObject.SetActive(false);
        switch (item.statType)
        {
            case StatType.Attack:
                data.attack -= (int)item.statValue;
                break;
            case StatType.Defence:
                data.attack -= (int)item.statValue;
                break;
            case StatType.Hp :
                data.attack -= (int)item.statValue;
                break;
            case StatType.Critical :
                data.attack -= (int)item.statValue;
                break;
        }
        UIManager.Instance.Status.RefreshUI();
        item.isEquipped = false;
    }
}