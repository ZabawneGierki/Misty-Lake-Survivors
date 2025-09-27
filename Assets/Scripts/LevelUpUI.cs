using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    public GameObject selectionPanel;

    void OnEnable()
    {
        FindObjectOfType<PlayerLevel>().OnLevelUp.AddListener(ShowPanel);
    }

    void OnDisable()
    {
        FindObjectOfType<PlayerLevel>().OnLevelUp.RemoveListener(ShowPanel);
    }

    void ShowPanel(int newLevel)
    {
        selectionPanel.SetActive(true);
        Time.timeScale = 0f; // pause game during choice
    }
}
