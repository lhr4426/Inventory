using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Transform itemParent;
    [SerializeField] private Button backButton;

    public void Init(Character player)
    {
        // TODO : 나중에 플레이어가 가지고있는 아이템 정보 여기다가 만들어주기
    }
    
    private void Start()
    {
        backButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);
    }
}
