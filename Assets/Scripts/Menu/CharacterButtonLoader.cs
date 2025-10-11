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
    // Start is called before the first frame update
    void Start()
    {
        foreach(CharacterData character in characterDataList)
        {
            GameObject button = Instantiate(characterButtonPrefab, buttonContainer);
            // Set button data here
            button.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = character.fullName;
            button.transform.Find("Icon").GetComponent<Image>().sprite = character.characterPortrait;

        }
    }



   
}
