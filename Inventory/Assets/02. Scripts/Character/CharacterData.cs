using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string name;
    public int level;
    public long money;
    public int attack;
    public int defence;
    public int hp;
    public int crit;
    public List<Item> items;
    public List<Item> equipItems;
}