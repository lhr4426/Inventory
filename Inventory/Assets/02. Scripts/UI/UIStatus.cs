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

    
    public void Init(Character player)
    {
        attackValue.text = player.baseAttack.ToString();
        defenceValue.text = player.baseDefense.ToString();
        hpValue.text = player.baseHp.ToString();
        critValue.text = player.baseCrit.ToString();
    }
    
    private void Start()
    {
        backButton.onClick.AddListener(UIManager.Instance.OpenMainMenu);
    }
}
