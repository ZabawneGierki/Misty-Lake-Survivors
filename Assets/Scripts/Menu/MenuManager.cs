using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public static MenuManager instance;
    public SaveData saveData;


    private void Awake()
    {
        instance = this;
        LoadGame();
    }


    public void AddCoins(int amount)
    {
        saveData.coins += amount;
        SaveManager.Save(saveData);
    }

    public void UnlockCharacter(CharacterNames character)
    {
        if (!saveData.unlockedCharacters.Contains(character))
        {
            saveData.unlockedCharacters.Add(character);
            SaveManager.Save(saveData);
        }
    }


    public bool IsCharacterUnlocked(CharacterNames character)
    {
        return saveData.unlockedCharacters.Contains(character);
    }
    void LoadGame()
    {
        saveData = SaveManager.Load();
    }

    public void ResetProgress()
    {
        SaveManager.ResetSave();
        saveData = new SaveData();
    }
}
