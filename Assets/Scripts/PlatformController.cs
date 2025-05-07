using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float moveLimit = 3f;
    public float speed = 1f;
    private float initialX;
    private float xLimit;
    private int direction = 1;


    void Start()
    {
        initialX = transform.position.x;
        xLimit = initialX + moveLimit;
    }

    void Update()
    {
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);

        if (transform.position.x < initialX || transform.position.x > xLimit)
        {
            direction *= -1;
        }
    }
}
