using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //(minimum amount of text lines used, maximum amount of text lines used)
    [TextArea(3,10)]
    public string[] sentences;


}
