using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StacktraceTest : MonoBehaviour
{
    void Start()
    {
        // GC AllocのCall stacks表示がすべて同じ行になる
        int[] a = new int[1];




        int[] b = new int[2];




        int[] c = new int[3];
    }
}
