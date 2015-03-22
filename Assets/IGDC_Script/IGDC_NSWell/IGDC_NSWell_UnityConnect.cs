using UnityEngine;
using System.Collections;

public class IGDC_NSWell_UnityConnect : MonoBehaviour
{
    private string serverPath; 
    private IGDC_NSWell_Enum.OperatingState state;
    private string[] matchingKeywords;
    private string[] SQLSentence;
    public string ServerPath
    {
        get { return serverPath; }
        private set { serverPath = value; }
    }

    public string[] SQLSentence1 
    {
        get { return SQLSentence; }
        set { SQLSentence = value; }
    }

    public string[] MatchingKeywords
    {
        get { return matchingKeywords; }
        set { matchingKeywords = value; }
    }
  
    public IGDC_NSWell_Enum.OperatingState State
    {
        get { return state; }
        set { state = value; }
    }
   void Start()
    {
        IGDC_NSWell_ConnectToSql INCT=null;
        IGDC_NSWell_SqlFactory INSF = new IGDC_NSWell_SqlFactory();
        INCT = INSF.Factory(state,SQLSentence[0]);
    }
}
