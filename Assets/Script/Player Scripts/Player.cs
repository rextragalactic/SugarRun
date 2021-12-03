using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    private Rigidbody playerRigidbody;
    private bool walkingRight = true;

    private Animator animator;
    private HighscoreManager highscoreManager;

    public float jump = 600f;
    public float force = 3f;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationtSpeed;


    private bool isJumping = false;
    private bool isOnStreet = true;
    public bool canJump;
    private int playerIndex;

    private ScenenControll sceneManager;
    private GameController gameController;


    [SerializeField]
    Animator[] playerAnimator;

    private GameObject[] characterList;




    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        //animator = playerAnimator[playerIndex].GetComponent<Animator>();
        playerIndex = PlayerPrefs.GetInt("CharacterSelected");
        animator = playerAnimator[playerIndex];

        highscoreManager = FindObjectOfType<HighscoreManager>();
        sceneManager = FindObjectOfType<ScenenControll>();
        gameController = GetComponent<GameController>();
        
    }

    
    private void Start()
    {
        characterList = new GameObject[transform.childCount];  // definding the size of the Array

        // Fill the array with Characters
        for (int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        // Hide them 
        foreach (GameObject go in characterList)
            go.SetActive(false);

        if (characterList[0])
        {
            characterList[playerIndex].SetActive(true);
        }

    }

    
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!gameController.GameStarted)
        {
            return;
        }
        else
            animator.SetTrigger("isMoving");

        playerRigidbody.transform.position = transform.position - transform.forward * movementSpeed * Time.deltaTime;
       


    }

    private void Update()
    {
        // If the Input is Space and the player can't jump then switch direction
        if (Input.GetKeyDown(KeyCode.Space) && !canJump)
        {
            SwitchDirection();
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
            animator.SetTrigger("isJumping");

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
            Quaternion targetRotation;

            if (walkingRight)
            {
                targetRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                targetRotation = Quaternion.Euler(0, 90, 0);
            }

            transform.rotation = targetRotation;
        }
    }

    // Metoths for Triggers 
    private void OnTriggerEnter(Collider other)
    {
        // To Collect the Sweets & Candys
        if (other.tag == "Sweets")
        {
            //Turn off grafic for the Sound
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            // Soun to collect
            AudioSource audio = other.gameObject.GetComponent<AudioSource>();
            audio.Play();

            //Destroy the Object
            Destroy(other.gameObject, audio.clip.length);

            // Increase the Score
            highscoreManager.IncreaseScore();


        }

        // To Jump when we enter the Trigger 
        if (other.tag == "Jump")
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

        // To Collect the Sweets & Candys
        if (other.tag == "Door")
        {
            Destroy(other.gameObject);

        }



    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Jump") // If i am out of the Collider you can't jump
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