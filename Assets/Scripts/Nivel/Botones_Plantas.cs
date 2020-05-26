using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Botones_Plantas : MonoBehaviour, IPointerEnterHandler
{
    public Text buttonTexto;
    public GameObject Temporal;
    public Planta plantacion = null;
    public GameManager gm;
    public Text output;

    public void OnPointerEnter(PointerEventData eventData)
    {
       plantacion =  gm.elegirPlanta(buttonTexto.text);
        int aguaMed = (plantacion.AguaMin + plantacion.AguaMax) / 2;
        int luzMed = (plantacion.LuzMin + plantacion.LuzMax) / 2;
        int abonoMed = (plantacion.AbonoMin + plantacion.AbonoMax) / 2;
        int tempMed = (plantacion.TempMin + plantacion.TempMax) / 2;
        output.text = "Agua: " + conversorEstrellas(aguaMed) + "\nLuz: " + conversorEstrellas(luzMed) + "\nAbono: " + conversorEstrellas(abonoMed) + "\nTemperatura: " + conversorEstrellas(tempMed);
    }

    private string conversorEstrellas(int num)
    {
        string conversor = "";

        if (0 >= num && num <= 20)
        {
            conversor = "*";
        } else if (20 > num && num <= 40)
        {
            conversor = "**";
        }
        else if (40 > num && num <= 60)
        {
            conversor = "***";
        }
        else if (60 > num && num <= 80)
        {
            conversor = "****";
        }
        else if (80 > num && num <= 100)
        {
            conversor = "*****";
        }


        return conversor;
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
