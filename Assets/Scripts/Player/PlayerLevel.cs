using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{
    [Header("XP Settings")]
    public int level = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 10;

    [Header("Events")]
    public static UnityEvent<int> OnLevelUp; // sends new level to listeners

    public void AddXP(int amount)
    {
        currentXP += amount;
        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentXP -= xpToNextLevel;
        level++;

        // You can make the XP curve scale
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.2f);

        OnLevelUp?.Invoke(level);
    }

    public float GetXPPercent()
    {
        return (float)currentXP / xpToNextLevel;
    }
}
