using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    //public float sprintSpeed = 10f; mozna pouzijeme pozdeji
    public Vector2 movement; //vektor pro pohyb v osach x a y
    public float jumpForce = 3f;
    private Rigidbody2D rb; //na praci s fyzikou
    private bool isGrounded; //kontrola, jestli je hrac na zemi
    private bool jumpPressed; //kontrola, jestli hrac stiskl mezernik
    public Transform groundCheck; //pozice/rotace/velikot objektu, kontrolni bod
    public float groundDistance = 0.3f; 
    public LayerMask groundMask; //vrstva, na ktere se kontroluje groundCheck
    public int extraJumpsValue = 1; //pocet dalsich skoku ve vzduchu - cheme double jump
    private int extraJumps; //aktualni pocet dalsich skoku ve vzduchu
    void Start() //spusti se jednou pri spusteni hry
    {
        rb = GetComponent<Rigidbody2D>(); //ziskani Rigidbody2D komponenty na objektu, na kterem je pripojen skript

        extraJumps = extraJumpsValue; 
    }

    void Update() //spusti se kazdy frame
    {
        movement = Vector2.zero; //nastaveni pohybu na nulu - porad, aby byl pohyb aktualni 
        //kontrola pohybu doleva a doprava - scitame, aby se pri stisku obou klaves pohyb vynuloval
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector2.right;
        }
        
        if(isGrounded)
        {
            extraJumps = extraJumpsValue; //obnoveni poctu dalsich skoku, pokud je hrac na zemi
        }

        //kontrola skoku - okamziku stisku mezerniku
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
    }
    
    void FixedUpdate() //spusti se casteji
    {
        //rychlost horizontalniho pohybu hrace, vertikalni je zachovan 
        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
        
        //kontrola, jestli je hrac na zemi
        //vytvori se pomyslny kruh na pozici groundCheck s polomerem groundDistance a kontroluje se, jestli se kruh dotyka objektu na vrstve groundMask   
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);
        
        //Debug.Log("Is Grounded: " + isGrounded);
        
        if (isGrounded && jumpPressed) //pokud je hrac na zemi a stiskl mezernik
        {
            //pridani sily hraci na skok s okamzitym imuplsem sily
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        } 
        else if (extraJumps > 0 && jumpPressed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            extraJumps--; //zbyva o jeden skok mene ve vzduchu
        }
        jumpPressed = false;
    }

    public void ResetExtraJumps() //resetovani poctu dalsich skoku ve vzduchu pri pouziti bounce padu
    {
        extraJumps = extraJumpsValue;
    }
}
