using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrangeColor : MonoBehaviour {
    private MeshRenderer m_render;
    //public SkinnedMeshRenderer m_render;

    private Material mat;
    Color color;
   
	// Use this for initialization
	void Start () {
        m_render = gameObject.GetComponent<MeshRenderer>();
        //m_render = gameObject.GetComponent<SkinnedMeshRenderer>();
        
        mat = m_render.sharedMaterial;
        color = mat.GetColor("_RimColor");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            mat.SetFloat("_RimPower", 1.3f);
            mat.SetColor("_RimColor",new Color(1,0,0,0));            
        }
        else if(Input.GetMouseButtonUp(0))
        {

            mat.SetFloat("_RimPower", 8);
            mat.SetColor("_RimColor", color);
        }
	}
}
