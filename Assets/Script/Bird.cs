using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    private Rigidbody2D M_birdRB;
    private Animator M_birdAnimator;

    private bool M_isAlive = false;
    private Vector3 M_initialBirdPosition;
    private Quaternion M_initialBirdRotation;

    [SerializeField] private float M_maxJumpVelocity = 5f;
    [SerializeField] private float M_maxUpwardAngle = 45f;     
    [SerializeField] private float M_maxDownwardAngle = -90f;  
    [SerializeField] private float M_rotationLerpSpeed = 5f;
    [SerializeField] private float M_gravityScale = 3f;
    

    void Start()
    {
        M_initialBirdPosition = transform.position;
        M_initialBirdRotation = transform.rotation;
        M_birdAnimator = GetComponent<Animator>();
        M_birdRB = GetComponent<Rigidbody2D>();
        M_birdRB.gravityScale = 0f; 
    }

    void Update()
    {
        if (M_isAlive)
        {
            if (Input.GetButton("Jump") || Input.GetButton("Fire1"))
            {
                Jump();
            }
            RotateBasedOnVelocity();
        }
    }

    //Summary
    //Resets jump trigger in animator

    private void ResetJumpTrigger()
    {
        M_birdAnimator.ResetTrigger("Jump");
    }

    //Summary
    // give the player upwards velocity, sets animation trigger to jump
    private void Jump()
    {
        M_birdRB.linearVelocity = Vector2.up * M_maxJumpVelocity;
        M_birdAnimator.SetTrigger("Jump");
    }

    //Summary
    // calculates and sets the birds rotation to desired angle based on current velocity
    void RotateBasedOnVelocity()
    {
        float verticalVelocity = M_birdRB.linearVelocity.y;
        float tempAngle = 0f;
        float targetAngle = 0f;

        if (verticalVelocity > 0)
        {
            tempAngle = Mathf.InverseLerp(0, M_maxJumpVelocity, verticalVelocity);
            targetAngle = Mathf.Lerp(0, M_maxUpwardAngle, tempAngle);
        }
        else
        {
            tempAngle = Mathf.InverseLerp(0, -M_maxJumpVelocity, verticalVelocity);
            if (tempAngle < 0)
            {
                tempAngle = 0;
            }
            targetAngle = Mathf.Lerp(0, M_maxDownwardAngle, tempAngle);
        }
        
        float currentZ = transform.eulerAngles.z;
        if (currentZ > 180)
        {
            currentZ -= 360;
        }

        float newZ = Mathf.Lerp(currentZ, targetAngle, Time.deltaTime * M_rotationLerpSpeed);
        transform.rotation = Quaternion.Euler(0f, 0f, newZ);
    }

    //Summary
    // sets important game variables to be ready for gameplay
    public void StartGame()
    {
        M_isAlive = true;
        M_birdRB.gravityScale = M_gravityScale;
        M_birdRB.linearVelocity = Vector2.zero;
    }

    //Summary
    // returns the bird to its start conditions, ready for gameplay
    public void ResetBird()
    {
        StartGame();
        transform.position = M_initialBirdPosition;
        transform.rotation = M_initialBirdRotation;
    }

    //Summary
    // disables inputs and makes sure player cannot interact, calls game over
    public void Die()
    {
        M_isAlive = false;
        M_birdRB.linearVelocity = Vector2.zero;
        GameManager.S_Instance.GameOver();
    }

    //Summary
    //when colliding with any collider the player dies
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
}
