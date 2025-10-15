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
    public GameObject screenRef;
    public ScreenName screenName;
}
public class ScreenManager : MonoBehaviour
{
    private static ScreenManager instance;
    public static ScreenManager Instance { get { return instance; } }
    [SerializeField] List<Screen> screens;

    public void ShowScreen(ScreenName screenName)
    {
        foreach (var screen in screens)
        {
            if (screen.screenName == screenName)
            {
                screen.screenRef.SetActive(true);
            }
            else
            {
                screen.screenRef.SetActive(false);
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
