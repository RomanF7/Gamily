using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaltoRampa : MonoBehaviour
{
    public Button btn_FlechaIDerecha, btn_FlechaIzquierda;
    public Sprite[] barraIndividual;
    public Image imgBarras;
    // Start is called before the first frame update
    void Start()
    {
        btn_FlechaIDerecha.onClick.AddListener(BTN_DerechaOnClick);
        btn_FlechaIzquierda.onClick.AddListener(BTN_IzquierdaOnClick);
    }

    public void BTN_DerechaOnClick()
    {
        int aux = 0;
        for (int i = 0; i < barraIndividual.Length; i++)
        {
            if (imgBarras.sprite == barraIndividual[i])
            {
                aux = i;
            }
        }

        switch (aux)
        {
            case 0:
                imgBarras.sprite = barraIndividual[1];
                break;

            case 1:
                imgBarras.sprite = barraIndividual[2];
                break;
            case 2:
                imgBarras.sprite = barraIndividual[3];
                break;
            case 3:
                imgBarras.sprite = barraIndividual[4];
                break;
            case 4:
                imgBarras.sprite = barraIndividual[5];
                break;
        }
    }

    public void BTN_IzquierdaOnClick()
    {
        int aux = 0;
        for (int i = 0; i < barraIndividual.Length; i++)
        {
            if (imgBarras.sprite == barraIndividual[i])
            {
                aux = i;
            }
        }

        switch (aux)
        {
            case 5:
                imgBarras.sprite = barraIndividual[4];
                break;
            case 4:
                imgBarras.sprite = barraIndividual[3];
                break;
            case 3:
                imgBarras.sprite = barraIndividual[2];
                break;
            case 2:
                imgBarras.sprite = barraIndividual[1];
                break;
            case 1:
                imgBarras.sprite = barraIndividual[0];
                break;
        }
    }
}
