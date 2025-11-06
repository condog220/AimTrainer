using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static float timer;
    [SerializeField] GameObject timerText;
    [SerializeField] GameObject resultScreen;
    [SerializeField] GameObject scoreResult;
    [SerializeField] GameObject accuracyResult;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Awake()
    {
        timer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        CountDownTimer();

    }

    public void CountDownTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.GetComponent<TMPro.TextMeshProUGUI>().text = Convert.ToInt32(timer % 60).ToString();
        }
        if (timer <= 0)
        {
            timer = 0;
            resultsScreen();
        }


    }

    public void resultsScreen()
    {
        resultScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        scoreResult.GetComponent<TMPro.TextMeshProUGUI>().text = ScoreManager.instance.getScore().ToString();
        accuracyResult.GetComponent<TMPro.TextMeshProUGUI>().text = ScoreManager.instance.getAccuracy().ToString("F2") + "%";

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        resultScreen.SetActive(false);

        timer = 30f;

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.resetScore();
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }
}
