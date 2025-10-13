using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("isOn", isOn);
        }
    }
}
