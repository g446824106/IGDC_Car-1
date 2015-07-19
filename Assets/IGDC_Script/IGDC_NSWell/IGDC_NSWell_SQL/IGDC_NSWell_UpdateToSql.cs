/**************************************************************
 * 
 *                 Script by NSWell
 *                  用于数据库更新                  
 *
 **************************************************************/
using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;
public class IGDC_NSWell_UpdateToSql : IGDC_NSWell_CreateConnect {
    /// <summary>
    /// 更新数据库表
    /// </summary>
    /// <returns></returns>
    private  bool UpdateData()
    {
        try
        {
            if (base.GetResult().CompareTo("No") == 0)
                return false;
            else
            {
                if (Alrealdy("SELECT * FROM `test` WHERE name"))
                {
                    MySqlCommand mycom = new MySqlCommand(SetSQLCommand,Mycon);
                    mycom.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log("Update error: " + ex.Message);
            return false;
        }
    }

    public IGDC_NSWell_UpdateToSql(string SQLCommand)
    {
        SetSQLCommand = SQLCommand;
        if (SetSQLCommand != null)
            if (UpdateData())
                Debug.Log("Delect");
            else
                Debug.LogError("Can not Delect");
    }
}
