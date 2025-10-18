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
        
        

        Debug.Log("Save file path: " + saveFilePath);



    }
    public static void SavePermantUpgrade(PermanentUpgrade upgrade)
    {
        
       
    }


}
