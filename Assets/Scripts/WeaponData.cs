using UnityEngine;

[CreateAssetMenu(menuName = "BulletHeaven/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Sprite icon;
    public string description;
    public GameObject weaponPrefab;
    public int maxLevel = 5;
}

