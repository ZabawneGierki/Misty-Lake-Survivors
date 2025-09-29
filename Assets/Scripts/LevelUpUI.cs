using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class LevelUpUI : MonoBehaviour
{
    public GameObject panel;
    public Transform choiceParent;
    public GameObject choiceButtonPrefab;

    public List<WeaponData> allWeapons;
    public List<PowerUpData> allPowerUps;

    PlayerInventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<PlayerInventory>();
        panel.SetActive(false);
    }

    public void ShowChoices()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;

        // Clear old
        foreach (Transform c in choiceParent) Destroy(c.gameObject);

        // Generate 3 random choices (can tweak number)
        for (int i = 0; i < 3; i++)
        {
            bool pickWeapon = Random.value < 0.5f; // 50/50 weapon or powerup
            if (pickWeapon) MakeWeaponChoice();
            else MakePowerUpChoice();
        }
    }

    void MakeWeaponChoice()
    {
        // Pick a random weapon the player doesn’t have OR can level up
        WeaponData choice = allWeapons[Random.Range(0, allWeapons.Count)];
        var btn = Instantiate(choiceButtonPrefab, choiceParent);
        //btn.GetComponentInChildren<Image>().sprite = choice.icon;
        btn.transform.GetChild(1).GetComponent<Image>().sprite = choice.icon;
        btn.GetComponentInChildren<TextMeshProUGUI>().text = choice.weaponName;

        btn.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (inventory.HasWeapon(choice))
                inventory.LevelUpWeapon(choice);
            else
                inventory.AddWeapon(choice, inventory.transform.Find("WeaponMount"));

            ClosePanel();
        });
    }

    void MakePowerUpChoice()
    {
        PowerUpData choice = allPowerUps[Random.Range(0, allPowerUps.Count)];
        var btn = Instantiate(choiceButtonPrefab, choiceParent);
        btn.GetComponentInChildren<Image>().sprite = choice.icon;
        btn.GetComponentInChildren<TextMeshProUGUI>().text = choice.powerName;

        btn.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (inventory.HasPowerUp(choice))
                inventory.LevelUpPowerUp(choice);
            else
                inventory.AddPowerUp(choice);

            ClosePanel();
        });
    }

    void ClosePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
