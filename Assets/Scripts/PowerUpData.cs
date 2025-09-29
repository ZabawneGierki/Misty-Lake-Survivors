using UnityEngine;

[CreateAssetMenu(menuName = "BulletHeaven/PowerUp")]
public class PowerUpData : ScriptableObject
{
    public string powerName;
    public Sprite icon;
    public string description;
    public int maxLevel = 5;
}
