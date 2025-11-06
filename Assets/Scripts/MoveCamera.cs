using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
        float rotationX = 0f;
        float rotationY = 0f;
        float dotperinch;
        private float radsPerDot;
        public float userSens;
        [SerializeField] private float sensMultiplier;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        dotperinch = 16.3286f;
        radsPerDot = math.TAU / dotperinch;
        userSens = SettingsManager.sensitivity;
        sensMultiplier = userSens * radsPerDot;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseScript.isPaused)
        {
            return;
        }

        rotationY += Input.GetAxisRaw("Mouse X") * sensMultiplier/0.4f * Time.deltaTime;
        rotationX -=  Input.GetAxisRaw("Mouse Y") * sensMultiplier/0.4f * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
