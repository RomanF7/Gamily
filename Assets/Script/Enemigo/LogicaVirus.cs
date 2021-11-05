using UnityEngine;

public class LogicaVirus : MonoBehaviour
{
    [SerializeField]
    private float velAux;
    private float velocidadTiempo, velocidad;
    public Transform PuntoA, PuntoB;
    private Transform objetivo;

    void Awake()
    {
        PuntoA.position = new Vector3(PuntoA.position.x, PuntoA.position.y, transform.position.z);
        PuntoB.position = new Vector3(PuntoB.position.x, PuntoB.position.y, transform.position.z);
        objetivo = PuntoB;
    }

    void Update()
    {

        if (Jeringas.pararTiempo == true)
        {
            velocidad = 0f;
        }
        else
        {
            //Verifica que velocidad tomará
            if (Jeringas.habilidadMA == true)
            {
                velocidad = (velAux * 0.5f);
            }
            else
            {
                velocidad = velAux;
            }
        }

        if (transform.position == PuntoB.position)
        {
            objetivo = PuntoA;
        }
        else if (transform.position == PuntoA.position)
        {
            objetivo = PuntoB;
        }
        velocidadTiempo = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z), velocidadTiempo);
    }
}