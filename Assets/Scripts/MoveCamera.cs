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
        private float userSens;
        [SerializeField] private float sensMultiplier;
        bool locked = true;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        dotperinch = 16.3286f;
        radsPerDot = math.TAU / dotperinch;
        userSens = 1.2f;
        sensMultiplier = userSens * radsPerDot;
    }

    // Update is called once per frame
    void Update()
    {
        if(locked){
            rotationY += Input.GetAxis("Mouse X") * sensMultiplier;
            rotationX -=  Input.GetAxis("Mouse Y") * sensMultiplier;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }


        if(Input.GetKey(KeyCode.Escape)){
            if(locked == true){
                locked = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else{
                locked = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
