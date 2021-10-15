using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPasto : MonoBehaviour
{
    public Material pasto;

    private void Start()
    {
        pasto.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            pasto.SetTextureOffset("_MainTex", new Vector2(pasto.GetTextureOffset("_MainTex").x + 0.005f, 0f));
        }

        if (Input.GetKey(KeyCode.A))
        {
            pasto.SetTextureOffset("_MainTex", new Vector2(pasto.GetTextureOffset("_MainTex").x - 0.005f, 0f));
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
