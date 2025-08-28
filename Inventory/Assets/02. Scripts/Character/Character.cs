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


    public int attack;
    public int defence;
    public int hp;
    public int critical;

    public void Init()
    {
        // EquipImages에 타입에 맞게 이미지 저장해두고 나중에 변경할 예정
        equipImages.Add(EquipType.Top, topImage);
        equipImages.Add(EquipType.Bottom, bottomImage);

        // 베이스 수치 반영
        attack = data.attack;
        defence = data.defence;
        hp = data.hp;
        critical = data.crit;
        
        // 만약 아이템을 착용한 채로 저장했었다면
        // 착용한 상태를 불러와야 함
        if (data.equipItems != null)
        {
            for (int i = 0; i < data.equipItems.Count; i++)
            {
                Equip(data.equipItems[i]);
            }
        }
        
        // 데이터 반영한대로 업데이트 해줘야함
        UIManager.Instance.Status.RefreshUI();
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
            // 같은 그룹의 아이템은 하나만 착용 가능
            // ex) 상의는 하나만 착용 가능
            // 그래서 이미 있으면 착용해제 시키기
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

        
        // 아이템 수치 적용
        switch (item.statType)
        {
            case StatType.Attack:
                attack += (int)item.statValue;
                break;
            case StatType.Defence:
                defence += (int)item.statValue;
                break;
            case StatType.Hp :
                hp += (int)item.statValue;
                break;
            case StatType.Critical :
                critical += (int)item.statValue;
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
            UIManager.Instance.Inventory.RefreshSlot(equipItems[item.equipType]);
            equipItems.Remove(item.equipType);
            data.equipItems.Remove(item);
            UIManager.Instance.Status.RefreshUI();
        }
        
        equipImages[item.equipType].sprite = null;
        equipImages[item.equipType].color = Color.white;
        equipImages[item.equipType].gameObject.SetActive(false);
        switch (item.statType)
        {
            case StatType.Attack:
                attack = data.attack;
                break;
            case StatType.Defence:
                defence = data.defence;
                break;
            case StatType.Hp :
                hp = data.hp;
                break;
            case StatType.Critical :
                critical = data.crit;
                break;
        }
        UIManager.Instance.Status.RefreshUI();
        item.isEquipped = false;
    }
}