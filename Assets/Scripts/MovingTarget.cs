using UnityEngine;

public class MovingTarget : MonoBehaviour
{

    private float max = 10f;
    private float min = -10f;
    private float direction = 1f; // 1 for right, -1 for left

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = transform.position.x + direction * Time.deltaTime * 3f;

        if (xValue >= max)
        {
            direction = -1f;
            Debug.Log("Changing direction to left");
        }
        else if (xValue <= min)
        {
            direction = 1f;
            Debug.Log("Changing direction to right");
        }

        transform.position = new Vector3(xValue, transform.position.y, transform.position.z);

    }

    public void Initialize(float inpDirection)
    {
        direction = inpDirection;
    }
}
