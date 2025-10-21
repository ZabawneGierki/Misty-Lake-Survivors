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
