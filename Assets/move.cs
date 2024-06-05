using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.right;
    private string currentAnimation = "";
    private bool facingRight = true;

    public bool onGround = false;
    public float moveSpeed = 1;
    public float jumpStrength = 10;
    public Rigidbody2D playerRigidbody2D;
    public SpriteRenderer playerSpriteRenderer;
    public Animator playerAnimator;

    void Update()
    {
        HandleMovement();
        HandleJumping();
    }

    void FixedUpdate()
    {
        CheckGround();
    }

    void HandleMovement()
    {
        if (Input.GetKey("d"))
        {
            MovePlayer(Vector2.right);
            facingRight = true;
            RotatePlayer();

        }
        else if (Input.GetKey("a"))
        {
            MovePlayer(Vector2.left);
            facingRight = false;
            RotatePlayer();
        }
        else
        {
            StopPlayerAnimation();
        }
    }

    void MovePlayer(Vector2 direction)
    {
        moveDirection = direction * moveSpeed;
        playerRigidbody2D.velocity = new Vector2(moveDirection.x, playerRigidbody2D.velocity.y);

        if (onGround)
        {
            PlayAnimation("PlayerWalk");
        }
    }

    void RotatePlayer()
    {
        playerSpriteRenderer.flipX = !facingRight;
        // Thêm các mã khác để xoay nhân vật một cách chính xác
    }

    void HandleJumping()
    {
        if (Input.GetKeyDown("space") && onGround)
        {
           
            playerRigidbody2D.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);

            
            onGround = false;
            if (Input.GetKeyDown("space") && onGround)
            {
                Debug.Log("Jumping triggered!");
                playerRigidbody2D.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
                onGround = false;
                StartCoroutine(PlayJumpAnimation());
            }
            // Chơi animation nhảy
            StartCoroutine(PlayJumpAnimation());
        }
    }

    void StopPlayerAnimation()
    {
        if (onGround)
        {
            PlayAnimation("PlayerIdle");
        }
    }

    IEnumerator PlayJumpAnimation()
    {
        PlayAnimation("PlayerJump");
        yield return new WaitUntil(() => onGround);
        PlayAnimation("PlayerIdle");
    }

    void PlayAnimation(string animationName)
    {
        if (currentAnimation != animationName)
        {
            currentAnimation = animationName;
            playerAnimator.Play(currentAnimation);
            Debug.Log("Playing: " + currentAnimation);
        }
    }

    void CheckGround()
    {
        // Kiểm tra xem nhân vật có đang tiếp đất không
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground"));
        onGround = hit.collider != null;
    }

}