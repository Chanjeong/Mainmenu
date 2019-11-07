using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed=5f;
    public Animator animator;
    [SerializeField] private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    public bool facingRight = true;

    public float jumpForce = 5f;

    private int extraJumps;
    public int extraJumpsValue;
    private float moveInput;

    // Start is called before the first frame update
    void Start()
    {
       rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius, whatIsGround); //check if the character is on the ground.
        float x = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        if (facingRight==true){
        transform.Translate(x,0,0);
        } else{
            transform.Translate(-x,0,0);
        }
        
        animator.SetFloat("Speed",Mathf.Abs(x));
        if(x > 0 && !facingRight)
            Flip();
        else if(x < 0 && facingRight)
            Flip();
    }
    void Update()
    {
       
        //animator.SetBool("Grounded",isGrounded);
         
        if(isGrounded == true){
            extraJumps=extraJumpsValue; //when character hits ground, you get a number of jumps.
        }
        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
    {
        rb.velocity = Vector2.up *jumpForce;
        extraJumps--; //if you jump when extra jump > 0, extra jump will decreased by 1
    } else if (Input.GetKeyDown(KeyCode.Space) && extraJumps ==0 && isGrounded == true){ // if you set to extra jump to 0, you can only jump once.
        rb.velocity = Vector2.up *jumpForce;

      
}
}
void Flip ()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f); //flip character when facing a different direction
    }
}
