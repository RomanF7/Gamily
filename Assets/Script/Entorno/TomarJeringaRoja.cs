using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarJeringaRoja : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer jeringaRoja;
    [HideInInspector]
    public static bool tenerJR = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            jeringaRoja.enabled = true;
            Destroy(gameObject);
            tenerJR = true;
        }
    }
}
