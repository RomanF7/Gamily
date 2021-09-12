using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public MovimientoPersonaje personaje;
    public Transform transformPer/*, transformFondo*/;
    public Vector3 posCamara, posFondo;

    private void Awake()
    {
        posCamara.z = -100;
        posFondo.x = transformPer.position.x;
        posFondo.z = 100;
    }
    
    private void LateUpdate()
    {
        posCamara.x = transformPer.position.x;
        transform.position = posCamara;
    }
}
