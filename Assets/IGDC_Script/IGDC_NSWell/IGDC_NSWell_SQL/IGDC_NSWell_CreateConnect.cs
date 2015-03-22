/**************************************************************
 * 
 *                 Script by NSWell
 *                  用于数据库的连接
 *
 **************************************************************/
using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;
public class IGDC_NSWell_CreateConnect : IGDC_NSWell_ConnectToSql
{

    //开启连接
    private MySqlConnection mycon = null;
    public MySqlConnection Mycon { get { return mycon; } }

    /// <summary>
    /// 返回连接结果
    /// </summary>
    /// <returns></returns>
    public override string GetResult()
    {
        if (ConnectToSql())
        {
            Debug.Log("连接数据库成功。");
            return "Ok";
        }
        else
            return "No";
    }


    /// <summary>
    /// 连接数据库
    /// </summary>
    /// <returns></returns>
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
            Debug.LogError("无法连接服务器。");
            mycon.Close();
            return false;
        }
    }


    /// <summary>
    /// 关闭连接
    /// </summary>
    protected internal void Close()
    {
        mycon.Close();
    }


    /// <summary>
    /// 判断正要插入的对象是否存在数据库中
    /// </summary>
    /// <param name="_SetSQLCommand"></param>
    /// <returns></returns>
    public  bool Alrealdy(string _SetSQLCommand)
    {
        MySqlCommand mycmd = new MySqlCommand(_SetSQLCommand, Mycon);
        MySqlDataReader reader = mycmd.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    if (reader.GetString(0).CompareTo(CompareToString) == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    Debug.Log("用户已存在，请重试!");
                    return false;
                }
            }
        }
        catch (System.Exception)
        {
            Debug.LogError("无法查询数据库。");
        }
        finally { reader.Close(); }
        return false;
    }
}
