using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class  CharacterData
{
    string fullName;
    CharacterNames name;
    Sprite characterPortrait;

        
}
public class CharacterButtonLoader : MonoBehaviour
{
    [SerializeField]
     List<CharacterData> characterDataList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
