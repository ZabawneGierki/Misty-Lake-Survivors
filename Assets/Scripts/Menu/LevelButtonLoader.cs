using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


[System.Serializable]

public class LevelData
{
    public string levelName;
    public int levelIndex;
    public Sprite levelThumbnail;
}
public class LevelButtonLoader : MonoBehaviour
{
    private const string Name = "Name";
    private const string Icon = "Icon";
    [SerializeField]
    List<LevelData> levelDataList;
    [SerializeField] GameObject levelButtonPrefab;
    [SerializeField] Transform buttonContainer;
    // Start is called before the first frame update
    void Start()
    {
        bool isFirst = true;
        foreach (LevelData level in levelDataList)
        {
            GameObject button = Instantiate(levelButtonPrefab, buttonContainer);
            // Set button data here
            button.transform.Find(Name).GetComponent<TextMeshProUGUI>().text = level.levelName;
            button.transform.Find(Icon).GetComponent<Image>().sprite = level.levelThumbnail;

            Toggle toggle = button.GetComponentInChildren<Toggle>();
            toggle.onValueChanged.AddListener((isOn) => { if (isOn) OnClick(level); });
            toggle.group = buttonContainer.GetComponent<ToggleGroup>();
            toggle.isOn = isFirst; // Set only the first toggle to be on
            isFirst = false;
        }
    }

    private void OnClick(LevelData lvl)
    {
        Debug.Log("Clicked on level: " + lvl.levelName);

        // set player data
        PlayerData.selectedLevel = lvl.levelIndex;
    }
}
