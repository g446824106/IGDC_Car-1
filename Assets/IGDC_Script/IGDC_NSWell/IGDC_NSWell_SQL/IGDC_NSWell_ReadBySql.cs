/**************************************************************
 * 
 *                 Script by NSWell
 *                  用于数据库读取                  
 *
 **************************************************************/
using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;
public class IGDC_NSWell_ReadBySql : IGDC_NSWell_CreateConnect
{
    private bool Read()
    {
        if (base.GetResult().CompareTo("No") == 0)
            return false;
        else
        {
            MySqlCommand mycmd = new MySqlCommand(SetSQLCommand, Mycon);
            MySqlDataReader reader = mycmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (reader.GetString(1).CompareTo(CompareToString) == 0 && reader.GetString(2).CompareTo(CompareToPassword)==0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Debug.Log("用户名不存在，请重试！");
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
    }



    public IGDC_NSWell_ReadBySql(string SQLCommand,string userName,string password)
    {
        CompareToString = userName;
        CompareToPassword = password;
        SetSQLCommand = SQLCommand;
        if (SetSQLCommand != null)
            if (Read())
            {
                Success = true;
                Debug.Log("登陆成功");
            }
            else
            {
                Success = false;
                Debug.LogError("无法登陆");
            }
    }
}
