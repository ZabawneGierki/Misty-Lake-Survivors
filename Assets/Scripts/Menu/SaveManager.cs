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

      private string saveFilePath = Application.persistentDataPath + "/upgrades.json";


    private void Awake()
    {
        // create save file if it doesn't exist
        if (!System.IO.File.Exists(saveFilePath))
        {
            System.IO.File.WriteAllText(saveFilePath, "{}");
            JsonUtility.ToJson(new PermanentUpgrade());
        }


    }
    public static void SavePermantUpgrade(PermanentUpgrade upgrade)
    {
         
    }


}
