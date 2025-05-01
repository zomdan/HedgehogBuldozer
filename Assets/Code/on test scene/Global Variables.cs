using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int SequenceCode = 10;
}

/* How to change these variables in other scripts: GlobalVariable.variableName = value;
    How to use it in a condition (most likely use case is in update method): if (GlobalVariable.variableName == value){}
*/