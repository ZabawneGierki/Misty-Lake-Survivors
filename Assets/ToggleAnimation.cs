using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ToggleAnimation : MonoBehaviour
{
    Image BackgroundImage;
    private void Awake()
    {
        BackgroundImage = GetComponentInParent<Image>();
        Debug.Log(BackgroundImage.name);
    }
    public void AnimateToggle(bool isOn)
    {
        if (isOn)
        {
            BackgroundImage.DOColor(new Color(1f, 1f, 1f, 0.5f), 0.2f);
        }
        else
        {
            BackgroundImage.DOColor(new Color(1f, 1f, 1f, 0.2f), 0.2f);
        }
    }
}
