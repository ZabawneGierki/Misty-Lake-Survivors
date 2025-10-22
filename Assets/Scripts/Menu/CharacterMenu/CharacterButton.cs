using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CharacterButton : MonoBehaviour
{
    [Header("public references")]

    public TextMeshProUGUI CharacterNameText;
    public Image CharacterSprite;
    public Toggle Toggle;

    public TextMeshProUGUI priceTag;
    public Image lockScreen;
    public Button button;

    private CharacterData characterData;

    public CharacterNames characterName;

    private const int characterUnlockPrice = 200;

    public void Init(CharacterData cd)
    {
        characterData = cd;
        CharacterNameText.text = characterData.fullName;
        CharacterSprite.sprite = characterData.characterPortrait;


        button.onClick.AddListener(() =>
        {
            if (MenuManager.instance.SpendCoins(characterUnlockPrice))
            {
                MenuManager.instance.UnlockCharacter(characterData.name);
                Toggle.interactable = true;
                Unlock();
                MenuManager.instance.ShowToastMessage(characterData.fullName + " unlocked!");
            }
            else
            {
                Debug.Log("Not enough coins to unlock " + characterData.fullName);
                MenuManager.instance.ShowToastMessage("Not enough coins to unlock " + characterData.fullName);
                 
            }

        });

        // check if character is unlocked 
        if (MenuManager.instance.IsCharacterUnlocked(characterData.name))
        {

            Toggle.interactable = true;
            Unlock();
        }
        else
        {
            Toggle.isOn = false;
            Toggle.interactable = false;
        }

    }


    private void Unlock()
    {
        priceTag.gameObject.SetActive(false);
        lockScreen.gameObject.SetActive(false);


    }




}
