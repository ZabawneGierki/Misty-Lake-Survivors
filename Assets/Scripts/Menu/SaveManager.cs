using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int coins;
    public Tuple<string, int> unlockedUpgrades = new("", 0); 
    public List<CharacterName> unlockedCharacters = new();
}

public enum CharacterName
{
    Reimu,
    Marisa,
    Daiyousei,
    Remilia,
    Cirno,
    Flandre

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
            return new SaveData(); // returns new blank save if none found

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public static void ResetSave()
    {
        if (File.Exists(path))
            File.Delete(path);
    }
}

