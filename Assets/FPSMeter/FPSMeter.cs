﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FPSMeter : MonoBehaviour
{
    [SerializeField]
    float targetFrameRate = 60.0f;
    [SerializeField]
    Color overColor;

    [SerializeField]
    float overFrameRate = 30.0f;

    float frameDeltaTime = 0.0f;
    float prevTime = 0.0f;
    Vector4 size;
    Material mat;

    [SerializeField]
    float interval = 0.2f;
    float elapsed = 0.0f;
    int frame = 0;

    Color defaultColor;

    int sizeID;
    int colorID;
    Mesh mesh;
    

    void OnDestroy()
    {
        if (mesh != null)
        {
            Destroy(mesh);
        }
    }

    void Start()
    {
        mesh = new Mesh();
        int[] indices = new int[6];
        Vector2[] uvs = new Vector2[4];
        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, 0, 0);
        vertices[2] = new Vector3(0, 0, 0);
        vertices[3] = new Vector3(0, 0, 0);

        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(1, 0);
        uvs[2] = new Vector2(0, 1);
        uvs[3] = new Vector2(1, 1);

        indices[0] = 0;
        indices[1] = 1;
        indices[2] = 2;
        indices[3] = 2;
        indices[4] = 1;
        indices[5] = 3;

        mesh.vertices = vertices;
        mesh.triangles = indices;
        mesh.uv = uvs;

        GetComponent<MeshFilter>().mesh = mesh;

        sizeID = Shader.PropertyToID("_Size");
        mat = GetComponent<Renderer>().material;
        size = mat.GetVector(sizeID);
        size.x = 1.0f;
        mat.SetVector(sizeID, size);
        colorID = Shader.PropertyToID("_Color");
        defaultColor = mat.GetColor(colorID);

        //var sampler = UnityEngine.Profiling.CustomSampler.Create("hoge", true);
        //var commandBuffer = new CommandBuffer();
        //commandBuffer.BeginSample(sampler);
        //commandBuffer.EndSample(sampler);
        //Camera.main.AddCommandBuffer(CameraEvent.AfterImageEffects, commandBuffer);

        
    }

    void Update()
    {
        float currentTime = Time.realtimeSinceStartup;
        frameDeltaTime = currentTime - prevTime;
        prevTime = currentTime;
        elapsed += frameDeltaTime;
        frame++;

        if (elapsed < interval)
        {
            return;
        }

        float time = elapsed / frame;

        size.x = time * targetFrameRate * 0.5f;
        mat.SetVector(sizeID, size);

        //Debug.Log(frame / elapsed);

        mat.SetColor(colorID, time > 1.0f / overFrameRate ? overColor : defaultColor);

        frame = 0;
        elapsed = 0.0f;
    }
}
