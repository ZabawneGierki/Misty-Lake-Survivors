using TMPro; // if you use TextMeshPro
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItemUI : MonoBehaviour
{
    public Image icon;
    public Button buyButton;
    public Transform starsParent;
    public Sprite emptyStar;
    public Sprite filledStar;

    [HideInInspector] public string upgradeName;
    [HideInInspector] public int currentLevel;
    [HideInInspector] public int maxLevel;
    [HideInInspector] public int costPerLevel = 10; // or whatever

    private void Start()
    {
        buyButton.onClick.AddListener(OnBuy);
    }

    public void Setup(string name, Sprite iconSprite, int level, int maxLvl)
    {
        upgradeName = name;
        icon.sprite = iconSprite;
        currentLevel = level;
        maxLevel = maxLvl;
        RefreshStars();
        RefreshButton();
    }

    void RefreshStars()
    {
        for (int i = 0; i < starsParent.childCount; i++)
        {
            var img = starsParent.GetChild(i).GetComponent<Image>();
            img.sprite = i < currentLevel ? filledStar : emptyStar;
        }
    }

    void RefreshButton()
    {
        bool canBuy = currentLevel < maxLevel &&
                      MenuManager.instance.saveData.coins >= costPerLevel;
        buyButton.interactable = canBuy;
    }

    void OnBuy()
    {
        if (MenuManager.instance.saveData.coins < costPerLevel) return;

        MenuManager.instance.saveData.coins -= costPerLevel;
        currentLevel++;
        GameManager.Instance.UpgradeLevel(upgradeName);
        GameManager.Instance.SaveGame();

        RefreshStars();
        RefreshButton();
    }
}

