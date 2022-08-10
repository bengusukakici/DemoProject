using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                //new GameObject("Canvas").AddComponent<UIManager>();
            }
            return instance;
        }
    }


    [Header("Start Panel")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject startButton;

    [Header("In Game Panel")]
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject pie;
    [SerializeField] private GameObject joystick;

    [Header("Fail Panel")]
    public GameObject failPanel;
    [SerializeField] private GameObject failButton;

    [Header("Victory Panel")]
    public GameObject victoryPanel;
    [SerializeField] private GameObject nextButton;

    [Header("Button Scale Animation Settings")]
    [SerializeField] float buttonScaleAnimationSpeed = 0.3f;
    [SerializeField] float buttonScaleAnimationLength = 0.2f;
    [SerializeField] float buttonScaleAnimationStartPosition = 0.8f;

    PlayerMovement playerMovement;

    private void Awake()
    {
        instance = this;
        victoryPanel.SetActive(false);
        failPanel.SetActive(false);
        pie.SetActive(false);
        joystick.SetActive(false);
    }

    void Start()
    {
        levelText.text = "Level" + PlayerPrefs.GetInt("lastLevel", 1).ToString();
        playerMovement = GameManager.instance.player.GetComponent<PlayerMovement>();
        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
        InvokeRepeating("StartPanel", 0.00f, 0.01f);
    }
    public void Update()
    {
        ScaleButton(startButton);
        ScaleButton(nextButton);
        ScaleButton(failButton);
        if (GameManager.instance.isFinish)
        {
            pie.SetActive(true);
        }
        if (GameManager.instance.isRotatingPlatform)
        {
            joystick.SetActive(true);
        }

    }
    public void StartPanel()
    {
        startPanel.SetActive(true);
        playerMovement.enabled = false;
        foreach(NavMesh script in GameManager.instance.opponentScript)
        {
            script.enabled = false;
        }
        CancelInvoke("StartPanel");
    }
    public void StartLevel()
    {
        startPanel.SetActive(false);
        playerMovement.enabled = true; 
        foreach (NavMesh script in GameManager.instance.opponentScript)
        {
            script.enabled = true;
        }
    }
    
    public void NextLevel()
    {
        LevelManager.Instance.NextLevel();
    }
    public void RestartLevel()
    {
        LevelManager.Instance.LevelRestart();
    }
    
    public void OpenStore()
    {

    }
    void ScaleButton(GameObject button)
    {
        float t = Time.time * buttonScaleAnimationSpeed;
        button.transform.localScale = new Vector3(Mathf.PingPong(t, buttonScaleAnimationLength) + buttonScaleAnimationStartPosition, Mathf.PingPong(t, buttonScaleAnimationLength) + buttonScaleAnimationStartPosition, 1);
    }


}