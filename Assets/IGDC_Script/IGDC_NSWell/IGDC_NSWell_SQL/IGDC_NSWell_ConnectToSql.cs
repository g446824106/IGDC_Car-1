/**************************************************************
 * 
 *                 Script by NSWell
 *                  最基类               
 *
 **************************************************************/
using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;
using System;

public abstract class IGDC_NSWell_ConnectToSql {
    //使用这个 serverPath 连接服务器
    //server 服务器地址
    //User Id 数据库用户名
    //password 数据库密码
    //Databse 数据库名称
    private readonly string serverPath = "server  = localhost;User Id = root;password=;Database = cshaptest;CharSet=utf8";
    public string ServerPath { get { return serverPath; } }






    //数据库操作语句
    private string SQLCommand=null;
    public string SetSQLCommand { get { return SQLCommand==null? null:SQLCommand; } set { SQLCommand = value; } }






    //成功
    private bool success;
    public bool Success
    {
        get { return success; }
         set { success = value; }
    }







    //临时寄存当前用户输入的信息
    private string compareToString;
    public string CompareToString { get { return compareToString; } set { compareToString = value; } }





    //临时寄存当前用户输入的信息
    private string compareToPassword;
    public string CompareToPassword { get { return compareToPassword; } set { compareToPassword = value; } }







    //构造函数  用于初始化 serverPath 
    public IGDC_NSWell_ConnectToSql(string _serverPath)
    {
        this.serverPath = _serverPath;
    }






    //空构造函数
    public IGDC_NSWell_ConnectToSql()
    { 
        /*
         空 构造函数
         */
    }





    /// <summary>
    /// 返回连接结果
    /// </summary>
    /// <returns></returns>
  public  abstract string GetResult();
}
