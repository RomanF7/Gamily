using UnityEngine;

public class LogicaVirus : MonoBehaviour
{
    [SerializeField]
    private float velAux;
    private float velocidadTiempo, velocidad;
    public Transform PosIzq, PosDer;
    private Transform objetivo;

    void Start()
    {
        objetivo = PosDer;
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

        if (transform.position.x == PosDer.position.x)
        {
            objetivo = PosIzq;
        }
        else if (transform.position.x == PosIzq.position.x)
        {
            objetivo = PosDer;
        }
        velocidadTiempo = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(objetivo.position.x, transform.position.y, transform.position.z), velocidadTiempo);
    }
}