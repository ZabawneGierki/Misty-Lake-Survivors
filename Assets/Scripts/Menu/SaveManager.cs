using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



[System.Serializable]
public class UpgradeData
{
    public string upgradeName;
    public int level;
}
[Serializable]
public class SaveData
{
    public int coins;
    public Tuple<string, int> unlockedUpgrades = null; 
    public List<CharacterNames> unlockedCharacters = new();
}


public static class SaveManager
{
    private static string path = Application.persistentDataPath + "/save.json";

    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public static SaveData Load()
    {
        if (!File.Exists(path))
        {
            var newSave = new SaveData();
            newSave.unlockedCharacters.Add(CharacterNames.Reimu);  // add Reimu at the start.
            Save(newSave); // optional: create file right away
            return newSave;
        }

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public static void ResetSave()
    {
        if (File.Exists(path))
            File.Delete(path);
    }
}

