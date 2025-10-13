using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterData
{
    public string fullName;
    public CharacterNames name;
    public Sprite characterPortrait;
}

public class CharacterButtonLoader : MonoBehaviour
{
    [SerializeField]
    List<CharacterData> characterDataList;
    [SerializeField] GameObject characterButtonPrefab;
    [SerializeField] Transform buttonContainer;

    void Start()
    {
        bool isFirst = true;
        foreach (CharacterData character in characterDataList)
        {
            GameObject button = Instantiate(characterButtonPrefab, buttonContainer);

            // Set button data here
            button.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = character.fullName;
            button.transform.Find("Icon").GetComponent<Image>().sprite = character.characterPortrait;
            
            Toggle toggle = button.GetComponentInChildren<Toggle>();
            toggle.onValueChanged.AddListener((isOn) => { if (isOn) OnClick(character.name); });
            toggle.group = buttonContainer.GetComponent<ToggleGroup>();
            toggle.isOn = isFirst; // Set only the first toggle to be on
            
            isFirst = false;
        }
    }

    private void OnClick(CharacterNames characterName)
    {
        Debug.Log("Clicked on character: " + characterName);
        // Handle character selection logic here
        PlayerData.selectedCharacterName = characterName;
    }
}
