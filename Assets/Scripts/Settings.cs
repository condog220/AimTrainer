using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public static float volume = 1.0f;
    public static float sensitivity = 1.0f;

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] GameObject volumeVal;
    [SerializeField] GameObject sensitivityVal;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volumeSlider.value = volume;
        sensitivitySlider.value = sensitivity;
        volumeVal.GetComponent<Text>().text = (volume * 100).ToString("0");
        sensitivityVal.GetComponent<Text>().text = sensitivity.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float vol)
    {
        volume = vol;
        volumeVal.GetComponent<Text>().text = (volume * 100).ToString("0");
    }

    public void SetSensitivity(float sens)
    {
        sensitivity = sens;
        sensitivityVal.GetComponent<Text>().text = sensitivity.ToString("0.00");
    }
}
