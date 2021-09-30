using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeringaSuelta : MonoBehaviour
{
    //Variables publicas
    public SpriteRenderer renderJeringaAzul;
    public GameObject texto1, texto2;
    
    //Variables privadas
    private bool enColisionConLaJeringaAzul;
    
    private void Update()
    {
        RecoleccionJeringaAzul();
    }

    private void RecoleccionJeringaAzul()
    {
        if (Input.GetKeyDown(KeyCode.E) && enColisionConLaJeringaAzul == true)
        {
            renderJeringaAzul.enabled = true;
            Destroy(gameObject);
            Destroy(texto1);
            Destroy(texto2);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enColisionConLaJeringaAzul = true;
        }
        else
        {
            enColisionConLaJeringaAzul = false;
        }
    }

}
