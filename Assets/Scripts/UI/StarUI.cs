using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUI : MonoBehaviour
{
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public void Show()
    {
        m_Animator.SetTrigger("isShow");
    }
}
