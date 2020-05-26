using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    // Game Instance Singleton
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public int day = 1;
    public int month = 1;
    public int year = 0;

    public Text text;

    private bool ejecutandoDia = false;

    public List<Terreno> listaTerreno;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(pasarDia());
        //Debug.Log("Hoy es fecha: " + day + "/" + month + "/" + year);
        text.text = "Fecha: " + day + "/" + month + "/" + year;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ejecutandoDia)
        {
            StartCoroutine(pasarDia());

        }
        text.text = "Fecha: " + day + "/" + month + "/" + year;
    }

    private void FixedUpdate()
    {
        if (day > 30)
        {
            actualizarFecha();
        }
        
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

        for (int i = 0; i < listaTerreno.Count; i++)
        {
            if(listaTerreno[i].terreno_ocupado)
                listaTerreno[i].GetComponent<Terreno>().restarCapacidades();
        }
    }

    public Planta elegirPlanta(string nombre)
    {
        Planta pt = new Planta();
        SQLiteConnection connection;
        connection = new SQLiteConnection(@"Data Source= " + Application.dataPath + "\\StreamingAssets\\greengrowth.db;Version=3;");

        connection.Open();
        SQLiteCommand command = connection.CreateCommand();
        string sqlQuery = "Select * FROM Plantas WHERE Nombre = '"  + nombre + "';";
        command.CommandText = sqlQuery;
        command.CommandType = System.Data.CommandType.Text;

        IDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            pt.Id = reader.GetInt32(0);
            pt.Nombre = reader.GetString(2);

            pt.Crecimiento.Add(reader.GetInt32(3));
            if (reader.GetValue(4).GetType().Equals(typeof(System.Int64)))
            {
                pt.Crecimiento.Add(reader.GetInt32(4));

                if (reader.GetValue(5).GetType().Equals(typeof(System.Int64)))
                    pt.Crecimiento.Add(reader.GetInt32(5));
            }

            pt.AguaMin = reader.GetInt32(6);
            pt.AguaMax = reader.GetInt32(7);
            pt.LuzMin = reader.GetInt32(8);
            pt.LuzMax = reader.GetInt32(9);
            pt.TempMin = reader.GetInt32(10);
            pt.TempMax = reader.GetInt32(11);
            pt.AbonoMin = reader.GetInt32(12);
            pt.AbonoMax = reader.GetInt32(13);
        }
        reader.Close();
        reader = null;
        command.Dispose();
        command = null;
        connection.Close();

        return pt;
    }
}
