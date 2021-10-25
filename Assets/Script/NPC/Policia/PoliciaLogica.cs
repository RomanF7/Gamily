using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliciaLogica : MonoBehaviour
{
    private Animator animator;
    private bool empiezaCharla;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        empiezaCharla = true;
    }
}
