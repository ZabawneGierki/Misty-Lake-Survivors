using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBarUI : MonoBehaviour
{
    public PlayerLevel playerLevel;
    public Image fillImage;

    void Update()
    {
        if (playerLevel != null)
        {
            fillImage.fillAmount = playerLevel.GetXPPercent();
        }
    }
}
