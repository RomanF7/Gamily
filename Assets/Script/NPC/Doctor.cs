using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    [HideInInspector]
    public static bool visitaAlDoctor = false;

    [SerializeField]
    private SpriteRenderer jeringaRoja;
    private Animator animator;
    private float[] cronometro;
    private bool roto = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        cronometro = new float[2];
        cronometro[0] = 0;
        cronometro[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= cronometro[0] && cronometro[0] != 0)
        {
            Movimiento();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && visitaAlDoctor == false)
        {
            visitaAlDoctor = true;
            cronometro[0] = Time.time + 3;
            cronometro[1] = Time.time + 5;
        }
    }

    private void Movimiento()
    {

        if (Time.time >= cronometro[1] && roto == false)
        {
            animator.enabled = false;
            jeringaRoja.enabled = true;
            roto = true;
        }
        else if(roto == false)
        {
            animator.Play("CaminarDoctor");
            transform.Translate(2f * Time.deltaTime, 0, 0);
        }
    }
}
