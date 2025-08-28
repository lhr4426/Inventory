using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static string SavePath => Application.persistentDataPath + "/playerData.json";
    
    [field: SerializeField] public Character Player { get; private set; }

    private void Awake()
    {
        LoadData();
    }

    private void Start()
    {
        SetData();
    }

    private void OnDisable()
    {
        SaveData();
    }

    public void SetData()
    {
        // UI Manager에 플레이어 데이터 넘겨주고 초기화 시키기
        UIManager.Instance.Init(Player);
        Player.Init();
    }

    public void LoadData()
    {
        string loadData;
        try
        {
            loadData = File.ReadAllText(SavePath);
        }
        // 파일 자체가 없는 경우
        catch (FileNotFoundException) 
        {
            Debug.LogError("Player data file not found. Creating new player data.");
            CreateData();
            return;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error reading player data file: {e.Message}");
            return;
        }

        // 파일이 비어있는 경우
        if (loadData == "") 
        {
            Debug.LogError("There's No Player Data");
            Debug.Log("Creating New Player Data");
            CreateData();
        }
        else
        {
            Player.data = JsonUtility.FromJson<CharacterData>(loadData);
        }
    }

    public void SaveData()
    {
        var saveData = JsonUtility.ToJson(Player.data);
        File.WriteAllText(SavePath, saveData);
        Debug.Log($"{SavePath}");
    }

    private void CreateData()
    {
        Player.data.name = "test";
        Player.data.level = 1;
        Player.data.money = 0;
        Player.data.attack = 10;
        Player.data.defence = 10;
        Player.data.hp = 100;
        Player.data.crit = 10;
        Player.data.items.Clear();
        Player.data.items.Add(
            new Item()
            {
                name = "흰색 티",
                equipType = EquipType.Top,
                isEquipped = false,
                color = new Color(1, 1, 1, 1),
                statType = StatType.Attack,
                statValue = 5
            });
        Player.data.items.Add(
            new Item()
            {
                name = "검은 티",
                equipType = EquipType.Top,
                isEquipped = false,
                color = new Color(0, 0, 0, 1),
                statType = StatType.Critical,
                statValue = 7
            });
        
        Player.data.items.Add(
            new Item()
            {
                name = "청바지",
                equipType = EquipType.Bottom,
                isEquipped = false,
                color = new Color(25/255f, 25/255f, 112/255f, 1),
                statType = StatType.Defence,
                statValue = 5
            });
        Player.data.items.Add(
            new Item()
            {
                name = "베이지색 바지",
                equipType = EquipType.Bottom,
                isEquipped = false,
                color = new Color(222/255f, 184/255f, 135/255f, 1),
                statType = StatType.Hp,
                statValue = 20
            });
        
        SaveData(); // 기본값으로 만들고 저장 한 번 하기
    }
}
