using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    public static bool visitaAlDoctor;
    public SpriteRenderer jeringaRoja;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public float[] cronometro;
    [HideInInspector]
    public bool agarrarJeringa = false;

    public static Doctor instancia;
    private void Awake()
    {
        if (visitaAlDoctor == true) { visitaAlDoctor = true; }
        animator = GetComponent<Animator>();
        cronometro = new float[2];
        cronometro[0] = 0;
        cronometro[1] = 0;
        instancia = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= cronometro[0] && cronometro[0] != 0)
        {
            Movimiento();
        }
    }

    public void Movimiento()
    {

        if (Time.time >= cronometro[1] && agarrarJeringa == false)
        {
            animator.enabled = false;
            jeringaRoja.enabled = true;
            agarrarJeringa = true;
        }
        else if (agarrarJeringa == false)
        {
            animator.Play("CaminarDoctor");
            transform.Translate(2f * Time.deltaTime, 0, 0);
        }
    }
}
