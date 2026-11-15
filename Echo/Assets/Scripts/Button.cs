using UnityEngine;

public class Button : MonoBehaviour
{
    private int objectsOnButton = 0; //pocet objektu, ktere stoji na tlacitku
    //je true, pokud je na tlacitku alespon jeden objekt - vstup dalsiho objektu by jinak tlacitko vypnul
    public bool isPressed => objectsOnButton > 0; 
    public Door door; //odkaz na dvere, ktere se maji otevrit

    private Rigidbody2D rb;
    private Animator animator;
    private bool isLocked = false; //urcuje, jestli tlacitko nezustane uzamcene

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //v promenne collision se ulozi objekt, ktery vstoupil do kolize s tlacitkem
    {
        //if (isLocked) return; //tlacitko je uzamcene - zadne operace s nim se neprovedou

        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box")) //pokud hrac nebo krabice stoupne na tlacitko
        {
            objectsOnButton++; //pristoupil dalsi objekt
            //animator.Play("ButtonAnimation"); //spustime animaci tlacitka, kdyz je stisknute
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision) //v promenne collision se ulozi objekt, ktery opustil kolizi s tlacitkem
    {
        //if (isLocked) return; //tlacitko je uzamcene - zadne operace s nim se neprovedou

        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box")) //pokud hrac nebo krabice vystoupne z tlacitka
        {
            objectsOnButton--; //odstoupil jeden objekt
        }
    }

    /*public void LockButton()
    {
        isLocked = true;
        animator.Play("ButtonAnimation", 0, 1f);
    }*/
}
