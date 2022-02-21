using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playermovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private GameObject groundCheck;
    [SerializeField]
    private LayerMask groundLayer;

    private float horizontalAxis;
    private bool isGrounded;
    
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //non physics object
    }

    void FixedUpdate()
    {
        //physics objects

        //translate
        //_rb.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f));
        
        // add force
        //_rb.AddForce(new Vector2(moveSpeed, 0.0f), ForceMode2D.Force);

        //velocity
        _rb.velocity = new Vector2(moveSpeed * horizontalAxis, _rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, groundLayer);
    }

    public void OnMove(InputAction.CallbackContext context){
        horizontalAxis = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context){
        if(context.performed && isGrounded){
            _rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            //Debug.Log(" Jump");
        }
        
    }
}
