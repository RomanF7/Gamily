using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogosDeDoctor : MonoBehaviour
{

    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas canvasDialogo;
    private int click = 7;
    private void Dialogo()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            click++;
        }


    }
}
