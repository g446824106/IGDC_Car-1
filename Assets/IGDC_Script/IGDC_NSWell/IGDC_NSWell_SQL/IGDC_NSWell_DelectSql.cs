using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;
public class IGDC_NSWell_DelectSql :IGDC_NSWell_CreateConnect {
    private bool DelectAnTable()
    {
        if (base.GetResult().CompareTo("No") == 0)
            return false;
        else
        {
            CompareToString = "1";
            Debug.Log(Alrealdy("SELECT * FROM `test` WHERE name"));
            if (Alrealdy("SELECT * FROM `test` WHERE name"))
            {
                try
                {
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
