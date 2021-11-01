using System.Collections;
using UnityEngine;

public class BacteriaLiana : MonoBehaviour
{
    private Rigidbody2D fisica;
    [SerializeField]
    private float fuerza, tiempo;

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        StartCoroutine(Movimiento());
    }

    IEnumerator Movimiento()
    {
        Debug.Log("IEnumerator called.");
        while (true)
        {
            if (!Jeringas.pararTiempo)
            {
                fisica.bodyType = RigidbodyType2D.Dynamic;
                fisica.AddForce(new Vector3(fuerza, 0, 0));
                yield return new WaitForSeconds(tiempo);
                fisica.AddForce(new Vector3(-fuerza, 0, 0));
                yield return new WaitForSeconds(tiempo);
            }
            else
            {
                Debug.Log(fisica.inertia);
                fisica.bodyType = RigidbodyType2D.Static;
                yield return new WaitForSeconds(3f);
            }
        }
    }
}
