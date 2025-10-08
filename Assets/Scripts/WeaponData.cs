using UnityEngine;

[CreateAssetMenu(menuName = "BulletHeaven/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Sprite icon;
    [TextArea]public string[] descriptions; //description per level
    public GameObject weaponPrefab;
    public int maxLevel = 5;

    public string GetDescription(int level)
    {
        if (level - 1 < descriptions.Length)
            return descriptions[level - 1];
        return descriptions.Length > 0 ? descriptions[^1] : "";
    }
}

