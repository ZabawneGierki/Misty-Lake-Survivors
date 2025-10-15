using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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

    public Screen currentScreen;
    public static ScreenManager Instance { get { return instance; } }
    [SerializeField] List<Screen> screens;

    public Stack<ScreenName> screenHistory = new Stack<ScreenName>();


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
       currentScreen = screens.Find(s => s.screenName == ScreenName.MainMenu);
    }

    public void ShowScreen(ScreenName screenName)
    {

        if (currentScreen != null)
        {
            currentScreen.screenRef.SetActive(false);
            screenHistory.Push(currentScreen.screenName);
        }
        Screen screenToShow = screens.Find(s => s.screenName == screenName);
        if (screenToShow != null)
        {
            screenToShow.screenRef.SetActive(true);
            currentScreen = screenToShow;
        }
        else
        {
            Debug.LogError("Screen not found: " + screenName);
        }

    }

    public void GoBack()
    {
         
    }
}
