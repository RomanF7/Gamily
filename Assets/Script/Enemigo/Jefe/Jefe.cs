using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jefe : MonoBehaviour
{
    [Header("Jugador")]
    [Tooltip("Los ojos segiran al objetivo")]
    [SerializeField]
    private Transform transformJugador;


    [Header("Jefe")]
    [SerializeField]
    private Transform ojo1, ojo2;
    [SerializeField]
    private GameObject inicioColumna, inicioRayo1, inicioRayo2, finalComlumna, inicioDiamante;
    [SerializeField]
    private GameObject prefabColumna, prefabRayo1, prefabRayo2, prefabDiamante;

    public static bool stop;

    private GameObject rayoGrande1, rayoGrande2, columna, diamante;
    private float cronometro;
    private bool ataque3, ataque2, ataque1, spawn;
    private Vector2 diferencia;

    private void Start()
    {
        MovimientoColumna.SetFinal(finalComlumna.transform);
    }

    private void Update()
    {
        Ataque3();
        Ataque2();
        Ataque1();
    }


    private void Ataque3()
    {
        if (ataque3)
        {
            stop = false;
            if (spawn == false)
            {

                cronometro = Time.time + .5f;
                rayoGrande1 = Instantiate(prefabRayo1, inicioRayo1.transform);
                rayoGrande2 = Instantiate(prefabRayo2, inicioRayo2.transform);
                rayoGrande1.transform.position = new Vector3(rayoGrande1.transform.position.x, rayoGrande1.transform.position.y, 2);
                rayoGrande2.transform.position = new Vector3(rayoGrande2.transform.position.x, rayoGrande2.transform.position.y, 1.2f);
                spawn = true;
            }
            else if (Time.time > cronometro && stop == false)
            {
                Destroy(rayoGrande1);
                Destroy(rayoGrande2);
                stop = true;
                ataque3 = false;
            }

            diferencia = transformJugador.position - transform.position;
            var aux = Vector2.Angle(diferencia, transform.position);
            var aux2 = Vector2.Angle(new Vector2(transformJugador.position.x - transform.position.x, -transformJugador.position.y), transform.position);
            if (aux > 100)
            {
                ojo1.transform.eulerAngles = new Vector3(0, 0, -Mathf.Clamp(aux, 90, 180));
                ojo1.transform.localScale = new Vector3(-1, -1, 1);
                ojo2.transform.eulerAngles = new Vector3(0, 0, -Mathf.Clamp(aux, 90, 180));
                ojo2.transform.localScale = new Vector3(1, -1, 1);

                rayoGrande1.transform.eulerAngles = new Vector3(0, 0, -Mathf.Clamp(aux2, 90, 180) + 90);
                rayoGrande2.transform.eulerAngles = new Vector3(0, 0, -Mathf.Clamp(aux2, 90, 180) + 90);

            }
        }
    }

    private void Ataque2()
    {
        if (ataque2)
        {

            if (spawn == false)
            {
                columna = Instantiate(prefabColumna, inicioColumna.transform);
                spawn = true;
            }
            if (stop)
            {
                Destroy(columna, 1);
                ataque2 = false;
            }
        }
    }

    private void Ataque1()
    {
        if (ataque1)
        {

            if (Time.time > cronometro)
            {
                if (stop == false)
                {
                    diamante = Instantiate(prefabDiamante, inicioDiamante.transform);
                    stop = true;
                }
                cronometro = Time.time + 4f;
                diferencia = transformJugador.position;
            }

            if (Time.time < cronometro)
            {
                diamante.transform.position = Vector2.MoveTowards(diamante.transform.position, diferencia, 1.5f * Time.deltaTime);
            }
        }
    }
}
