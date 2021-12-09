using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    public Animator animator;
    public void fade()
    {
        
        animator.SetTrigger("Fade");
    }
    
}
