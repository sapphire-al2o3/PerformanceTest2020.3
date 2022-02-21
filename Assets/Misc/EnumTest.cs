using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class EnumTest : MonoBehaviour
{
	[System.Flags]
	enum Flags
	{
		A,
		B,
		C
	}

    void Start()
    {
		{
			Profiler.BeginSample("HasFlags");
			Flags flag = Flags.A;
			bool ret = flag.HasFlag(Flags.B);
			Profiler.EndSample();

			Debug.Log(ret);
		}
    }
}
