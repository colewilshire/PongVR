using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform ball; // Reference to the ball
    private float speed = 5f; // Speed of the AI paddle
    private float lastBallX; // The last known x-position of the ball
    private float offset; // The random offset for intercepting the ball
    private BoxCollider boxCollider; // The collider attached to the paddle

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>(); // Assuming a 3D BoxCollider. If you're using a 2D game, use BoxCollider2D instead.
        lastBallX = ball.position.x;
        UpdateOffset();
    }

    void Update()
    {
        // If the ball's x-position has changed significantly, update the offset
        if (Mathf.Abs(ball.position.x - lastBallX) > 1) // Change the threshold as needed
        {
            lastBallX = ball.position.x;
            UpdateOffset();
        }

        // The target position is the ball's x-position plus the offset, but the AI paddle's own y and z
        Vector3 targetPosition = new Vector3(ball.position.x + offset, transform.position.y, transform.position.z);

        // Move the AI paddle towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void UpdateOffset()
    {
        // The offset is a random value between -paddleWidth/2 and paddleWidth/2
        float paddleWidth = boxCollider.bounds.size.x;
        offset = Random.Range(-paddleWidth/2, paddleWidth/2);
    }
}
