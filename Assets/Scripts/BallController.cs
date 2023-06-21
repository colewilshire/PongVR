using UnityEngine;

public class BallController : MonoBehaviour
{
    private float maxSkew = 30f;
    private float fireDelay = 1f;
    private float initialSpeed = 5f;
    private float currentSpeed;
    private Vector3 direction;
    private Rigidbody rb;
    private AudioSource[] audioSources;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSources = GetComponents<AudioSource>();

        ResetBall();
    }

    private void FixedUpdate()
    {
        rb.angularVelocity = Vector3.zero;
        rb.MovePosition(rb.position + direction * currentSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision);
    }

    private void Bounce(Collision collision)
    {
        ContactPoint pointOfContact = collision.GetContact(0);

        if (collision.gameObject.CompareTag("Player"))
        {
            // When hitting a player, the ball will bounce in the direction of the side it hit, with its angle scaled by the distance from the center of the player
            Transform hitObjectTransform = collision.transform;
            float distanceFromCenter = pointOfContact.point.x - hitObjectTransform.position.x;
            float percentageDistance = distanceFromCenter / (hitObjectTransform.localScale.x / 2f);
            float roundedPercentageDistance = Mathf.Round(percentageDistance * 10f) / 10f;
            Quaternion skewRotation = Quaternion.Euler(0f, maxSkew * roundedPercentageDistance, 0f);

            direction = skewRotation * hitObjectTransform.forward;
            
            // Reverse x-direction if player object is rotated on the y-axis
            if (hitObjectTransform.rotation.y != 0)
            {
                direction = Vector3.Scale(direction, new Vector3(-1, 1, 1));
            }

            PlaySound(0);
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            ResetBall();
            PlaySound(1);
        }
        else
        {
            direction = Vector3.Reflect(direction, pointOfContact.normal);
            PlaySound(1);
        }
    }

    private void ResetBall()
    {
        direction = Vector3.zero;
        transform.position = Vector3.zero;

        Invoke(nameof(FireBall), fireDelay);
    }

    private void FireBall()
    {
        int randomSign = Random.Range(0, 2) * 2 - 1;

        direction = transform.forward * randomSign;
        currentSpeed = initialSpeed;
    }

    private void PlaySound(int soundIndex = 0)
    {
        audioSources[soundIndex].Play();
    }
}
