using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;    

public class LevelUpUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject panel;
    public Transform choiceParent;
    public GameObject choiceButtonPrefab;

    [Header("Available Upgrades")]
    public List<WeaponData> allWeapons;
    public List<PowerUpEffect> allPowerUps;

    [Header("Fallback Options")]
    public Sprite healIcon;
    public string healText = "Recover 20% HP";

    PlayerInventory inventory;
    int choicesToShow = 3;
     

    void Start()
    {
        inventory = FindObjectOfType<PlayerInventory>();
        panel.SetActive(false);
        
        
    }

     

    public void ShowChoices()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;

        foreach (Transform c in choiceParent) Destroy(c.gameObject);

        // Collect valid upgrade options
        List<ChoiceData> validChoices = new List<ChoiceData>();

        // Weapons
        foreach (var w in allWeapons)
        {
            var existing = inventory.weapons.Find(x => x.data == w);
            if (existing == null || existing.level < w.maxLevel)
                validChoices.Add(new ChoiceData { weapon = w });
        }

        // PowerUps
        foreach (var p in allPowerUps)
        {
            var existing = inventory.powerUps.Find(x => x.effect == p);
            if (existing == null || existing.level < p.maxLevel)
                validChoices.Add(new ChoiceData { powerUp = p });
        }

        // If nothing left, fallback to heal
        if (validChoices.Count == 0)
        {
            CreateFallbackChoice();
            return;
        }

        // Shuffle and pick limited number without duplicates
        validChoices = validChoices.OrderBy(x => Random.value).Take(Mathf.Min(choicesToShow, validChoices.Count)).ToList();

        // Create buttons
        foreach (var choice in validChoices)
        {
            CreateChoiceButton(choice);
        }
    }

    void CreateChoiceButton(ChoiceData choice)
    {
        var btnObj = Instantiate(choiceButtonPrefab, choiceParent);
        var img = btnObj.transform.Find("Icon").GetComponent<Image>();
        var nameTxt = btnObj.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        var descTxt = btnObj.transform.Find("Description").GetComponent<TextMeshProUGUI>();
        var levelTxt = btnObj.transform.Find("Level").GetComponent<TextMeshProUGUI>();

        Button btn = btnObj.GetComponent<Button>();

        if (choice.weapon != null)
        {
            var w = choice.weapon;
            var existing = inventory.weapons.Find(x => x.data == w);
            int nextLevel = existing == null ? 1 : existing.level + 1;

            img.sprite = w.icon;
            nameTxt.text = w.weaponName;
            descTxt.text = "Level " + nextLevel;
            levelTxt.text = (existing != null ? $"Current Lv {existing.level}" : "New Weapon");

            btn.onClick.AddListener(() =>
            {
                if (existing != null)
                    inventory.LevelUpWeapon(w);
                else
                    inventory.AddWeapon(w, inventory.transform.Find("WeaponMount"));
                ClosePanel();
            });
        }
        else if (choice.powerUp != null)
        {
            var p = choice.powerUp;
            var existing = inventory.powerUps.Find(x => x.effect == p);
            int nextLevel = existing == null ? 1 : existing.level + 1;

            img.sprite = p.icon;
            nameTxt.text = p.powerName;
            descTxt.text = p.GetDescription(nextLevel);
            levelTxt.text = existing != null ? $"Current Lv {existing.level}" : "New Power-Up";

            btn.onClick.AddListener(() =>
            {
                if (existing != null)
                    inventory.LevelUpPowerUp(p);
                else
                    inventory.AddPowerUp(p);
                ClosePanel();
            });
        }
    }

    void CreateFallbackChoice()
    {
        var btnObj = Instantiate(choiceButtonPrefab, choiceParent);
        var img = btnObj.transform.Find("Icon").GetComponent<Image>();
        var nameTxt = btnObj.transform.Find("Name").GetComponent<Text>();
        var descTxt = btnObj.transform.Find("Description").GetComponent<Text>();
        var levelTxt = btnObj.transform.Find("Level").GetComponent<Text>();
        var btn = btnObj.GetComponent<Button>();

        img.sprite = healIcon;
        nameTxt.text = "Heal";
        descTxt.text = healText;
        levelTxt.text = "";

        btn.onClick.AddListener(() =>
        {
            // Simple heal effect
            var health = FindObjectOfType<PlayerHealth>();
            if (health != null)
               // health.HealPercent(0.2f); // heal 20%
            ClosePanel();
        });
    }

    void ClosePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    class ChoiceData
    {
        public WeaponData weapon;
        public PowerUpEffect powerUp;
    }
}