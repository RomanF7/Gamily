using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    //Variables privadas
    private int direccion;
    private float cronometro;

    //Variables publicas
    public Jugador jugador;
    public float velocidad, duracion;

    //Start
    public void Start()
    {
        //Seteo de variables a valores por defecto
        direccion = 0;
        cronometro = 0;
    }

    // Update
    public void Update()
    {
        //Comprobar que se haya parado el tiempo
        if (Jeringas.pararTiempo == true)
        {
            velocidad = 0f;
        }
        else
        {
            //Verifica que velocidad tomará
            if (Jeringas.habilidadMA == true)
            {
                velocidad = Jeringas.habilidadLenta;
            }
            else
            {
                velocidad = 2f;
            }

            //Si el tiempo trascurrido es menor, este cuerpo se movera hasta el tiempo determinado
            if (Time.unscaledTime < cronometro)
            {
                IrALaOtraDireccion();
            }
            else
            {
                //Luego de tracurir el tiempo, se selecciona la dirección opuesta para moverse
                if (direccion == 1)
                {
                    direccion = 0;
                }
                else
                {
                    direccion = 1;
                }
                cronometro = Time.unscaledTime + duracion;
            }
        }
    }

    //Movimiento dependiento de la dirección
    public void IrALaOtraDireccion()
    {

        if (direccion == 1)
        {
            transform.position = new Vector3(transform.position.x + 1 * velocidad * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (direccion == 0)
        {
            transform.position = new Vector3(transform.position.x - 1 * velocidad * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
