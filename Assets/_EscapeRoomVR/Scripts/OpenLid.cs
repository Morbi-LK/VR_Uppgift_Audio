using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLid : MonoBehaviour
{
    [SerializeField] private Animator _lidAnimator;

    public void PlayOpenLidAnimation()
    {
        _lidAnimator.SetBool("OpenLid", true);
    }
}
