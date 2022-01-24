using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class PrefabTest : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    void Start()
    {
        // 152byte
        {
            Profiler.BeginSample("prefab Instantiate");
            var go = GameObject.Instantiate(prefab);
            Profiler.EndSample();
        }

        
        {
            // 40byte
            Profiler.BeginSample("new GameObject");
            var go = new GameObject();
            Profiler.EndSample();

            // 0byte
            Profiler.BeginSample("set_name");
            go.name = "test";
            Profiler.EndSample();

            Profiler.BeginSample("SetParent");
            go.transform.SetParent(transform);
            Profiler.EndSample();
        }
    }
}
