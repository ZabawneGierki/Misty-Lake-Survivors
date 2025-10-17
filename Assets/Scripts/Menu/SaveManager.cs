using UnityEngine;

[System.Serializable]
public enum PermanentUpgradeName
{
    MaxHealth,
    Damage,
    Speed,
    FireRate,
    ShieldCapacity,
    HealthRegen
}

[System.Serializable]

public class PermanentUpgrade
{
    public PermanentUpgradeName upgradeName;
    public int currentLevel;

}
public   class SaveManager: MonoBehaviour
{

    static private string saveFilePath = Application.persistentDataPath + "/upgrades.json";


    private void Awake()
    {
        // create save file if it doesn't exist


    }
    public static void SavePermantUpgrade(PermanentUpgrade upgrade)
    {
         
    }


}
