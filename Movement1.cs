using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public float turnSpeed = 100f; // Turning speed
    public float jumpForce = 5f; // Jump force
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle movement
        float moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, 0, moveVertical);

        // Handle turning
        float turnHorizontal = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turnHorizontal, 0);

        // Handle jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
