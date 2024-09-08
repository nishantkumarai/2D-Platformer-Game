using System;
using UnityEditorInternal;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController;
    public Animator animator;
    public float speed;
    public float jumpPower;

    
    [SerializeField] private float fallDeathposition;

    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        Debug.Log("Player controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Jump");
        bool crouch = Input.GetKey(KeyCode.LeftControl);

        animator.SetBool("Crouch", crouch);
       

        PlayMovementAnimation(horizontal);
        MoveCharactor(horizontal);
        FallDeath();

        // move charactor vertically
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
            //Debug.Log("running");
            animator.SetTrigger("Jump");
        }

        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y* 0.5f);
        }

    }

    

    private void MoveCharactor(float horizontal)
    {
        //move charactor horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayMovementAnimation(float horizontal)
    {
        //run
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
       
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    /*
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "platform")
        {
            isGrounded = false;
        }
    }*/

    private void FallDeath()
    {
        Vector3 position = transform.localPosition;
        if(position.y <= fallDeathposition)
        {
            gameOverController.PlayerDied();
            //SceneRestart();
        }
    }

    

    public void PickUpKey()
    {
        Debug.Log("Key Pick Up");
        scoreController.IncrementScore(10);
    }

    public void KillPlayer()
    {
        Debug.Log("Player dead");
        animator.SetTrigger("Death");
        gameOverController.PlayerDied();
        SoundManager.Instance.Play(Sounds.PlayerDeath);
    }
}
