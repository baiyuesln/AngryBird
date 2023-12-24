using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public GameObject unLockGo;
    public GameObject lockGo;
    public TextMeshProUGUI levelNumberText;
    public GameObject start0Go;
    public GameObject start1Go;
    public GameObject start2Go;
    public GameObject start3Go;

    private MapLevelUI mapLevelUI;
    private int levelID;

    public void Show(int starCount,int levelID,MapLevelUI mapLevelUI)
    {
        this.mapLevelUI = mapLevelUI;
        this.levelID = levelID;
        levelNumberText.text = levelID.ToString();
        start0Go.SetActive(false);
        start1Go.SetActive(false);
        start2Go.SetActive(false);
        start3Go.SetActive(false);

        if(starCount <=-1)
        {
            unLockGo.SetActive(false);
            lockGo.SetActive(true);
        }
        else
        {
            lockGo.SetActive(false);
            unLockGo.SetActive(true) ;
            if(starCount == 3)
            {
                start3Go.SetActive(true);
            }else if(starCount == 2)
            {
                start2Go.SetActive(true);
            }
            else if(starCount == 1)
            {
                start1Go.SetActive(true);
            }
            else if(starCount == 0)
            {
                start0Go.SetActive(true);
            }
        }
    }

    public void OnClick()
    {
        mapLevelUI.OnLevelButtonClick(levelID);
    }
}
