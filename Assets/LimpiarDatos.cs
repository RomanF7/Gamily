using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimpiarDatos : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
}
