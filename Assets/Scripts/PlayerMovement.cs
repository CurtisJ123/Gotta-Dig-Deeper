using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Camera mainCamera;
    CameraController mainCameraController;
    public float horizontalMove = 0f;
    float verticalMove = 0f;
    public float runSpeed = 40f;
    public float timer;
    private bool collided;


    // Start is called before the first frame update
    void Start()
    {
        mainCameraController = mainCamera.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.S))
        {
            timer = Time.time;

        }
        else if(Input.GetKey(KeyCode.S))
        {
            mainCameraController.Shake = true;
            if(Time.time - timer > 3f)
            {
                timer = Time.time;
                Debug.Log("Down held for 3 seconds");
                controller.BreakBlock(new Vector3(0, -1, 0));
                mainCameraController.Shake = false;
            }
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            timer = Time.time;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            if(collided == true)
            {
                mainCameraController.Shake = true;
                if(Time.time - timer > 3f)
                {
                    timer = Time.time;
                    Debug.Log("Down held for 3 seconds");
                    controller.BreakBlock(new Vector3(-1, 0, 0));
                    collided = false;
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
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            collided = false;
            Debug.Log("Collided = " + collided);
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            collided = false;
            Debug.Log("Collided = " + collided);
        }
    }

    //public void OnCollisionExit2D(Collision2D collision)
    //{
    //    collided = false;
    //    Debug.Log("Collided = " + collided + " Left collider " + collision.gameObject.name);
    //}
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
                Debug.Log("A key collided " + collided + " with " + collision.gameObject.name);
                Debug.Log("Collided = " + collided);
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
                    Debug.Log("D key collided " + collided + " with " + collision.gameObject.name);
                    Debug.Log("Collided = " + collided);
                }
            }
            else
            {
                collided = false;
                Debug.Log("Collided = " + collided);
            }
        } 
        
        //if(Input.GetKey(KeyCode.A))
        //{
        //    collided = true;
        //    int layerMask = ~(1 << 6);
        //    RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(-1f, 0f, 0f), 1000f, layerMask);
        //    Debug.DrawRay(transform.position, new Vector3(-1f, 0f, 0f), Color.yellow, 1000f);
        //    if(hit.collider != null && hit.collider.gameObject != this.gameObject)
        //    {
        //        if(hit.collider.gameObject == collision.gameObject)
        //        {
        //            Debug.Log("Hit is same as collider " + collision.gameObject.name + " " + hit.collider.name);
        //            if(hit.collider.gameObject.layer == 7)
        //            {
        //                if(Time.time - timer > 3f)
        //                {
        //                    timer = Time.time;
        //                    Debug.Log("Down held for 3 seconds");
        //                    controller.BreakBlock(new Vector3(-1f, 0f, 0f));
        //                    mainCameraController.Shake = false;
        //                }

        //            }
        //        }
        //    }

        //}
        //if(Input.GetKey(KeyCode.D))
        //{
        //    int layerMask = ~(1 << 6);
        //    RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(1f, 0f, 0f), 1000f, layerMask);
        //    Debug.DrawRay(transform.position, new Vector3(1f, 0f, 0f), Color.yellow, 1000f);
        //    if(hit.collider != null && hit.collider.gameObject != this.gameObject)
        //    {
        //        if(hit.collider.gameObject == collision.gameObject)
        //        {
        //            Debug.Log("Hit is same as collider " + collision.gameObject.name + " " + hit.collider.name);
        //            if(hit.collider.gameObject.layer == 7)
        //            {
        //                controller.BreakBlock(new Vector3(1f, 0f, 0f));
        //            }
        //        }
        //    }
        //}
    }
}
