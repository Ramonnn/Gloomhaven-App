using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingOrder : MonoBehaviour {

    MeshRenderer rendererMesh;

	// Use this for initialization
	void Start () {

        rendererMesh = GetComponent<MeshRenderer>();

        rendererMesh.sortingLayerName = "OnTopofCard";

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
