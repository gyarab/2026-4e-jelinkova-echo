using UnityEngine;

public class Button : MonoBehaviour
{
    private int objectsOnButton = 0; //pocet objektu, ktere stoji na tlacitku
    //je true, pokud je na tlacitku alespon jeden objekt - vstup dalsiho objektu by jinak tlacitko vypnul
    public bool isPressed => objectsOnButton > 0; 

    private void OnTriggerEnter2D(Collider2D collision) //v promenne collision se ulozi objekt, ktery vstoupil do kolize s tlacitkem
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box")) //pokud hrac nebo krabice stoupne na tlacitko
        {
            objectsOnButton++; //pristoupil dalsi objekt
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //v promenne collision se ulozi objekt, ktery opustil kolizi s tlacitkem
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box")) //pokud hrac nebo krabice vystoupne z tlacitka
        {
            objectsOnButton--; //odstoupil jeden objekt
        }
    }
}
