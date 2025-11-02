using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float timer;
    [SerializeField] GameObject timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 30f;
        
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
            timerText.GetComponent<UnityEngine.UI.Text>().text = Convert.ToInt32(timer % 60).ToString();
        }
    }


}
