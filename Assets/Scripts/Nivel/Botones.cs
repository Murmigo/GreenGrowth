using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
    public GameObject misionPanel;
    public GameObject plantasPanel;
    public GameObject accionesPanel;
    public bool eliminarActivado = false;
    public bool btn_plantaActivada = false;


    public bool AguaActive = false;
    public bool LuzActive = false;
    public bool TempActive = false;
    public bool AbonoActive = false;



    public void activarDesactivarPlantaBoton()
    {
        if (btn_plantaActivada)
            btn_plantaActivada = false;
        else
        {
            btn_plantaActivada = true;
        }
    }

    //ACCIONES
    private void setBooleanButtonsFalse()
    {
        AguaActive = false;
        LuzActive = false;
        TempActive = false;
        AbonoActive = false;
        eliminarActivado = false;
    }

    public void AguaPulsado()
    {
        if (AguaActive)
        {
            AguaActive = false;

        }
        else
        {
            setBooleanButtonsFalse();
            AguaActive = true;
            mostrarMisiones();
            mostrarPlantas();
        }
    }

    public void LuzPulsado()
    {
        if (LuzActive)
        {
            LuzActive = false;

        }
        else
        {
            setBooleanButtonsFalse();
            LuzActive = true;
            mostrarMisiones();
            mostrarPlantas();
        }
    }

    public void TempPulsado()
    {
        if (TempActive)
        {
            TempActive = false;

        }
        else
        {
            setBooleanButtonsFalse();
            TempActive = true;
            mostrarMisiones();
            mostrarPlantas();
        }
    }

    public void AbonoPulsado()
    {
        if (AbonoActive)
        {
            AbonoActive = false;

        }
        else
        {
            setBooleanButtonsFalse();
            AbonoActive = true;
            mostrarMisiones();
            mostrarPlantas();
        }
    }



    private void Start()
    {
        misionPanel = GameObject.Find("Misiones");
        plantasPanel = GameObject.Find("Plantas");
        accionesPanel = GameObject.Find("Acciones");
    }

    public void mostrarMisiones()
    {

        if (!misionPanel.activeSelf)
        {
            misionPanel.SetActive(true);
        }
        else
        {
            misionPanel.SetActive(false);
        }

    }
    public void mostrarPlantas()
    {
        

        if (!plantasPanel.activeSelf)
        {
            plantasPanel.SetActive(true);
        }
        else
        {
            plantasPanel.SetActive(false);
        }
    }

    public void mostrarAcciones()
    {
        if (!accionesPanel.activeSelf)
        {
            accionesPanel.SetActive(true);
        }
        else
        {
            accionesPanel.SetActive(false);
        }
    }

    public void eliminarPlanta()
    {
        if (!eliminarActivado)
        {
            eliminarActivado = true;
        }
        else
            eliminarActivado = false;

    }

    public void mostrarPaneles()
    {
        if (!plantasPanel.activeSelf)
            mostrarPlantas();
        if (!misionPanel.activeSelf)
            mostrarMisiones();

    }

}
