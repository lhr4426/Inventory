using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static string SavePath => Application.persistentDataPath + "/playerData.json";
    
    public Character Player { get; private set; }

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
        UIManager.Instance.Init(Player);
    }

    public void LoadData()
    {
        string loadData;
        try
        {
            loadData = File.ReadAllText(SavePath);
        }catch (FileNotFoundException)
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

        if (loadData == "")
        {
            Debug.LogError("There's No Player Data");
            Debug.Log("Creating New Player Data");
            CreateData();
        }
        else
        {
            Player = JsonUtility.FromJson<Character>(loadData);
        }
    }

    public void SaveData()
    {
        var saveData = JsonUtility.ToJson(Player);
        File.WriteAllText(SavePath, saveData);
        Debug.Log($"{SavePath}");
    }

    private void CreateData()
    {
        Player.name = "test";
        Player.level = 1;
        Player.money = 0;
        Player.baseAttack = 10;
        Player.baseDefense = 10;
        Player.baseHp = 100;
        Player.baseCrit = 10;

        SaveData();
    }
}
