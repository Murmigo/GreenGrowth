using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SQLite;

public class DBConnector : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log(Application.dataPath);
        //string URL = Application.dataPath + "\BBDD\greengrowth.db;Version=3;";
        SQLiteConnection connection = new SQLiteConnection(@"Data Source= " + Application.dataPath + "\\StreamingAssets\\greengrowth.db;Version=3;");
        connection.Open();
        SQLiteCommand command = connection.CreateCommand();
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText =
                            "CREATE TABLE IF NOT EXISTS 'Plantas' ( " +
                          "  'Id' INTEGER PRIMARY KEY, " +
                          "  'Tipo' TEXT NOT NULL, " +
                          "  'Nombre' TEXT NOT NULL, " +
                          "  'Crecimiento_Fase1' INTEGER NOT NULL, " +
                          "  'Crecimiento_Fase2' INTEGER, " +
                          "  'Crecimiento_Fase3' INTEGER, " +
                          "  'Agua_min' INTEGER NOT NULL, " +
                          "  'Agua_MAX' INTEGER NOT NULL, " +
                          "  'Luz_min' INTEGER NOT NULL, " +
                          "  'Luz_MAX' INTEGER NOT NULL, " +
                          "  'Temp_min' INTEGER NOT NULL, " +
                          "  'Temp_MAX' INTEGER NOT NULL, " +
                          "  'Abono_min' INTEGER NOT NULL, " +
                          "  'Abono_MAX' INTEGER NOT NULL" +
                          "); \n" +
                          "CREATE TABLE IF NOT EXISTS 'Misiones' ( " +
                          "  'Id' INTEGER PRIMARY KEY AUTOINCREMENT, " +
                          "  'Titulo' TEXT NOT NULL, " +
                          "  'Descripcion' TEXT NOT NULL, " +
                          "  'Objetivo_1' INTEGER NOT NULL, " +
                          "  'Numero_Objetivo_1' INTEGER NOT NULL, " +
                          "  'Objetivo_2' INTEGER, " +
                          "  'Numero_Objetivo_2' INTEGER, " +
                          "  'Tiempo' INTEGER NOT NULL," +
                          "  FOREIGN KEY(Objetivo_1) REFERENCES Plantas(id)," +
                          "  FOREIGN KEY(Objetivo_2) REFERENCES Plantas(id)" +
                          ");";

        command.ExecuteNonQuery();
        command.ExecuteNonQuery();
        connection.Close();

        /* WOn't work in STANDALONE??
         The reason is that Unity will put the native library into the YourAppName/YourAppName_Data/Plugins directory.
         The wrapper (managed library), however, will look for the native library in the YourAppName/YourAppName_Data/Mono directory, which actually does not exist.
         So, to get your application working correctly, create the YourAppName/YourAppame_Data/Mono directory and copy the SQLite.Interop.dll file
         from the YourAppName/YourAppName_Data/Plugins directory into it
         */
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
