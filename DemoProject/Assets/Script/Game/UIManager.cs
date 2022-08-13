using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.AI;

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
    [SerializeField] public GameObject startPanel;
    [SerializeField] private GameObject startButton;

    [Header("In Game Panel")]
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] public TextMeshProUGUI orderText;
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
    PlayerOrder playerorder;
    int order;

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
        playerMovement = GameManager.instance.character.GetComponent<PlayerMovement>();
        playerorder = GameManager.instance.character.GetComponent<PlayerOrder>();
        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
        InvokeRepeating("StartPanel", 0.00f, 0.001f);
    }
    public void FixedUpdate()
    {
        ScaleButton(startButton);
        ScaleButton(nextButton);
        ScaleButton(failButton);
        if (GameManager.instance.isPaintFinish)
        {
            pie.SetActive(true);
        }
        if (GameManager.instance.isFinish)
        {
            joystick.SetActive(true);
        }
    }
    public void StartPanel()
    {
        Time.timeScale = 1;
        startPanel.SetActive(true);
        playerMovement.enabled = false;
        foreach (NavMesh script in GameManager.instance.opponentScript)
        {
            script.animation.stoprun();
            script.enabled = false;
            script.GetComponentInParent<NavMeshAgent>().enabled = false;
        }
        CancelInvoke("StartPanel");
    }
    public void StartLevel()
    {
        startPanel.SetActive(false);
        playerMovement.enabled = true;
        foreach (NavMesh script in GameManager.instance.opponentScript)
        {
            script.animation.run();
            script.enabled = true;
            script.GetComponentInParent<NavMeshAgent>().enabled = true;
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

    void ScaleButton(GameObject button)
    {
        float t = Time.time * buttonScaleAnimationSpeed;
        button.transform.localScale = new Vector3(Mathf.PingPong(t, buttonScaleAnimationLength) + buttonScaleAnimationStartPosition, Mathf.PingPong(t, buttonScaleAnimationLength) + buttonScaleAnimationStartPosition, 1);
    }
    public void Order()
    {
        if (!GameManager.instance.isFinishLine)
        {
            order = GameManager.instance.distance.BinarySearch(playerorder.GetDistance()) + 1;
            if (order > 0)
            {
                orderText.text = order.ToString() + ".";
            }
        }
    }
}