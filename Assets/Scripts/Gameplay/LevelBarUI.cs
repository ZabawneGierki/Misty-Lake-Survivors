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


    private IEnumerator Start()
    {
        // Wait one frame to ensure PlayerLevel is initialized
        yield return null;
        while (playerLevel == null)
        {
            yield return new WaitForSeconds(0.5f);
            playerLevel = FindObjectOfType<PlayerLevel>();
        }
    }
}
