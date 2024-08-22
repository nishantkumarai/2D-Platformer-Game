using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb2d;
    private bool isGrounded = false;
    [SerializeField]
    private float deathposition;

    private void Awake()
    {
        Debug.Log("Player controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        bool crouch = Input.GetKey(KeyCode.LeftControl);

        animator.SetBool("Crouch", crouch);
       

        PlayMovementAnimation(horizontal, vertical);
        MoveCharactor(horizontal, vertical);
        FallDeath();
    }

    private void MoveCharactor(float horizontal, float vertical)
    {
        //move charactor horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        // move charactor vertically
        if(vertical > 0 && isGrounded)
        {
            //animator.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            //Debug.Log("running");
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
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

        //jump 
        
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

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
    }

    private void FallDeath()
    {
        Vector3 position = transform.localPosition;
        if(position.y <= deathposition)
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
