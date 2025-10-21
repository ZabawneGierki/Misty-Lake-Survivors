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

    private CharacterData characterData;

    public CharacterNames characterName;



    public void Init (CharacterData cd)
    {
        characterData = cd;
        CharacterNameText.text = characterData.fullName;
        CharacterSprite.sprite = characterData.characterPortrait;

        // check if character is unlocked 

    }

}
