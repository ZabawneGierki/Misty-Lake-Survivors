using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    // play an animation and destroy the object after the animation is done
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(gameObject, animationLength);
        }
        else
        {
            Destroy(gameObject, 1f); // default to 1 second if no animator found
        }
    }
}
