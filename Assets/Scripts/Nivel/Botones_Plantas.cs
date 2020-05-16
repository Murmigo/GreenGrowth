using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botones_Plantas : MonoBehaviour
{
    public Text buttonTexto;
    public GameObject Temporal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setNombreObjetoTemporal()
    {
        if (Temporal.name == "Temporal")
            Temporal.name = buttonTexto.text;
        else
            Temporal.name = "Temporal";

    }
}
