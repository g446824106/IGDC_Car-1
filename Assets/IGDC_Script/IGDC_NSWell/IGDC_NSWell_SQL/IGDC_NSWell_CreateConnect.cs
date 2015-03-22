using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;
public class IGDC_NSWell_CreateConnect : IGDC_NSWell_ConnectToSql
{
    private MySqlConnection mycon = null;
    public MySqlConnection Mycon { get { return mycon; } }
    public override string GetResult()
    {
        if (ConnectToSql())
            return "Ok";
        else
            return "No";
    }
    private bool ConnectToSql()
    {
        mycon = new MySqlConnection(ServerPath);
        try
        {
            mycon.Open();
            return true;
        }
        catch (System.Exception)
        {
            Debug.LogError("无法连接服务器.");
            mycon.Close();
            return false;
        }
    }
    protected internal void Close()
    {
        mycon.Close();
    }
}
