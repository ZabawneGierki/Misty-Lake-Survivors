using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image slider;
    public Vector3 offset = new Vector3(0, 1.5f, 0); // above head

    public void SetHealth(float current, float max)
    {
        slider.fillAmount = current / max;
    }
     
}
