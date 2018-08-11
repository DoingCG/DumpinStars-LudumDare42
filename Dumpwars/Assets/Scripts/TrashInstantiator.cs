using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInstantiator : MonoBehaviour {


    public GameObject floor;
    public GameObject trash;

    private Mesh surf;
    private int[] tris;

    // Use this for initialization
    void Start()
    {
        surf = floor.GetComponent<MeshFilter>().mesh;
        tris = surf.triangles;
        InvokeRepeating("TrashInstantiate", 3, 3);

    }

    // Update is called once per frame
    void Update() {

    }

    Vector3 GetInstancePoint()
    {
        int randTri =(int) Mathf.Floor( Random.Range(0,(int) Mathf.Floor((tris.Length-1)/3)));
        Debug.Log(randTri * 3);
        Debug.Log(surf.vertices.Length);
        Vector3 vtx1 = surf.vertices[tris[randTri * 3]];     
        Vector3 vtx2 = surf.vertices[tris[randTri * 3 + 1]];
        Vector3 vtx3 = surf.vertices[tris[randTri * 3 + 2]];

        Vector3 xaxis = vtx2 - vtx1;
        float xcoord = Random.Range(0, Vector3.Magnitude(xaxis));
        Vector3 yaxis = vtx3 - vtx1;
        float ycoord = Random.Range(0, Vector3.Magnitude(yaxis));

        return floor.transform.position+vtx1 + (xaxis * xcoord) + (yaxis * ycoord);
    }

    void TrashInstantiate()
        {
        Instantiate(trash, GetInstancePoint(), Quaternion.identity);
        }
}
