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
    public Transform transformPer;
    public Vector3 posCamara;
    public SpriteRenderer jeringaR, jeringaA;
    private void Awake()
    {
        posCamara.z = -100;
        if (Doctor.visitaAlDoctor)
        {
            jeringaR.enabled = true;
        }
    }

    private void LateUpdate()
    {
        if (transformPer.position.x > -10.03f && transformPer.position.x < 60.62f)
        {
            posCamara.x = transformPer.position.x;
            transform.position = posCamara;
        }
        
    }
}
