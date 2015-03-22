using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;

public class IGDC_NSWell_WriteToSql : IGDC_NSWell_CreateConnect {
    //用来插入的名称
    private string insertName=null;
    public string InsertName { get { return insertName; } set { insertName = value; } }

    private bool Write()
    {
        if (base.GetResult().CompareTo("No") == 0)
        {
            return false;
        }
        else
        {
            Debug.LogError(Alreadly("SELECT * FROM `test` WHERE name"));
            if (Alreadly("SELECT * FROM `test` WHERE name"))
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
    /// 判断正要插入的对象是否存在数据库中
    /// </summary>
    /// <param name="_SetSQLCommand"></param>
    /// <returns></returns>
    private bool Alreadly(string _SetSQLCommand)
    {
        MySqlCommand mycmd = new MySqlCommand(_SetSQLCommand, Mycon);
        MySqlDataReader reader = mycmd.ExecuteReader();
        try
        {
            while (reader.Read())
            {              
                if (reader.HasRows)
                {
                    if (reader.GetString(0).CompareTo(InsertName) == 0)
                    {
                        Debug.Log("An user are already!!Try other,please!");
                        return false;
                    }
                }
                else
                    return true;
            }
        }
        catch (System.Exception)
        {            
            Debug.LogError("无法查询数据库");           
        }
        finally { reader.Close(); }
        return true;
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
