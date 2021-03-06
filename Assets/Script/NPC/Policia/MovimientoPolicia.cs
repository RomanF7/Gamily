using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoPolicia : MonoBehaviour
{
    [SerializeField]
    private Transform transformPer;
    [SerializeField]
    private float velocidad;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Flip();
        Movimiento();
    }
    private void Movimiento()
    {
        if (DialogoNive1Noche.movimientoPolicia == true && LogicaFlecha.enContacto == false)
        {
            animator.Play("Policiacaminar");
            transform.position = Vector2.MoveTowards(transform.position, transformPer.position, velocidad*Time.deltaTime);
        }
    }

    private void Flip()
    {
        Vector3 diferencial = transformPer.position - transform.position;
        if (diferencial.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (diferencial.x <= 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && DialogoNive1Noche.movimientoPolicia == true)
        {
            DialogoNive1Noche.movimientoPolicia = false;
            LogicaFlecha.enContacto = false;
            SceneManager.LoadScene("Nivel1 (Noche)");
        }
    }
}
