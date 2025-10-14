using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class CharacterPrefab
{
    public CharacterNames characterName;
    public GameObject prefab;
}

[System.Serializable]
public class LevelPrefab
{
    public int levelIndex;
    public GameObject prefab;
}
public class GameplayManager : MonoBehaviour
{

    [SerializeField]
    List<CharacterPrefab> characterPrefabs;

    [SerializeField]
    List<LevelPrefab> levelPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject characterPrefab = characterPrefabs.Find(c => c.characterName == PlayerData.selectedCharacterName)?.prefab; 
        GameObject levelPrefab = levelPrefabs.Find(l => l.levelIndex == PlayerData.selectedLevel)?.prefab;

        if (characterPrefab != null)
        {
            Instantiate(characterPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Character prefab not found for: " + PlayerData.selectedCharacterName);
        }
        if (levelPrefab != null)
        {
            Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Level prefab not found for level index: " + PlayerData.selectedLevel);
        }
    }


}
