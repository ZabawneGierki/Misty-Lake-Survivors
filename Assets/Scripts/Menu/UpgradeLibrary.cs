using System.Collections.Generic;
using UnityEngine;

public static class UpgradeLibrary
{
    public static List<(string name, Sprite icon, int maxLevel)> GetAllUpgrades()
    {
        // You could later move this to ScriptableObjects
        return new()
        {
            ("Speed", Resources.Load<Sprite>("Icons/Speed"), 3),
            ("Damage", Resources.Load<Sprite>("Icons/Damage"), 5),
        };
    }
}