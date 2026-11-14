using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f; // rychlost pohybu platformy
    public Transform[] points; // pole bodu pohybu platformy

    private int i;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) //pokud hrac vstoupi do kolize s platformou
        {
            collision.transform.SetParent(transform); //hrace nastavime jako dite, tedy jako soucast platformy, aby se pohybovali spolu
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) //pokud hrac opusti kolizi s platformou
        {
            collision.transform.SetParent(null); //hrace odstranime jako dite, aby se opet pohyboval samostatne
        }
    }
}
