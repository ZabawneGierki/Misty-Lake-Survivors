using UnityEngine;

public abstract class PowerUpEffect : ScriptableObject
{
    public string powerName;
    public Sprite icon;
    [TextArea] public string[] levelDescriptions; // description per level
    public int maxLevel = 5;

    public bool IsMaxed(int currentLevel) => currentLevel >= maxLevel;
    public string GetDescription(int level)
    {
        if (level - 1 < levelDescriptions.Length)
            return levelDescriptions[level - 1];
        return levelDescriptions.Length > 0 ? levelDescriptions[^1] : "";
    }

    public abstract void Apply(PlayerInventory inventory, int newLevel);
}
