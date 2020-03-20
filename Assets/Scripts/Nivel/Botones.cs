using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
    GameObject misionPanel;
    GameObject plantasPanel;
    private void Start()
    {
        misionPanel = GameObject.Find("Misiones");
        plantasPanel = GameObject.Find("Plantas");
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
}
