using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 5f;
    private float maxZOffset = 100f;//1f;
    private Rigidbody rb;
    private Vector3 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal * movementSpeed, 0f, 0f);
        Vector3 newPosition = transform.position + movement * Time.deltaTime;
        newPosition.z = Mathf.Clamp(newPosition.z, startPosition.z - maxZOffset, startPosition.z + maxZOffset);
        rb.MovePosition(newPosition);
    }
}