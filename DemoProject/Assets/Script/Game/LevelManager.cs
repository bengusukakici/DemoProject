using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance = null;

    private int lastLevel = 0;
    private int _isFirstLevelFirstlyCompleted;
    int _tryNum;

    [SerializeField] private LevelSettings levelSettings = null;

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                new GameObject("LevelManager").AddComponent<LevelManager>();
            }
            return instance;
        }
    }
    void Awake()
    {
        instance = this;
        levelSettings = Resources.Load<LevelSettings>("LevelSettings");
        lastLevel = PlayerPrefs.GetInt("lastLevel", 1);
        _tryNum = PlayerPrefs.GetInt("tryNum", 1);
        _isFirstLevelFirstlyCompleted = PlayerPrefs.GetInt("firstLevelCompleted", 0);
    }

    public void LevelComplete()
    {
        if (_isFirstLevelFirstlyCompleted == 0)
        {
            _isFirstLevelFirstlyCompleted = 1;
            PlayerPrefs.SetInt("firstLevelCompleted", _isFirstLevelFirstlyCompleted);
        }
        Time.timeScale = 0;
        UIManager.Instance.victoryPanel.SetActive(true);
    }
    public void LevelFailed()
    {
        Time.timeScale = 0;
        UIManager.Instance.failPanel.SetActive(true);
    }
    public void LevelRestart()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("tryNum", _tryNum++);
        //StartCoroutine(AsyncSceneLoader(SceneManager.GetActiveScene().buildIndex));
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(levelSettings.LevelArray[(lastLevel % levelSettings.levelCount)]);
        lastLevel++;
        PlayerPrefs.SetInt("lastLevel", lastLevel);
    }

}
