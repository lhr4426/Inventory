using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Outline outline;
    [SerializeField] private Button button;
    
    
    private Item item;
    
    public void SetItem(Item item)
    {
        // 아이템 들어오면 해당 슬롯의 아이템을 설정
        this.item = item;
        button.onClick.RemoveAllListeners(); // 버튼 클릭하면 장착 할 수 있도록 설정
        button.onClick.AddListener(onClickButton);
        RefreshUI();
    }

    public void RefreshUI()
    {
        switch (item.equipType)
        {
            case EquipType.Top:
                icon.sprite = Resources.Load<Sprite>("Item/top");
                break;
            case EquipType.Bottom:
                icon.sprite = Resources.Load<Sprite>("Item/bottom");
                break;
            default :
                Destroy(icon);
                break;
        }

        icon.color = item.color;
    }

    public void ChangeEquip()
    {
        item.isEquipped  = !item.isEquipped;
        if(item.isEquipped) GameManager.Instance.Player.Equip(item);
        else GameManager.Instance.Player.UnEquip(item);
        outline.enabled = item.isEquipped;
    }

    public void onClickButton()
    {
        ChangeEquip();
    }
}
