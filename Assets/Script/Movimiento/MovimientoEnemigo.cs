using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    //Variables privadas
    private int posicion;
    private float cronometro;

    //Variables publicas
    public MovimientoPersonaje jugador;
    public float velocidad, duracion;
    public MenuPrincipal menu;

    //Start
    void Start()
    {
        //Seteo de variables a valores por defecto
        posicion = 0;
        cronometro = 0;
    }

    // Update
    void Update()
    {
        //Comprobar que se haya parado el tiempo
        if (jugador.GetPararTiempo() == true)
        {
            velocidad = 0f;
        }
        else
        {
            //Verifica que velocidad tomará
            if (jugador.GetHabilidadA() == true)
            {
                velocidad = jugador.GetVelocidadAPasar();
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
                if (posicion == 1)
                {
                    posicion = 0;
                }
                else
                {
                    posicion = 1;
                }
                cronometro = Time.unscaledTime + duracion;
            }
        }
    }

    //Movimiento dependiento de la dirección
    void IrALaOtraDireccion()
    {

        if (posicion == 1)
        {
            transform.position = new Vector3(transform.position.x + 1 * velocidad * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (posicion == 0)
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
