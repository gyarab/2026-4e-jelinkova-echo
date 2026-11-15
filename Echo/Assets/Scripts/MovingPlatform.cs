using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f; // rychlost pohybu platformy
    public Transform[] points; // pole bodu pohybu platformy

    private int i;
    private bool isQuitting = false;

    void Start()
    {
        transform.position = points[0].position; //nastaveni pocatecni pozice platformy na prvni bod
    }

    void Update()
    {
        //zmeri se vzdalenost mezi aktualni a cilovou pozici, pokud je temer u cilove pozice, tak se zmeni cil na dalsi bod
        if(Vector2.Distance(transform.position, points[i].position) < 0.01f) 
        {
            i++;
            if(i == points.Length)
            {
                i = 0; //pokud jsme na konci trasy, tak dalsim cilem je zacatecni bod
            }
        }
        //pohyb platformy k cilove pozici - v kazdem snimku o kousicek, speed muze zmenit rychlost pohybu
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnApplicationQuit()
    {
        isQuitting = true; //aplikace se ukoncuje - zabrani se nasledujici funkce, aby se hrac neodpojil od platformy pri ukoncovani hry
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collided with: " + collision.gameObject.name);
        if(!isQuitting && gameObject.activeInHierarchy) //kontrola, jestli se aplikace ukoncuje a jestli je platforma aktivni
        {
            collision.transform.SetParent(transform); //objekt nastavime jako dite, tedy jako soucast platformy, aby se pohybovaly spolu
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("Exited collision with: " + collision.gameObject.name);
        if(!isQuitting && gameObject.activeInHierarchy && collision.gameObject.activeInHierarchy) //kontrola, jestli se aplikace ukoncuje a jestli je platforma a hrac aktivni
        {
            collision.transform.SetParent(null); //objekt odstranime jako dite, aby se opet pohyboval samostatne
        }
    }
}
