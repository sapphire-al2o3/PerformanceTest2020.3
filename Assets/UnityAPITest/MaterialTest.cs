using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var renderer = GetComponent<Renderer>();

        var mats = renderer.sharedMaterials;
        Debug.Log(mats[0].GetHashCode());

        mats = renderer.sharedMaterials;
        Debug.Log(mats[0].GetHashCode());

        mats = renderer.materials;
        Debug.Log(mats[0].GetHashCode());

        mats = renderer.sharedMaterials;
        Debug.Log(mats[0].GetHashCode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
