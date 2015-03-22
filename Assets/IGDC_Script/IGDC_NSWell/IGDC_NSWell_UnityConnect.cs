using UnityEngine;
using System.Collections;

public class IGDC_NSWell_UnityConnect : MonoBehaviour
{
   public IGDC_NSWell_Enum.OperatingState state;
   void Start()
    {
        IGDC_NSWell_ConnectToSql INCT=null;
        IGDC_NSWell_SqlFactory INSF = new IGDC_NSWell_SqlFactory();
        INCT = INSF.Factory(state);
    }
}
