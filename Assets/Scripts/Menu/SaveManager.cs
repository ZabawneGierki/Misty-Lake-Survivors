using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;


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

    public static string saveFilePath;

    public List<PermanentUpgrade> permanentUpgrades = new List<PermanentUpgrade>(); 


    private void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/savefile.json";
        // create save file if it doesn't exist
        if (!System.IO.File.Exists(saveFilePath))
        {
            System.IO.File.WriteAllText(saveFilePath, "{}");

        }
    }
    private void Start()
    {
        
        SavePermantUpgrade(new PermanentUpgrade { upgradeName = PermanentUpgradeName.MaxHealth, currentLevel = 1 });

        Debug.Log("Save file path: " + saveFilePath);



    }
    public static void SavePermantUpgrade(PermanentUpgrade upgrade)
    {
         JsonUtility.ToJson(upgrade);

        //check if upgrade already exists in file
        PermanentUpgrade[] existingUpgrades = System.IO.File.ReadAllLines(saveFilePath)
            .Select(line => JsonUtility.FromJson<PermanentUpgrade>(line))
            .Where(u => u.upgradeName == upgrade.upgradeName)
            .ToArray();
        if (existingUpgrades.Length > 0)
        {
             foreach (var existingUpgrade in existingUpgrades)
            {
                
            }

        }




        System.IO.File.AppendAllText(saveFilePath, JsonUtility.ToJson(upgrade) + "\n");
    }


}
