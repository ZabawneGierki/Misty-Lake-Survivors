using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class LevelData
{
    public string levelName;
    public int levelIndex;
    public Sprite levelThumbnail;
}
public class LevelButtonLoader : MonoBehaviour
{
    [SerializeField]
    List<LevelData> levelDataList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     
}
