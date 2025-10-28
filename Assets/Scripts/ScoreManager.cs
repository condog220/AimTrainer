using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    private int score = 0;
    private float accuracy = 0;
    private int totalShots = 0;
    private int totalHits = 0;

    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject accuracyText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore()
    {
        score += 200;
        scoreText.GetComponent<Text>().text = score.ToString();


    }

    public void updateAccuracy()
    {
        if(totalShots == 0) {
            accuracy = 0;
        }
        else
        {
            accuracy = ((float)totalHits / (float)totalShots) * 100f;
            accuracyText.GetComponent<Text>().text = accuracy.ToString("F2") + "%";
        }
    }

    public void registerShot(bool hit)
    {
        totalShots++;
        if (hit)
        {
            totalHits++;
        }

        updateAccuracy();

    }
}
