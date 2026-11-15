using UnityEngine;

public class Door : MonoBehaviour
{
    public Button[] buttons; //pole tlacitek, ktere je potreba stisknout na otevreni dveri

    void Update()
    {
        if(buttons.Length > 0 && AllButtonsPressed())
        {
            /*foreach(Button b in buttons)
            {
                b.LockButton(); 
            }*/
            Destroy(gameObject); //pokud jsou vsechna tlacitka stisknuta, tak se dvere znici
        }
    }

    //kontrola toho, jestli jsou vsechna tlacitka stisknuta
    public bool AllButtonsPressed()
    {
        foreach(Button b in buttons)
        {
            if(!b.isPressed) //pokud alespon jedno tlacitko neni stisknute, vrati se false
            {
                return false;
            }
        }
        return true; 
    }
}
