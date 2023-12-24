using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//控制游戏流程
public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }
    public GameSO gameSO;

    private Brid[] bridList;
    private int index = -1;
    private int pigTotalCount;
    private int pigDeadCount;
    private FollowTarget cameraFollowTarget;

    public GameOverUI gameOverUI;
    private void Awake()
    {
        Instance = this;
        pigDeadCount = 0;
        LoadSelectedLevel();
    }
    // Start is called before the first frame update
    void Start()
    {
        pigTotalCount = FindObjectsOfType<Pig>().Length;
        bridList = FindObjectsOfType<Brid>();
        cameraFollowTarget = Camera.main.GetComponent<FollowTarget>();
        LoadNextBird();
    }

    private void LoadSelectedLevel()
    {
        Time.timeScale = 1.0f;
        int mapID = gameSO.selectedMapID;
        int levelID = gameSO.selectedLevelID;
        GameObject levelPrefab = Resources.Load<GameObject>("Map" + mapID + "/" + "Level" + levelID);
        GameObject.Instantiate(levelPrefab);
    }

    public void LoadNextBird()
    {
        index++;
        if(index >= bridList.Length)
        {
            GameOver();
        }
        else
        {
            bridList[index].GoState(SlingShoot.Instance.getCenterPosition());
            cameraFollowTarget.SetTarget(bridList[index].transform);
        }
    }


    private void GameOver()
    {
        int starCount = 0;
        float pigDeadPercent = pigDeadCount*1f / pigTotalCount;
        
        if (pigDeadPercent > 0.99)
        {
            starCount = 3;
        }
        else if (pigDeadPercent > 0.66)
        {
            starCount = 2;
        }
        else if(pigDeadPercent > 0.33f)
        {
            starCount = 1;
        }
        gameOverUI.Show(starCount);
        gameSO.UpdateLevel(starCount);
    }

    public void OnPigDead()
    {
        pigDeadCount++;
        if(pigDeadCount >= pigTotalCount)
        {
            GameOver();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelList()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    
}
