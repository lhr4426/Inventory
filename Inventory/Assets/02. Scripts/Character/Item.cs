using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    Top,
    Bottom
}

public enum StatType
{
    Attack,
    Defence,
    Hp,
    Critical
}

[System.Serializable]
public class Item
{
    public string name;
    public EquipType equipType;
    public bool isEquipped = false;
    public Color color;
    public StatType statType;
    public float statValue;
}
