using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class UpgradeInfo
{
    public string upgradeName;
    public Sprite upgradeIcon;
    public int upgradeCost;
    public string upgradeDescription;
    public int upgradeLevel;
    // Add other upgrade-related fields here
}
public class UpgradesMenu : MonoBehaviour
{

    [SerializeField] private Transform upgradesMenuGrid;
    [SerializeField] private GameObject upgradeButtonPrefab;

    public List<UpgradeData> availableUpgrades;


}
