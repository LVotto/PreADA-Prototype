using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveIconBehaviour : MonoBehaviour
{
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    Mesh mesh;
    public Material arrowMaterial;
    public Vector2 direction;
    public float radius = .6f;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        mesh = meshFilter.mesh;
        float angle;
        Vector3[] vertices = new Vector3[3];
        for (int i = 0; i < 3; i++){
            angle = Mathf.PI / 2 + i * 2 * Mathf.PI / 3;
            vertices[i] = new Vector3(
                Mathf.Cos(angle), Mathf.Sin(angle), 0 
            );
            vertices[i] *= radius;
        }
        meshRenderer.material = arrowMaterial;
        mesh.vertices = vertices;
        transform.position += Vector3.down * radius / 6;
        // Vector3[] normals = new Vector3[1];
        // normals[0] = Vector3.back;
        // mesh.normals = normals;
        int[] triangles = {0, 2, 1, 0, 1, 2};
        mesh.triangles = triangles;
        SaveAsset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveAsset()
    {
        var mf = GetComponent<MeshFilter>();
        if (mf)
        {
            var savePath = "Assets/triangle.asset";
            Debug.Log("Saved Mesh to:" + savePath);
            AssetDatabase.CreateAsset(mf.mesh, savePath);
        }
    }
}
