using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    CharacterController characterController;
    Transform playerContainer, cameraContainer;
    //Camera camera;

    public float speed = 6.0f;
    public float jumpSpeed = 7.0f;
    public float mouseSensitivity = 2f;
    public float gravity = 20.0f;
    public float lookUpClamp = -30f;
    public float lookDownClamp = 60f;

    private Vector3 moveDirection = Vector3.zero;
    float rotateX, rotateY;

    void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        SetCurrentCamera();  // Add after PerspectiveSwitch
    }
    void Update()
    {
        Locomotion();
        RotateAndLook();


        // TEST PERSPECTIVE SWITCH
        PerspectiveCycle();
    }

    void SetCurrentCamera()
	{
        // The following line should be moved to the top definitions if being kept in game
        PerspectiveSwitch perspectiveSwitch = GetComponent<PerspectiveSwitch>();

        if (perspectiveSwitch.GetPerspective() == PerspectiveSwitch.Perspective.First)
        {
            playerContainer = gameObject.transform.Find("Container1P");
            cameraContainer = playerContainer.transform.Find("Camera1PContainer");
        }
		else
		{
            playerContainer = gameObject.transform.Find("Container3P");
            cameraContainer = playerContainer.transform.Find("Camera3PContainer");
        }
            
    }

    void Locomotion()
	{
        if (characterController.isGrounded) // When grounded, set y-axis to zero (to ignore it)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void RotateAndLook()
    {
        rotateX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotateY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotateY = Mathf.Clamp(rotateY, lookUpClamp, lookDownClamp);

        transform.Rotate(0, rotateX * mouseSensitivity, 0);

        cameraContainer.transform.localRotation = Quaternion.Euler(rotateY, 0, 0);

        //Transform camContainer = Camera.current.transform.parent;
        //Debug.Log(Camera.current.gameObject.name);
        //camContainer.localRotation = Quaternion.Euler(rotateY, 0, 0);

        //Transform camContainer = Camera.current.gameObject.GetComponentInParent<Transform>();
        //Debug.Log(camContainer.gameObject.name);
        //camContainer.localRotation = Quaternion.Euler(rotateY, 0, 0);
    }



    // TEST PERSPECTIVE SWITCH
    void PerspectiveCycle()
	{
        if (Input.GetButtonDown("Fire3"))
        {
            // The following line should be moved to the top definitions if being kept in game
            PerspectiveSwitch perspectiveSwitch = GetComponent<PerspectiveSwitch>();

            if (perspectiveSwitch.GetPerspective() == PerspectiveSwitch.Perspective.First)
            {
                perspectiveSwitch.SetPerspective(PerspectiveSwitch.Perspective.Third);
			}
			else
			{
                perspectiveSwitch.SetPerspective(PerspectiveSwitch.Perspective.First);
            }

            SetCurrentCamera();
        }
    }

}
