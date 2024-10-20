using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
        float rotationX = 0f;
        float rotationY = 0f;
        [SerializeField] private Vector2 sensitivity = Vector2.one * 720f;
        bool locked = true;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity.x;
        rotationX += Input.GetAxis("Mouse Y") * Time.deltaTime * -1 * sensitivity.y;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

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
