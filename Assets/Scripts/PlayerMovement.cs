using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Camera mainCamera;
    public GameObject GameController;
    CameraController mainCameraController;
    GameController gameController;
    public float horizontalMove = 0f;
    float verticalMove = 0f;
    public float runSpeed = 40f;
    public float timer;
    private bool collided;
    public float miningSpeed;


    // Start is called before the first frame update
    void Start()
    {
        mainCameraController = mainCamera.GetComponent<CameraController>();
        gameController = GameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameController.EndDay();
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyUp(KeyCode.A))
        {
            collided = false;
            //Debug.Log("Collided = " + collided + " Key Up A");
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            collided = false;
            //Debug.Log("Collided = " + collided + " Key Up D");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            timer = Time.time;

        }
        else if(Input.GetKey(KeyCode.S))
        {
            mainCameraController.Shake = true;
            if(Time.time - timer > miningSpeed)
            {
                timer = Time.time;
                //Debug.Log("Down held for 3 seconds");
                controller.BreakBlock(new Vector3(0, -1, 0));
                mainCameraController.Shake = false;
            }
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            timer = Time.time;
        }
        else if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if(collided == true)
            {
                mainCameraController.Shake = true;
                if(Time.time - timer > miningSpeed)
                {
                    timer = Time.time;
                    //Debug.Log("Left held for 3 seconds");
                    controller.BreakBlock(new Vector3(-1, 0, 0));
                    collided = false;
                    //Debug.Log("Collided = " + collided);
                    mainCameraController.Shake = false;
                }
            }
            else
            {
                controller.Move(horizontalMove * Time.fixedDeltaTime);
                mainCameraController.Shake = false;
                timer = Time.time;
            }
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            timer = Time.time;
        }
        else if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            if(collided == true)
            {
                mainCameraController.Shake = true;
                if(Time.time - timer > miningSpeed)
                {
                    timer = Time.time;
                    //Debug.Log("Right held for 3 seconds");
                    controller.BreakBlock(new Vector3(1, 0, 0));
                    collided = false;
                    //Debug.Log("Collided = " + collided);
                    mainCameraController.Shake = false;
                }
            }
            else
            {
                controller.Move(horizontalMove * Time.fixedDeltaTime);
                mainCameraController.Shake = false;
                timer = Time.time;
            }
        }
        else
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime);
            mainCameraController.Shake = false;
            timer = Time.time;
            collided = false;
        }
    }

    void FixedUpdate()
    {
        
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        int layerMask = ~(1 << 6);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(-1f, 0f, 0f), 1000f, layerMask);
        Debug.DrawRay(transform.position, new Vector3(-1f, 0f, 0f), Color.yellow, 1000f);
        if(hit.collider != null && hit.collider.gameObject != this.gameObject && hit.collider == collision.collider)
        {
            if(Input.GetKey(KeyCode.A))
            {
                
                collided = true;
                //Debug.Log("A key collided " + collided + " with " + collision.gameObject.name);
            }
                
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, new Vector3(1f, 0f, 0f), 1000f, layerMask);
            Debug.DrawRay(transform.position, new Vector3(1f, 0f, 0f), Color.yellow, 1000f);
            if(hit.collider != null && hit.collider.gameObject != this.gameObject && hit.collider == collision.collider)
            {
                if(Input.GetKey(KeyCode.D))
                {
                    collided = true;
                    //Debug.Log("D key collided " + collided + " with " + collision.gameObject.name);
                }
            }
            else
            {
                collided = false;
                //Debug.Log("Collided = " + collided);
                //Debug.Log("Collided with not horizontal block" + collision.gameObject.name);
            }
        } 
    }
}
