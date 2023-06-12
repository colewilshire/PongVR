using UnityEngine;

public class BallController : MonoBehaviour
{
    private float maxSkew = 30f;
    private float initialSpeed = 5f;
    private float currentSpeed;
    private Vector3 direction;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = transform.forward;
        currentSpeed = initialSpeed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * currentSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float distanceFromCenter = collision.GetContact(0).point.x - collision.transform.position.x;
            float percentageDistance = distanceFromCenter / (collision.transform.localScale.x / 2f);
            float roundedPercentageDistance = Mathf.Round(percentageDistance * 10f) / 10f;
            Quaternion skewRotation = Quaternion.Euler(0f, maxSkew * roundedPercentageDistance, 0f);

            //if (roundedPercentageDistance > .3 || roundedPercentageDistance < .3)
            //{
            direction = skewRotation * collision.transform.forward;
            
            if (collision.transform.rotation.y != 0)
            {
                direction = Vector3.Scale(direction, new Vector3(-1, 1, 1));
            }
            //}
        }
        else
        {
            direction = Vector3.Reflect(direction, collision.GetContact(0).normal);
        }
    }
}
