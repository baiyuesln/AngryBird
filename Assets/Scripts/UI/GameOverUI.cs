using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private Animator animator;

    private int starCount = 0;

    public GameObject failPig;

    public StarUI starUI1;
    public StarUI starUI2;
    public StarUI starUI3;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Show(int starCount)//0 1 2 3
    {
        animator.SetTrigger("isShow");
        this.starCount = starCount;
    }

    public void ShowStar()
    {
        if(starCount == 0)
        {
            failPig.SetActive(true);
        }
        if(starCount >= 1)
        {
            starUI1.Show();
        }
        if( starCount >= 2)
        {
            starUI2.Show();
        }
        if(starCount >= 3)
        {
            starUI3.Show();
        }
    }

    public void OnRestartButtonClick()
    {
        Manager.Instance.RestartLevel();
    }

    public void OnLevelListButtonClick()
    {
        Manager.Instance.LevelList();
    }
}
