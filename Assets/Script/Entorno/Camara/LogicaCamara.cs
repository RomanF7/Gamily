using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaCamara : MonoBehaviour
{
    /*

    ****************************************************************************
    ****************************************************************************
    **ACLARACÓN TODA PARTE LÓGICA COMENTADA SE ESPERA QUE SE USE EN UN FUTURO.**
    ****************************************************************************
    ****************************************************************************

    */

    //Variables publicas
    public Transform transformPer, transformIzq, transformDer, auxiliarDistanciaIzquierda, auxiliarDistanciaDerecha;
    public Vector3 posCamara;

    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        posCamara.z = -100;
    }

    private void Start()
    {
        audioSource.volume = ControlAudio.volumen;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

    }

    private void LateUpdate()
    {
        //Debug.Log("Distancia: " + Vector2.Distance(transformPer.position, transformDer.position));
        if (Vector2.Distance(auxiliarDistanciaIzquierda.position, transformIzq.position) > 0.6f && Vector2.Distance(auxiliarDistanciaDerecha.position,transformDer.position) > 0.8f)
        {
            posCamara.x = transformPer.position.x;
            transform.position = posCamara;
        }
        else if(Vector2.Distance(transformPer.position, transformIzq.position) > 9.8f && Vector2.Distance(transformPer.position, transformIzq.position) < 11 ||  Vector2.Distance(transformPer.position, transformDer.position) > 9.8f && Vector2.Distance(transformPer.position, transformDer.position) < 11)
        {
            posCamara.x = transformPer.position.x;
            transform.position = posCamara;
        }

        
    }
}
