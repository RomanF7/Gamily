using System.Collections;
using UnityEngine;

public class BacteriaLiana : MonoBehaviour
{
    private Rigidbody2D fisica;
    [SerializeField]
    private float fuerza, tiempo;
    private bool moviendoLiana, pararLiana;

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Debug.Log("Velocidad: " + fisica.velocity);
        if (!Jeringas.pararTiempo && !moviendoLiana)
        {
            pararLiana = false;
            StartCoroutine(Movimiento());
        }
        else if (Jeringas.pararTiempo && !pararLiana)
        {
            moviendoLiana = false;
            StopCoroutine(Movimiento());
            pararLiana = true;
            fisica.bodyType = RigidbodyType2D.Static;
        }

    }

    // esto no se toca; costó banda hacerlo funcionar c':
    IEnumerator Movimiento()
    {
        moviendoLiana = true;
        fisica.bodyType = RigidbodyType2D.Dynamic;
        while (moviendoLiana)
        {
            fisica.bodyType = RigidbodyType2D.Dynamic;
            fisica.AddForce(new Vector3(fuerza, 0, 0));
            yield return new WaitForSeconds(tiempo);
            fisica.AddForce(new Vector3(-fuerza, 0, 0));
            yield return new WaitForSeconds(tiempo);
        }
    }
}
