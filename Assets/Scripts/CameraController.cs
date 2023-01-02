using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    private BallComponent followTarget;
    private Vector3 originalPosition;

    private Rigidbody2D ballRigidbody;
    private BallComponent ball;




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

        float speed = ballRigidbody.velocity.magnitude;
        transform.position = Vector3.MoveTowards(transform.position, originalPosition + followTarget.transform.position, speed * Time.deltaTime);
    }
}
