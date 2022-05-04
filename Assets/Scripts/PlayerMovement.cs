using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Camera mainCamera;
    CameraController mainCameraController;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float runSpeed = 40f;
    public float timer;


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
                controller.BreakBlock();
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
}
