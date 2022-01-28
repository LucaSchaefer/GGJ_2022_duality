using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction { Left, Right }

public class PlayerMovement : MonoBehaviour {

    //Assingables
    [Header( "Assingables" )]
    public Transform playerCam;
    public Transform orientation;

    //Other
    private Rigidbody rb;

    [Header( "Camera Movement" )]
    public float sensitivityX = 50f;
    public float sensitivityY = 50f;
    private float sensMultiplier = 1f;
    private Vector2 cameraLookValue = new Vector2( );

    //Movement
    [Header( "Movement" )]
    private Direction _direction = Direction.Right;
    public Direction direction {
        get { return _direction; }
        set { 
            _direction = value;
            RotateMesh( );
        }
    }
    public float moveSpeed = 6.0f;
    public float movementMultiplier = 10.0f;

    //Jumping
    [Header( "Jumping" )]
    public float jumpForce = 550f;
    private float jumpValue = 0;
    private bool readyToJump = true;

    //Input
    Vector2 moveValue = new Vector2( );
    float lastMoveX;
    float horizontalAxis;
    bool jumping;

    void Awake( ) {
        rb = GetComponent<Rigidbody>( );
    }

    void Start( ) {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    #region input system methods

    public void OnMove( InputAction.CallbackContext context ) {
        moveValue = context.ReadValue<Vector2>( );
    }

    public void OnJump( InputAction.CallbackContext context ) {
        jumpValue = context.ReadValue<float>( );
    }

    public void OnMouseMove( InputAction.CallbackContext context ) {
        cameraLookValue = context.ReadValue<Vector2>( );
    }

    #endregion

    private void Update( ) {
        MyInput( );
        Look( );
    }

    private void FixedUpdate( ) {
        Movement( );
    }

    private void MyInput( ) {
        horizontalAxis = moveValue.x;

        if( horizontalAxis < 0 ) {
            direction = Direction.Left;
        }
        if( horizontalAxis > 0 ) {
            direction = Direction.Right;
        }

        jumping = jumpValue == 1 ? true : false;
    }

    private void Movement( ) {
        // walk movement
        Vector3 moveVector = orientation.forward * horizontalAxis;

        // rb.AddForce( moveVector * moveSpeed * movementMultiplier , ForceMode.Acceleration );
        rb.velocity = moveVector.normalized * moveSpeed * movementMultiplier * Time.deltaTime;

        //jumping
        if( readyToJump && jumping ) {
            //Jump( );
        }
    }

    private void RotateMesh( ) {
        orientation.eulerAngles = new Vector3( 0 , direction == Direction.Left ? 90 : -90 , 0 );
    }

    private void Look( ) {


        // Camera look

    }


}
