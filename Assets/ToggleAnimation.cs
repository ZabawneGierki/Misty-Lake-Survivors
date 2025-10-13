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
        Toggle toggle = GetComponentInChildren<Toggle>();

        toggle.onValueChanged.AddListener(AnimateToggle);
        toggle.isOn = false;
        // Initialize the background image alpha based on the initial toggle state
        BackgroundImage.DOFade(0.5f, 0.2f);
    }


     
    public void AnimateToggle(bool isOn)
    {
        if (isOn)
        {
            BackgroundImage.DOFade(1f, 0.2f);
        }
        else
        {
            BackgroundImage.DOFade(0.5f, 0.2f);
        }
    }
}
