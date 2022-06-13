using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

[ExecuteInEditMode]
public class Waves : MonoBehaviour
{
    public Vector3[] vertex;
    public Vector2[] uvmap;
    public int[] triangles;
    public float amplitudeV;
    public float limit = .5f;


    public int columns = 40;
    public int rows = 40;

    private MeshFilter filter;

    private void Start()
    {
        //StartCoroutine(wait());
    }

    private void Awake()
    {
        GenerateMesh();
    }
    private void FixedUpdate()
    {
       // wait();
        GenerateMesh();

    }

   /* IEnumerator wait()
    {
        //Ok, so in this part of the code i simply make a for wich is going to increment my amplitude in .2f, this affects directly into de mesh and how the curves behave. 
        for (amplitudeV = .2f; amplitudeV < limit; amplitudeV += .2f)
        {
            //And waits every 30 seconds to do the increment. 
            yield return new WaitForSeconds(15);
        }

    }
   */

    private void GenerateMesh()
    {



        // vertices
        vertex = new Vector3[columns * rows * 6];

        for (int i = 0; i < columns; ++i)
        {
            for (int j = 0; j < rows; ++j)
            {
                int index = (i * rows + j) * 6;

                /* Animation, it change the highed of the senoidal wave */
                float deltasinAncho1 = Mathf.Sin(Time.time + (i + 0)) * amplitudeV;
                float deltasinAncho2 = Mathf.Sin(Time.time + (i + 1)) * amplitudeV;
                float deltasinAlto1 = Mathf.Sin(Time.time + (j + 0)) * amplitudeV;
                float deltasinAlto2 = Mathf.Sin(Time.time + (j + 1)) * amplitudeV;

                //This part of the code helps the mesh by connecting the vertex so it doesn't look clumpsy. 
                vertex[index] = new Vector3(i + 0, (deltasinAncho1 + deltasinAlto1), j + 0);
                vertex[index + 1] = new Vector3(i + 1, (deltasinAncho2 + deltasinAlto1), j + 0);
                vertex[index + 2] = new Vector3(i + 0, (deltasinAncho1 + deltasinAlto2), j + 1);

                vertex[index + 3] = new Vector3(i + 1, (deltasinAncho2 + deltasinAlto1), j + 0);
                vertex[index + 4] = new Vector3(i + 1, (deltasinAncho2 + deltasinAlto2), j + 1);
                vertex[index + 5] = new Vector3(i + 0, (deltasinAncho1 + deltasinAlto2), j + 1);

            }
        }

        // poligons
        triangles = new int[rows * columns * 6];

        for (int i = 0; i < triangles.Length; ++i)
        {
            triangles[i] = i;
        }

        // uv map
        uvmap = new Vector2[columns * rows * 6];

        for (int i = 0; i < columns; ++i)
        {
            for (int j = 0; j < rows; ++j)
            {
                int index = (i * rows + j) * 6;
                uvmap[index] = new Vector2(0.375f, 1f);
                uvmap[index + 1] = new Vector2(0.5f, 1f);
                uvmap[index + 2] = new Vector2(0.375f, 0.875f);

                uvmap[index + 3] = new Vector2(0.5f, 1f);
                uvmap[index + 4] = new Vector2(0.5f, 0.875f);
                uvmap[index + 5] = new Vector2(0.375f, 0.875f);
            }
        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertex;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.uv = uvmap;
        filter = gameObject.GetComponent<MeshFilter>();
        filter.mesh = mesh;

        //Script for the collider to be updated in every frame so the game can manipulate everything in the right way
        MeshCollider meshV = GetComponent<MeshCollider>();
        if (meshV == null)
        {
            meshV = (MeshCollider)this.transform.gameObject.AddComponent(typeof(MeshCollider));
        }
        else
        {
            meshV.sharedMesh = null;
            meshV.sharedMesh = mesh;
        }
    }
}