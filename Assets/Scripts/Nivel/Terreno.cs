using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terreno : MonoBehaviour
{

    //Variables del terreno
    private int _agua;
    private int _luz;
    private int _temp;
    private int _abono;


    //Encapsulamiento(GETTER & SETTERS)
    public int Agua { get => _agua; set => _agua = value; }
    public int Luz { get => _luz; set => _luz = value; }
    public int Temp { get => _temp; set => _temp = value; }
    public int Abono { get => _abono; set => _abono = value; }

    //Si el estado es falso, la planta se marchita, si es true la planta no lo hace y crece
    private int marchito = 10;
    public bool estadoOk = false;
    private int contadorEstado = 0;

    private int edad = 0;
    private int mesActual = 0;
    private int añoDePlantacion = 0;
    //Variables de uso del Script
    public GameManager gm;
    private Planta plantacion = null;
    private bool btn_plantaPulsada;
    private bool terreno_ocupado = false;
    private GameObject instanciaActual = null;
    public GameObject Temporal;
   
    // Update is called once per frame
    void Update()
    {
        if (instanciaActual != null)
        {
            if (Agua < plantacion.AguaMin || Agua > plantacion.AguaMax)
            {
                estadoOk = false;
            }
            else if (Luz < plantacion.LuzMin || Luz > plantacion.LuzMax)
            {
                estadoOk = false;
            }
            else if (Temp < plantacion.TempMin || Temp > plantacion.TempMax)
            {
                estadoOk = false;
            }
            else if (Abono < plantacion.AbonoMin || Abono > plantacion.AbonoMax)
            {
                estadoOk = false;
            }
            else
            {
                estadoOk = true;
            }

            edad = gm.year - añoDePlantacion;
            

            if (!estadoOk)
            {
                if (gm.month != mesActual)
                {
                    mesActual = gm.month;
                    contadorEstado++;
                }
            }
            else
            {
                
            }

            if (contadorEstado > marchito)
            {
                Eliminar();
                Debug.Log("La planta murió");
            }
        }
    }

    private void OnMouseDown()
    {
        if (terreno_ocupado)
        {
            if (gm.GetComponent<Botones>().AguaActive)
            {
                Agua += 5;
                Debug.Log(Agua);
                gm.GetComponent<Botones>().mostrarPaneles();
                gm.GetComponent<Botones>().AguaPulsado();
            }
            else if (gm.GetComponent<Botones>().LuzActive)
            {
                Luz += 5;
                Debug.Log(Luz);
                gm.GetComponent<Botones>().mostrarPaneles();
            }
            else if (gm.GetComponent<Botones>().TempActive)
            {
                Temp += 5;
                Debug.Log(Temp);
                gm.GetComponent<Botones>().mostrarPaneles();
            }
            else if (gm.GetComponent<Botones>().AbonoActive)
            {
                Abono += 5;
                Debug.Log(Abono);
                gm.GetComponent<Botones>().mostrarPaneles();
            }

            if (gm.GetComponent<Botones>().eliminarActivado)
            {
                gm.GetComponent<Botones>().eliminarPlanta();
                Eliminar();
                gm.GetComponent<Botones>().mostrarPaneles();
            }
        }
        else {

            if (gm.GetComponent<Botones>().btn_plantaActivada && Temporal.name != "Temporal")
            {
                Instanciar();
                añoDePlantacion = gm.year;
                mesActual = gm.month;
            }
            if (gm.GetComponent<Botones>().AguaActive) {

                Agua += 5;
            }

        }
          
    }
    private void Instanciar()
    {
        Debug.Log("Has clickado el terreno");
        string nombrePlanta = Temporal.name;
        Temporal.name = "Temporal";
        plantacion = gm.elegirPlanta(nombrePlanta);
        GameObject instanciaPlanta = (GameObject)Resources.Load("Prefabs/" + nombrePlanta, typeof(GameObject));
        instanciaActual = Instantiate(instanciaPlanta, this.transform.position, Quaternion.identity);

        terreno_ocupado = true;

        gm.GetComponent<Botones>().mostrarAcciones();
        if (!gm.GetComponent<Botones>().misionPanel.activeSelf)
            gm.GetComponent<Botones>().mostrarMisiones();

        gm.GetComponent<Botones>().activarDesactivarPlantaBoton();

        edad = 0;
    }

    private void Eliminar()
    {
            //Crear subrutina de animación para cuando la planta mueren
            plantacion = null;
            Destroy(instanciaActual.gameObject.gameObject);
            instanciaActual = null;
            terreno_ocupado = false;

           

    }
}
