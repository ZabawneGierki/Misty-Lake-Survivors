using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [System.Serializable]
    public class WeaponSlot
    {
        public WeaponData data;
        public int level = 0;
        public GameObject instance; // actual weapon object under WeaponMount
    }

    [System.Serializable]
    public class PowerUpSlot
    {
        public PowerUpData data;
        public int level = 0;
    }

    public int maxWeapons = 5;
    public int maxPowerUps = 5;

    public List<WeaponSlot> weapons = new List<WeaponSlot>();
    public List<PowerUpSlot> powerUps = new List<PowerUpSlot>();

    public bool HasWeapon(WeaponData data) => weapons.Exists(w => w.data == data);
    public bool HasPowerUp(PowerUpData data) => powerUps.Exists(p => p.data == data);

    public bool AddWeapon(WeaponData data, Transform mount)
    {
        if (weapons.Count >= maxWeapons) return false;
        var slot = new WeaponSlot { data = data, level = 1 };
        GameObject inst = Instantiate(data.weaponPrefab, mount);
        slot.instance = inst;
        weapons.Add(slot);
        return true;
    }

    public bool LevelUpWeapon(WeaponData data)
    {
        var slot = weapons.Find(w => w.data == data);
        if (slot != null && slot.level < slot.data.maxLevel)
        {
            slot.level++;
            slot.instance.GetComponent<WeaponBase>()?.LevelUp();
            return true;
        }
        return false;
    }

    public bool AddPowerUp(PowerUpData data)
    {
        if (powerUps.Count >= maxPowerUps) return false;
        var slot = new PowerUpSlot { data = data, level = 1 };
        powerUps.Add(slot);
        return true;
    }

    public bool LevelUpPowerUp(PowerUpData data)
    {
        var slot = powerUps.Find(p => p.data == data);
        if (slot != null && slot.level < slot.data.maxLevel)
        {
            slot.level++;
            // apply effects here (damage multiplier, cooldown, etc.)
            return true;
        }
        return false;
    }
}

