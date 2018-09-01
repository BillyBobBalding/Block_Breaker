using UnityEngine;

public class Ball1 : MonoBehaviour
{

    //config parameters

    [SerializeField] Paddle1 paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = .2f;
    [SerializeField] float minVelocity = 15f;


    //state

    Vector2 paddleToBallVector;
    bool hasStarted = false;


    //cashed component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;



	// Use this for initialization
	void Start ()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        //bounceHeight = Mathf.Clamp(yVelocity, 1, 10);
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

        // Check if ball falls
        if (hasStarted && transform.position.y < -2)
        {
            hasStarted = !hasStarted;
        }

        // set min speed of ball
        if (myRigidBody2D.velocity.magnitude < minVelocity) myRigidBody2D.velocity = myRigidBody2D.velocity.normalized * minVelocity;
        /*
        // create multiple balls on paddle
        if(hasStarted)
        {
            instantiate ball1
            LockBallToPaddle();
        }
        */
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
        
    }

    private void LockBallToPaddle()
    {
            Vector2 paddlePoss = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePoss + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
