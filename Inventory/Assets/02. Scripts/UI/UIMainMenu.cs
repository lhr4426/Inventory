using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerLevel;
    [SerializeField] private TextMeshProUGUI playerMoney;
    
    [SerializeField] private GameObject buttons;
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    private Character player;
    
    public void Init(Character player)
    {
        this.player = player;
        playerName.text = player.data.name;
        playerLevel.text = "Lv. " + player.data.level;
        playerMoney.text = player.data.money.ToString();
    }

    public void RefreshUI()
    {
        playerLevel.text = "Lv. " + player.data.level;
        playerMoney.text = player.data.money.ToString();
    }
    
    public void OpenMainMenu()
    {
        buttons.SetActive(true);
    }

    public void CloseMainMenu()
    {
        buttons.SetActive(false);
    }

    private void Start()
    {
        statusButton.onClick.AddListener(UIManager.Instance.OpenStatus);
        inventoryButton.onClick.AddListener(UIManager.Instance.OpenInventory);
    }
}
