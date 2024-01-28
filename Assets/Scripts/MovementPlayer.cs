using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    //private bool onGround;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float wallJumpTimer;
    private float horizontalInput;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Pause pauseGame;


    private void Awake()
    {
        //References für die Objekte
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider= GetComponent<BoxCollider2D>();
    }

    //für Bewegung
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        
        //Charakter drehen
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.3948337f, 0.3865419f, 1);
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.3948337f, 0.3865419f, 1);

        

        //Animation
        animator.SetBool("Run", horizontalInput != 0 & !isOnWall());
        animator.SetBool("onGround", isOnGround());

        if (wallJumpTimer > 0.2f)
        {
            
            //links-rechts
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (isOnWall() && !isOnGround())
            {
                animator.SetTrigger("jump");
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 2;

            //Sprung bei Leertaste
            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseGame.PauseGame();
    }

    private void Jump()
    {
        if (isOnGround())
        {
            body.velocity = new Vector2(body.velocity.x, jumpHeight);
            animator.SetTrigger("jump");
        }
        else if (isOnWall() && !isOnGround()) 
        {
            if (horizontalInput == 0)
            {
                //komplizierter Weg um Spieler von Wand wegzudrücken (erster Wert für links/rechts, zweiter für oben)
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 5);
                //Charakter drehen
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            else
                //komplizierter Weg um Spieler von Wand wegzudrücken (erster Wert für links/rechts, zweiter für oben)
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            wallJumpTimer = 0;
            
        }
        
    }


    private bool isOnGround()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        //wenn nichts unter dem Spieler, dann wäre der Wert null
        return hit.collider != null;
    }
    private bool isOnWall()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        //wenn nichts unter dem Spieler, dann wäre der Wert null
        return hit.collider != null;
    }

    public bool canAttack()
    {
        print(animator.GetCurrentAnimatorClipInfo(0));
        return !isOnWall();
        
    }
}
