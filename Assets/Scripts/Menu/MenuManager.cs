using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{

    public static MenuManager instance;
    public SaveData saveData;


    // handling a toast message.
    [SerializeField] private CanvasGroup toastMessage;

    private void Awake()
    {
        instance = this;
        LoadGame();
    }


    private void Start()
    {
        toastMessage.alpha = 0f;
         
    }
    public void AddCoins(int amount)
    {
        saveData.coins += amount;
        SaveManager.Save(saveData);
    }

    public bool SpendCoins(int amount)
    {
        if (saveData.coins >= amount)
        {
            saveData.coins -= amount;
            SaveManager.Save(saveData);
            return true;
        }
        return false;
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



    public void ShowToastMessage(string message, float duration = 0.5f)
    {
        toastMessage.enabled = true;
        toastMessage.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = message;
        toastMessage.DOFade(1f, 0.5f).OnComplete(() =>
        {
            DOVirtual.DelayedCall(duration, () =>
            {
                toastMessage.DOFade(0f, 0.5f);
            });
        });
    }

}
