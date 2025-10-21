using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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



    public void Init (CharacterData cd)
    {
        characterData = cd;
        CharacterNameText.text = characterData.fullName;
        CharacterSprite.sprite = characterData.characterPortrait;

        // check if character is unlocked 
        if (MenuManager.instance.IsCharacterUnlocked(characterData.name))
        {
            Toggle.isOn = true;
            Toggle.interactable = true;
        }
        else
        {
            Toggle.isOn = false;
            Toggle.interactable = false;
        }

    }


    private void Unlock()
    {

    }

}
