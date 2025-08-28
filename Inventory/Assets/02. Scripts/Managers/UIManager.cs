using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [field : SerializeField] public UIMainMenu MainMenu { get; private set; }
    [field : SerializeField] public UIStatus Status { get; private set; }
    [field : SerializeField] public UIInventory Inventory { get; private set; }


    public void Init(Character player)
    {
        MainMenu.Init(player);
        Status.Init(player);
        Inventory.Init(player);
    }
    
    public void OpenMainMenu()
    {
        MainMenu.OpenMainMenu();
        Status.gameObject.SetActive(false);
        Inventory.gameObject.SetActive(false);
    }

    public void OpenStatus()
    {
        MainMenu.CloseMainMenu();
        Inventory.gameObject.SetActive(false);
        Status.gameObject.SetActive(true);
    }

    public void OpenInventory()
    {
        MainMenu.CloseMainMenu();
        Status.gameObject.SetActive(false);
        Inventory.gameObject.SetActive(true);
    }
}
