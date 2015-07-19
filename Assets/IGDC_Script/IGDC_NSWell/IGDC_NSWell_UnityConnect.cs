/**************************************************************
 * 
 *                 Script by NSWell
 *                  用于连接数据库类
 *                  将本类添加到GameObject上面即可
 *                  这个类提供 Register 和 Login方法
 *
 **************************************************************/
using UnityEngine;
using System.Collections;
public class IGDC_NSWell_UnityConnect : MonoBehaviour
{    
    /// <summary>
    /// 操作模式
    /// </summary>
    private IGDC_NSWell_Enum.OperatingState state = IGDC_NSWell_Enum.OperatingState.Write;
    public IGDC_NSWell_Enum.OperatingState State
    {
        get { return state; }
        set { state = value; }
    }

    IGDC_NSWell_ConnectToSql INCT = null;



    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="userPassword">密码</param>
    /// <param name="userEmail">邮箱</param>
    /// <returns></returns>
   protected internal bool Register(string userName,string userPassword,string userEmail)
    {
       IGDC_NSWell_SqlFactory INSF = new IGDC_NSWell_SqlFactory();
       string commnad ="INSERT INTO `test`(`id`,`name`, `password`, `email`)  Values ('','"+userName+"','"+userPassword+"','"+userEmail+"')";
       INCT = INSF.Factory(IGDC_NSWell_Enum.OperatingState.Write, commnad);
       INCT.CompareToString = userName;
       return INCT.Success;                 
   }




    /// <summary>
    /// 登陆
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="userPassword">密码</param>
    /// <returns></returns>
   protected internal bool Login(string userName, string userPassword)
   {
     
       IGDC_NSWell_SqlFactory INSF = new IGDC_NSWell_SqlFactory();
       string commnad = "SELECT * FROM `test` WHERE " + userName;
       INSF.TempName = userName;
       INSF.TempPassword = userPassword;
       INCT = INSF.Factory(IGDC_NSWell_Enum.OperatingState.Read, commnad);       
       return INCT.Success;
   }
}
