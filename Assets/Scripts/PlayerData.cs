using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum CharacterNames
{
        Reimu,
        Marisa,
        Cirno,
        Daiyousei,
}
public static class PlayerData  
{
     public static CharacterNames selectedcharacterName = CharacterNames.Reimu;
    public static int selectedLevel = 1;
}
