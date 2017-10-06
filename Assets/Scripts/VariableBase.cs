using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VariableBase {

    private static Vector3[] cameraPositions = { new Vector3(1810f, 0f, 4.3f),
                                                new Vector3(1870f, 0f, 7f),
                                                new Vector3(1916.4f, 0f, 4.3f),
                                                new Vector3(1970.38f, 0f, 4.3f) };

    public static bool initiatePositions(Vector3[] positions)
    {
        cameraPositions = positions;
        return true;
    }

    public static bool setCameraPosition(int index, Vector3 position)
    {
        cameraPositions[index] = position;
        return true;
    }

    public static Vector3 getCameraPosition(int index)
    {
       return cameraPositions[index];
    }

}
