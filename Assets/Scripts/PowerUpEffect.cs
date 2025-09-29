using UnityEngine;

public abstract class PowerUpEffect : ScriptableObject
{
    public string powerName;
    public Sprite icon;
    public string description;
    public int maxLevel = 5;

    // Called when this power-up is picked or leveled up.
    public abstract void Apply(PlayerInventory inventory, int newLevel);
}
