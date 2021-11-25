using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Transform RayStart;

    private Rigidbody playerRigidbody;
    private bool walkingRight = true;

    private Animator animator;
    private HighscoreManager highscoreManager;

    public float jump = 600f;
    public float force = 3f;

    [SerializeField]
    private float speed;


    private bool isJumping = false;
    private bool isOnStreet = true;
    public bool canJump;

    private ScenenControll sceneManager;
    private GameController gameController;

  


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        highscoreManager = FindObjectOfType<HighscoreManager>();
        sceneManager = GetComponent<ScenenControll>();
        gameController = GetComponent<GameController>();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!gameController.GameStarted)
        {
            return;
        }
        else
            animator.SetTrigger("gameStarted");


        playerRigidbody.transform.position = transform.position + transform.forward * speed * Time.deltaTime;
       


    }

    private void Update()
    {
        // If the Input is Space and the player can't jump then switch direction
        if (Input.GetKeyDown(KeyCode.Space) && !canJump)
        {
            SwitchDirection();


            // Check if Player is on the ground

            RaycastHit hit;

            if (!Physics.Raycast(RayStart.position, -transform.up, out hit, Mathf.Infinity))
            {
                animator.SetTrigger("isFalling");
            }

        }

        // If the position of the Player is -3 Restart the game because the Playe died 
        if (transform.position.y < -3)
        {
            sceneManager.Reset();
        }


        if (Input.GetKeyDown(KeyCode.Space) && isOnStreet && canJump)
        {
            playerRigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
            isOnStreet = false;
           
        }



    }

    // Metoth to switch the direction
    private void SwitchDirection()
    {
        if (!gameController.GameStarted)
            return;

        walkingRight = !walkingRight;

        if (!canJump)
        {
            if (walkingRight)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
    }

    // Metoths for Triggers 
    private void OnTriggerEnter(Collider other)
    {
        // To Collect the Sweets & Candys
        if (other.tag == "Sweets")
        {
            Destroy(other.gameObject);
            highscoreManager.IncreaseScore();

        }

        // To Jump when we enter the Trigger 
        if(other.tag == "Jump")
        {
            canJump = true;
            
        }

        // To end the Level and Switch to the next Level 
        if(other.tag == "EndPoint")
        {
            sceneManager.GoToGameScene();

        }

        // To Restart the game when the Player touches an object (Player dies) 
        if(other.tag == "Obstacle")
        {
            sceneManager.Reset();
        }

        


    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Jump")
        {
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Street"))
        {
            isOnStreet = true;

        }
    }


}