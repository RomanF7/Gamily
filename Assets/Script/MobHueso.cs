using UnityEngine;

public class MobHueso : MonoBehaviour
{
    [SerializeField] private float velAux;
    private float velocidadTiempo, velocidad;
    public Transform HuesoIzq, HuesoDer, objetivo;

    void Start()
    {
        objetivo = HuesoDer;
    }

    [System.Obsolete]
    void Update()
    {

        if (Jeringas.pararTiempo == true)
        {
            velocidad = 0f;
        }
        else
        {
            //Verifica que velocidad tomará
            if (Jeringas.habilidadJA == true)
            {
                velocidad = (velAux * 0.5f);
            }
            else
            {
                velocidad = velAux;
            }
        }

            if (transform.position.x == HuesoDer.position.x)
            {
                objetivo = HuesoIzq;
            }
            else if (transform.position.x == HuesoIzq.position.x)
            {
                objetivo = HuesoDer;
            }
            velocidadTiempo = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(objetivo.position.x, transform.position.y, transform.position.z), velocidadTiempo);
        }
        private void OnCollisionEnter2D(Collision2D colision)
        {
            if (colision.gameObject.tag == "Player")
            {
                colision.collider.transform.SetParent(transform);
            }
        }

        private void OnCollisionExit2D(Collision2D colision)
        {
            if (colision.gameObject.tag == "Player")
            {
                colision.collider.transform.SetParent(null);
            }
        }

    }
