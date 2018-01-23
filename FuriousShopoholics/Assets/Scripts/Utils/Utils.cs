using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{

    [Range(0, 100)] private static int _idTreeCounter = 0;
    private static int _idNodeCounter = 100;

    public static int GetTreeId()
    {
        if(_idTreeCounter >= 99)
        {
            _idTreeCounter = 0;
        }
        _idTreeCounter++;

        return _idTreeCounter;
    }

    public static int GetNodeId()
    {
        _idNodeCounter++;
        return _idNodeCounter;
    }

    public static void CreateArrayCopy<T>(T[] existingArray, out T[] arrayCopy)
    {
        arrayCopy = new T[existingArray.Length];
        for(int i = 0; i < arrayCopy.Length; i++)
        {
            arrayCopy[i] = existingArray[i]; 
        }

        return;
    }

    public static Vector3 GetRandomPositionOnMap()
    {
        float x = Random.Range(-40f, 40f);
        float z = Random.Range(-40f, 40f);

        return GetVector(x,0f,z);
    }

    public static Vector3 GetVector(float x, float y, float z)
    {
        Vector3 vector = Vector3.zero;
        vector.x = x;
        vector.y = y;
        vector.z = z;

        return vector;
    }

}
