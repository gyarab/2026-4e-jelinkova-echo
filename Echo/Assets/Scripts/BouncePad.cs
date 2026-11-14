using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce = 10f; //sila skoku

    private void OnCollisionEnter2D(Collision2D collision) //do promenne collision se ulozi objekt, ktery vstoupil do kolize s hracem
    {
        //ziskani Rigidbody2D komponenty na objektu, ktery vstoupil na bounce pad
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>(); 
        
        if(rb != null) //pokud objekt ma Rigidbody2D
        {
            //nastaveni vertikalni rychlosti na nulu, aby skok nebyl ovlivnen predchozim pohybem
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); 
            //nastaveni sily skoku
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            if(collision.gameObject.CompareTag("Player"))
            {
                //do promenne playerMovement se ulozi skript PlayerMovement
                PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>(); //
                if (playerMovement != null)
                {
                    //volani metody na resetovani poctu dalsich skoku ve vzduchu
                    playerMovement.ResetExtraJumps();
                }
            }
        }
    }
}
