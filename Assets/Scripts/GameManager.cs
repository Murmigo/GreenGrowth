using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int day = 1;
    public int month = 1;
    public int year = 0;

    public Text text;

    private bool ejecutandoDia = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(pasarDia());
        Debug.Log("Hoy es fecha: " + day + "/" + month + "/" + year);
        text.text = "Fecha: " + day + "/" + month + "/" + year;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ejecutandoDia)
        {
            StartCoroutine(pasarDia());

        }
    }

    private void FixedUpdate()
    {
        if (day > 30)
        {
            actualizarFecha();
        }
        text.text = "Fecha: " + day + "/" + month + "/" + year;
    }

    private IEnumerator pasarDia()
    {
        ejecutandoDia = true;
        //___________________________________________________________________________
        yield return new WaitForSecondsRealtime(1); //Para pruebas recordar borrar
        //___________________________________________________________________________
        //yield return new WaitForSecondsRealtime(240);
        day++;
        ejecutandoDia = false;
    }

    private void actualizarFecha()
    {
        month++;
        day = 1;
        if (month > 12)
        {
            year++;
            month = 1;
        }
    }
}
