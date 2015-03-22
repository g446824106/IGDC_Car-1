using UnityEngine;
using System.Collections;
namespace IGDC_NSWell_Enum
{
    /// <summary>
    /// 用于SQL操作状态
    /// </summary>
 public enum OperatingState
 {
     Connect,//连接
     Write,//增
     Erase,//删
     Change,//改
     Read//查
 }

}
