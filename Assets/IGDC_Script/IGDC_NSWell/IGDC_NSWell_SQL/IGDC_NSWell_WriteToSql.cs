using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;

public class IGDC_NSWell_WriteToSql : IGDC_NSWell_CreateConnect {
    //用来插入的名称
    private string insertName=null;
    public string InsertName { get { return insertName; } set { insertName = value; } }

    private bool Write()
    {
        CompareToString = "1";
        if (base.GetResult().CompareTo("No") == 0)
            return false;
        else
        {
            Debug.Log(Alrealdy("SELECT * FROM `test` WHERE name"));
            if (!Alrealdy("SELECT * FROM `test` WHERE name"))
            {          
                MySqlCommand mycmd = new MySqlCommand(SetSQLCommand, Mycon);
                if (mycmd.ExecuteNonQuery() > 0)
                {
                    base.Close();
                    return true;
                }
                else
                {
                    base.Close();
                    return false;
                }
            }
            return false;
        }
    }
   

    /// <summary>
    /// 构造函数 写入
    /// </summary>
    /// <param name="SQLCommand"></param>
    public  IGDC_NSWell_WriteToSql(string SQLCommand)
    {
        SetSQLCommand = SQLCommand;
        if(SetSQLCommand!=null)
        {            
            if (Write())
                Debug.Log("Write");
            else
                Debug.LogError("Can not write.");
        }     
        else
            Debug.LogError("Can not write.");
    }
    public IGDC_NSWell_WriteToSql() { }
}
