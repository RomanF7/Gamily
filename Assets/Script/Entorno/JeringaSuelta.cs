using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeringaSuelta : MonoBehaviour
{
    //Variables publicas
    public SpriteRenderer renderJeringaA;
    public GameObject indicacion1, indicacion2;
    
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
            renderJeringaA.enabled = true;
            Destroy(gameObject);
            Destroy(indicacion1);
            Destroy(indicacion2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
