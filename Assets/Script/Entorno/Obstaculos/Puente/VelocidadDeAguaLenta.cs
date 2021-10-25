using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadDeAguaLenta : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play("MovimientoAguaLento");
    }
}
