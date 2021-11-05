using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararRalentizarAnimaciones : MonoBehaviour
{
    private Animator animacion;
    [SerializeField] private float velocidad;
    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Jeringas.pararTiempo == true)
        {
            animacion.speed = 0f ;
        }
        else
        {
            //Verifica que velocidad tomará
            if (Jeringas.habilidadMA == true)
            {
                animacion.speed = (velocidad * 0.5f);
            }
            else
            {
                animacion.speed = velocidad;
            }
        }
    }
}
