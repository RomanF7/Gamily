using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoColumna : MonoBehaviour
{

    public static Transform transformFinalizacion;
    
    [Header("Columna")]
    [SerializeField]
    private float velocida;


    private void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        transform.position = Vector3.MoveTowards(transform.position, transformFinalizacion.position, velocida * Time.deltaTime);
        if (transform.position == transformFinalizacion.position)
        {
            Jefe.stop = true;
        }
    }
    public static void SetFinal(Transform final)
    {
        transformFinalizacion = final;
    }
}
