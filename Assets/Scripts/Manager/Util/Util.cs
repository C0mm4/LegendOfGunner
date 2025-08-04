using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public static class Util
{
    public static T[] Shuffle<T>(T[] types)
    {
        T[] result = types;
        int random1, random2;
        for (int i = 0; i < types.Length; ++i)
        {
            random1 = UnityEngine.Random.Range(0, types.Length);
            random2 = UnityEngine.Random.Range(0, types.Length);
            Swap(ref result[random1], ref result[random2]);
        }
        return result;
    }

    public static void Swap<T>(ref T t1, ref T t2)
    {
        T temp = t1;
        t1 = t2;
        t2 = temp;
    }

    // 3개의 변수를 입력받아서 2개를 반환하는 함수 
    public static T[] RandomReturn2<T>(int a, int b, int c, T[] values)
    {
        T[] temp = new T[2];
        int total = a + b + c;
        Debug.Log(total);
        int rndVal = UnityEngine.Random.Range(0, total);
        switch (rndVal)
        {
            case int n when (rndVal < a):
                temp[0] = values[0];
                temp[1] = RandomReturn(b, c, values[1], values[2]);
                break;
            case int n when (rndVal < a + b):
                temp[0] = values[1];
                temp[1] = RandomReturn(a, c, values[0], values[2]);
                break;
            case int n when (rndVal < a + b + c):
                temp[0] = values[2];
                temp[1] = RandomReturn(a, b, values[0], values[1]);
                break;
        }
        return temp;
    }

    //2개의 변수를 입력받아서 1개...
    public static T RandomReturn<T>(int a, int b, T t1, T t2)
    {
        int total = a + b;
        int rndVal = UnityEngine.Random.Range(0, total);
        switch (rndVal)
        {
            case int n when (rndVal < a):
                return t1;
            case int n when (rndVal < a + b):
                return t2;
            default:
                break;
        }
        Debug.Log("여21");

        return t1;
    }
}
