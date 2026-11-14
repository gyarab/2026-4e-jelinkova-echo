using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door; // dvere, ktere chcemme otevrit

    private void OnTriggerEnter2D(Collider2D collision) //v promenne collision se ulozi objekt, ktery vstoupil do kolize s klicem
    {
        if(collision.gameObject.CompareTag("Player")) //pokud hrac vstoupi do kolize s klicem
        {
            Destroy(door); //otevrou se = znici se dvere
            Destroy(gameObject); //odstrani se i klic
        }
    }
}
