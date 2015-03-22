using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;
public class IGDC_NSWell_DelectSql :IGDC_NSWell_CreateConnect {
    private string delectTableID="1";
    private bool DelectAnTable()
    {
        if (base.GetResult().CompareTo("No") == 0)
            return false;
        else
        {
            if (Alreadly("SELECT * FROM `test` WHERE name"))
            {
                try
                {
                    Debug.LogError(SetSQLCommand);
                    Debug.Log("Run");
                    MySqlCommand mycom = new MySqlCommand(SetSQLCommand,Mycon);
                    mycom.ExecuteNonQuery();
                    return true;
                }
                catch (System.Exception ex)
                {
                    Debug.LogError("Can delect "+ex.Message);
                }
            }
        }
        return false;
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
                    if (reader.GetString(0).CompareTo(delectTableID) == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    Debug.Log("An user are not already!!Try other,please!");
                    return false;
                }
            }
        }
        catch (System.Exception)
        {
            Debug.LogError("无法查询数据库");
        }
        finally { reader.Close(); }
        return false;
    }

    public IGDC_NSWell_DelectSql(string SQLCommand)
    {
        SetSQLCommand = SQLCommand;
        if (SetSQLCommand != null)
            if (DelectAnTable())
                Debug.Log("Delect");
            else
                Debug.LogError("Can not Delect");
    }
}
