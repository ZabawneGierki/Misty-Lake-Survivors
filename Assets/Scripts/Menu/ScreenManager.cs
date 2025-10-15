using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ScreenName
{
    MainMenu,
    Settings,
    CharacternlvlSelection,

}
[System.Serializable]
public class  Screen
{
    GameObject screenRef;
    ScreenName screenName;
}
public class ScreenManager : MonoBehaviour
{
    private static ScreenManager instance;
    public static ScreenManager Instance { get { return instance; } }
    [SerializeField] List<Screen> screens;

    private void Awake()
    {
        instance = this;
    }
}
