using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flechitas : MonoBehaviour
{
    public Button btn_flechitaDerecha, btn_flechitaIzquierda;
    public Sprite[] barritas;
    public Image barras;
    // Start is called before the first frame update
    void Start()
    {
        btn_flechitaDerecha.onClick.AddListener(BTN_DerechaOnClick);
        btn_flechitaIzquierda.onClick.AddListener(BTN_IzquierdaOnClick);
    }


    void BTN_DerechaOnClick()
    {
        int aux = 0;
        for (int i = 0; i < barritas.Length; i++)
        {
            if (barras.sprite == barritas[i])
            {
                aux = i;
            }
        }

        switch (aux)
        {
            case 0:
                barras.sprite = barritas[1];
                break;

            case 1:
                barras.sprite = barritas[2];
                break;
            case 2:
                barras.sprite = barritas[3];
                break;
            case 3:
                barras.sprite = barritas[4];
                break;
            case 4:
                barras.sprite = barritas[5];
                break;
        }
    }

    void BTN_IzquierdaOnClick()
    {
        int aux = 0;
        for (int i = 0; i < barritas.Length; i++)
        {
            if (barras.sprite == barritas[i])
            {
                aux = i;
            }
        }

        switch (aux)
        {
            case 5:
                barras.sprite = barritas[4];
                break;
            case 4:
                barras.sprite = barritas[3];
                break;
            case 3:
                barras.sprite = barritas[2];
                break;
            case 2:
                barras.sprite = barritas[1];
                break;
            case 1:
                barras.sprite = barritas[0];
                break;
        }
    }
}
