using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToRegularMesh : MonoBehaviour {

    [ContextMenu("Convert to regular mesh")]
	void Convert() {
        SkinnedMeshRenderer skinnedMesh = GetComponent<SkinnedMeshRenderer>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        meshFilter.sharedMesh = skinnedMesh.sharedMesh;
        meshRenderer.sharedMaterials = skinnedMesh.sharedMaterials;

        DestroyImmediate(skinnedMesh);
        DestroyImmediate(this);
    }
}
