using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class CharacterPrefab
{
    public CharacterNames characterName;
    public GameObject prefab;
}

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
        
    }

     
}
