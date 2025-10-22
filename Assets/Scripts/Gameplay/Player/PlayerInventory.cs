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
        public PowerUpEffect effect;
        public int level = 0;
    }

    public int maxWeapons = 5;
    public int maxPowerUps = 5;

    public List<WeaponSlot> weapons = new List<WeaponSlot>();
    public List<PowerUpSlot> powerUps = new List<PowerUpSlot>();

    public bool HasWeapon(WeaponData data) => weapons.Exists(w => w.data == data);
    public bool HasPowerUp(PowerUpEffect data) => powerUps.Exists(p => p.effect == data);

    public bool AddWeapon(WeaponData data, Transform mount)
    {
        if (weapons.Count >= maxWeapons) return false;

        var slot = new WeaponSlot { data = data, level = 1 };
        GameObject inst = Instantiate(data.weaponPrefab, mount);
        slot.instance = inst;
        weapons.Add(slot);

        // ✅ Apply all current power-up effects to the new weapon
        foreach (var p in powerUps)
        {
            if (p.effect != null)
                p.effect.Apply(this, p.level);
        }

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

    public bool AddPowerUp(PowerUpEffect effect)
    {
        if (powerUps.Count >= maxPowerUps) return false;
        var slot = new PowerUpSlot { effect = effect, level = 1 };
        powerUps.Add(slot);
        effect.Apply(this, 1);
        return true;
    }

    public bool LevelUpPowerUp(PowerUpEffect effect)
    {
        var slot = powerUps.Find(p => p.effect == effect);
        if (slot != null && slot.level < slot.effect.maxLevel)
        {
            slot.level++;
            slot.effect.Apply(this, slot.level);
            return true;
        }
        return false;
    }

}

