using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers {
    
    public string PlayerName { get; set; }

    public string ReplaceFirst(string txt, string src, string rplc)
    {
        int pos = txt.IndexOf(src);
        if(pos < 0)
        {
            return txt;
        }

        return txt.Substring(0, pos) + "<color=grey>" + rplc + "</color>" + txt.Substring(pos + src.Length);
    }

}
