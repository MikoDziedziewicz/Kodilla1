using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    private BallComponent followTarget;
    private Vector3 originalPosition;

    private Rigidbody2D ballRigidbody;
    private BallComponent ball;

    float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        BallComponent component = FindObjectOfType<BallComponent>();
        ball = FindObjectOfType<BallComponent>();
        ballRigidbody = ball.GetComponent<Rigidbody2D>();

        followTarget = FindObjectOfType<BallComponent>();

        

        originalPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        if (!followTarget.IsSimulated())
            return;

        speed = ballRigidbody.velocity.magnitude;
        float distance = speed * Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position, originalPosition + followTarget.transform.position, distance);
    }
}
