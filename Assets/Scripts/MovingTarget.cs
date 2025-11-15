using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    private float direction = 1f; // 1 for right, -1 for left
    private float timer = 0f;
    private float changeInterval;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        changeInterval = Random.Range(0.5f, 4f);
        
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = transform.position.x + direction * Time.deltaTime * 3f;

        timer += Time.deltaTime;

        if(timer >= changeInterval)
        {
            direction *= -1f;

            timer = 0f;
            changeInterval = Random.Range(0.5f, 4f);
            
        }

        transform.position = new Vector3(xValue, transform.position.y, transform.position.z);

    }

    public void Initialize(float inpDirection)
    {
        direction = inpDirection;
    }
}
