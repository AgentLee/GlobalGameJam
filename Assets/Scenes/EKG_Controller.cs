using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EKG_Controller : MonoBehaviour
{
    [SerializeField]
    private Shader ekg_shader;

    [SerializeField]
    private Material ekg_material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        
    }
}
