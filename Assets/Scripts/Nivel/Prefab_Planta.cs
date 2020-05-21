using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.Data.SQLite;

public class Prefab_Planta : MonoBehaviour
{

    public Planta pl;
    private List<Image> plantaCrecimiento;
    private int _estadoCrecimiento;

    public int EstadoCrecimiento { get => _estadoCrecimiento; set => _estadoCrecimiento = value; }

    // Start is called before the first frame update
    void Start()
    {
        EstadoCrecimiento = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

public class Planta
{
    private int _id;
    private string _nombre;
    private List<int> _crecimiento = new List<int>();
    private int _aguaMin;
    private int _luzMin;
    private int _tempMin;
    private int _abonoMin;
    private int _aguaMax;
    private int _luzMax;
    private int _tempMax;
    private int _abonoMax;

    public Planta()
    {

    }
    public Planta(int id, string nombre, List<int> crecimiento, int aguaMin, int luzMin, int tempMin, int abonoMin, int aguaMax, int luzMax, int tempMax, int abonoMax)
    {
        Id = id;
        Nombre = nombre;
        Crecimiento = crecimiento;
        AguaMin = aguaMin;
        LuzMin = luzMin;
        TempMin = tempMin;
        AbonoMin = abonoMin;
        AguaMax = aguaMax;
        LuzMax = luzMax;
        TempMax = tempMax;
        AbonoMax = abonoMax;
    }

    public int Id { get => _id; set => _id = value; }
    public string Nombre { get => _nombre; set => _nombre = value; }
    public List<int> Crecimiento { get => _crecimiento; set => _crecimiento = value; }
    public int AguaMin { get => _aguaMin; set => _aguaMin = value; }
    public int LuzMin { get => _luzMin; set => _luzMin = value; }
    public int TempMin { get => _tempMin; set => _tempMin = value; }
    public int AbonoMin { get => _abonoMin; set => _abonoMin = value; }
    public int AguaMax { get => _aguaMax; set => _aguaMax = value; }
    public int LuzMax { get => _luzMax; set => _luzMax = value; }
    public int TempMax { get => _tempMax; set => _tempMax = value; }
    public int AbonoMax { get => _abonoMax; set => _abonoMax = value; }

    
}
