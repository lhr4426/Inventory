using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackValue;
    [SerializeField] private TextMeshProUGUI defenceValue;
    [SerializeField] private TextMeshProUGUI hpValue;
    [SerializeField] private TextMeshProUGUI critValue;
    [SerializeField] private Button backButton;

    private Character player;
    
    public void Init(Character player)
    {
        this.player = player;
        RefreshUI();
    }

    public void RefreshUI()
    {
        attackValue.text = player.attack.ToString();
        defenceValue.text = player.defence.ToString();
        hpValue.text = player.hp.ToString();
        critValue.text = player.critical.ToString();
    }
    
    private void Start()
    {
        backButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);
    }
}
