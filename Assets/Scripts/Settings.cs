using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public static float sensitivity = 1.0f;
    public static float volume = 1.0f;

    public Slider sensSlider;
    public GameObject sensValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sensSlider.value = sensitivity;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onChangeSens(float value)
    {
        sensitivity = value;
        sensValue.GetComponent<Text>().text = sensitivity.ToString();

    }
}
