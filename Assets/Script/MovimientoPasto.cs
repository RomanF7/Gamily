using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPasto : MonoBehaviour
{
    public Material pasto;
    private float horizontal;


    private void Start()
    {
        pasto.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (MenuPausa.enPausa == false)
        {
            if (horizontal == 1)
            {
                pasto.SetTextureOffset("_MainTex", new Vector2(pasto.GetTextureOffset("_MainTex").x + 0.002f, 0f));
            }
            else if (horizontal == -1)
            {
                pasto.SetTextureOffset("_MainTex", new Vector2(pasto.GetTextureOffset("_MainTex").x - 0.002f, 0f));
            }

            if (pasto.GetTextureOffset("_MainTex").x >= 1)
            {
                pasto.SetTextureOffset("_MainTex", new Vector2(-0.90f, 0f));
            }
            else if (pasto.GetTextureOffset("_MainTex").x <= -1)
            {
                pasto.SetTextureOffset("_MainTex", new Vector2(0.90f, 0f));
            }
        }
    }
}
