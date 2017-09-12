using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VariableBase {

    // variables
    private static bool isIn = false;


    // set functions
    public static bool isItIn() { return isIn; }

    // get functions
    public static void setIsIn(bool temp) { isIn = temp; }

}
