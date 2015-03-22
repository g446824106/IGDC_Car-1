using UnityEngine;
using System.Collections;
public class IGDC_NSWell_SqlFactory
{
    /// <summary>
    /// 生产出对应操作类
    /// </summary>
    /// <param name="_State"></param>
    public IGDC_NSWell_ConnectToSql Factory(IGDC_NSWell_Enum.OperatingState _State,string SQLSentens)
    {
        IGDC_NSWell_ConnectToSql sql = null;        
        switch (_State)
        {
            case IGDC_NSWell_Enum.OperatingState.Connect:
                sql = new IGDC_NSWell_CreateConnect();
                break;
            case IGDC_NSWell_Enum.OperatingState.Write:
                sql = new IGDC_NSWell_WriteToSql(SQLSentens);//"insert into test(name,password,email) values('1','dikd3939','1134384387@qq.com')"
                break;
            case IGDC_NSWell_Enum.OperatingState.Erase:
                sql = new IGDC_NSWell_DelectSql(SQLSentens);//"DELETE FROM `test` WHERE name ='1'"
                break;
            case IGDC_NSWell_Enum.OperatingState.Change:
                sql = new IGDC_NSWell_UpdateToSql(SQLSentens);//"update test set password='往往' where name= 1"
                break;
            case IGDC_NSWell_Enum.OperatingState.Read:
                break;
        }
        return sql;
    }
}
