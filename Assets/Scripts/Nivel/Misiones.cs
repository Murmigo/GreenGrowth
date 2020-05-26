using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using UnityEngine;
using UnityEngine.UI;

public class Misiones : MonoBehaviour
{
    private int count = 0;
    public bool cogerMision = true;
    private SQLiteConnection connection;
    private List<Mision> listaMisiones;
    public GameObject gm;


    public GameObject m1;
    public GameObject m2;
    public GameObject m3;

    // Start is called before the first frame update
    void Start()
    {
        listaMisiones = new List<Mision>();
        connection = new SQLiteConnection(@"Data Source= " + Application.dataPath + "\\StreamingAssets\\greengrowth.db");

        connection.Open();
        SQLiteCommand command = connection.CreateCommand();
        string sqlQuery = "Select COUNT(*) FROM Misiones";
        command.CommandText = sqlQuery;
        command.CommandType = System.Data.CommandType.Text;

        IDataReader reader = command.ExecuteReader();

        while(reader.Read())
        {
            //count = reader.FieldCount;
            count = reader.GetInt32(0);
        }
        reader.Close();
        reader = null;
        command.Dispose();
        command = null;
        connection.Close();
        /*
         int value = reader.GetInt32(0);
         string name = reader.GetString(1);
         int rand = reader.GetInt32(2);
         */

    }

    // Update is called once per frame
    void Update()
    {
        if (cogerMision)
        {
            bool rnd_Ok = true;
            int rnd = -1;

            do
            {
                rnd_Ok = true;
                rnd = Random.Range(1, count);
                for (int i = 0; i < listaMisiones.Count; i++)
                {
                    if (listaMisiones[i].Id == rnd)
                        rnd_Ok = false;
                }
            } while (!rnd_Ok);

                //Debug.Log("el random es : " + rnd);

            connection = new SQLiteConnection(@"Data Source= " + Application.dataPath + "\\StreamingAssets\\greengrowth.db");
            
            connection.Open();
            SQLiteCommand command = connection.CreateCommand();
            string sqlQuery = "Select * FROM Misiones WHERE id = " + rnd;
            command.CommandText = sqlQuery;
            command.CommandType = System.Data.CommandType.Text;

            IDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int valueId = reader.GetInt32(0);
                string valueTitulo = reader.GetString(1);
                string valueDescripcion = reader.GetString(2);
                int valueObj1 = reader.GetInt32(3);
                int valueNumObj1 = reader.GetInt32(4);
                int valueObj2 = -1;
                int valueNumObj2 = 0;


                /* Hay que comprobar como pasar el campo a null, si no poner de default -1 y 0 a la base de datos */
                if (reader.GetValue(5).GetType().Equals(typeof(System.Int64)))
                {
                   // Debug.Log("Hola mundo");
                    valueObj2 = reader.GetInt32(5);
                    valueNumObj2 = reader.GetInt32(6);
                }
                int valueTiempo = reader.GetInt32(7);


                Mision nuevaMision = new Mision(valueId, valueTitulo, valueDescripcion, valueObj1, valueNumObj1, valueObj2, valueNumObj2, valueTiempo);
 
                listaMisiones.Add(nuevaMision);
                if (listaMisiones.Count >= 3)
                {
                    cogerMision = false;
                    setMisionText(listaMisiones[0], m1);
                    setMisionText(listaMisiones[1], m2);
                    setMisionText(listaMisiones[2], m3);
                }
            }
            reader.Close();
            reader = null;
            command.Dispose();
            command = null;
            connection.Close();
        }
    }

    private void setMisionText(Mision m, GameObject misionText)
    {
        misionText.GetComponent<Text>().text = m.Descripcion;
    }

    public void EntregarMision(int pos)
    {
        Mision m = listaMisiones[pos];
        List<Terreno> terrenos = gm.GetComponent<GameManager>().listaTerreno;
        List<Terreno> plantas = new List<Terreno>();
        int countObj1 = 0;
        int countObj2 = -1;

        for (int i = 0; i< terrenos.Count;i++)
        {
            if (terrenos[i].terreno_ocupado)
            {
                if (terrenos[i].plantacion.Id == m.Obj1 && terrenos[i].maduracion)
                {
                    if (countObj1 < m.NumObj1)
                    {
                        countObj1++;
                        plantas.Add(terrenos[i]);
                    }
                }
            

                if (m.Obj2 != -1)
                {
                    if(countObj2 == -1)
                        countObj2 = 0;
                    if (terrenos[i].plantacion.Id == m.Obj2 && terrenos[i].maduracion)
                    {
                        if (countObj2 < m.NumObj2)
                        {
                            countObj2++;
                            plantas.Add(terrenos[i]);
                        }
                    }

                }
            }
        }

        if (countObj1 == m.NumObj1)
        {
            if (countObj2 == m.NumObj2 || countObj2 == -1)
            {
                for (int i = 0; i < plantas.Count; i++)
                {
                    plantas[i].Eliminar();
                    Debug.Log("Entregado");

                }
                listaMisiones.RemoveAt(pos);
                cogerMision = true;
            }
        }
    }

    private void buscarPlanta(int mision)
    {
    }



}



public class Mision
{
    int id;
    string titulo;
    string descripcion;
    int obj1;
    int obj2; // default -1
    int numObj1;
    int numObj2; // default 0
    int tiempo;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Obj1 { get => obj1; set => obj1 = value; }
    public int Obj2 { get => obj2; set => obj2 = value; }
    public int NumObj1 { get => numObj1; set => numObj1 = value; }
    public int NumObj2 { get => numObj2; set => numObj2 = value; }
    public int Tiempo { get => tiempo; set => tiempo = value; }

    public Mision(int id, string titulo, string descripcion, int obj1, int numObj1, int obj2, int numObj2, int tiempo)
    {
        this.Id = id;
        this.Titulo = titulo;
        this.Descripcion = descripcion;
        this.Obj1 = obj1;
        this.NumObj1 = numObj1;
        this.Obj2 = obj2;
        this.NumObj2 = numObj2;
        this.Tiempo = tiempo;
    }

    public Mision(int id, string titulo, string descripcion, int obj1, int numObj1, int tiempo)
    {
        this.Id = id;
        this.Titulo = titulo;
        this.Descripcion = descripcion;
        this.Obj1 = obj1;
        this.NumObj1 = numObj1;
        this.Obj2 = -1;
        this.NumObj2 = 0;
        this.Tiempo = tiempo;
    }

}