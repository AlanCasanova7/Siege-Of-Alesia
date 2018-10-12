using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SphericalSpawner : MonoBehaviour
{
    IcosahedronGenerator icosahedron;
    public const int possibleSubDivisions = 7;
    public static readonly int[] supportedChunkSizes = { 20, 80, 320, 1280, 5120, 20480, 81920 };

    [Range(0, possibleSubDivisions - 1)]
    public int numOfMainTriangles = 0;
    [Range(0, possibleSubDivisions - 1)]
    public int numOfSubdivisionsWithinEachTriangle = 0;
    public bool saveIcosahedron = false;

    public GameObject toSpawn;

    // Use this for initialization
    void Start()
    {
        icosahedron = ScriptableObject.CreateInstance<IcosahedronGenerator>();

        // 0 = 12 verts, 20 tris
        icosahedron.GenBaseIcosahedron();
        icosahedron.SeparateAllPolygons();

        // 0 = 12 verts, 20 tris - Already Generated with GenBaseIcosahedron()
        // 1 = 42 verts, 80 tris
        // 2 = 162 verts, 320 tris
        // 3 = 642 verts, 1280 tris
        // 5 = 2562 verts, 5120 tris
        // 5 = 10242 verts, 20480 tris
        // 6 = 40962verts, 81920 tris
        if (numOfMainTriangles > 0)
        {
            icosahedron.Subdivide(numOfMainTriangles);
        }
        icosahedron.SeparateAllPolygons();

        if (numOfSubdivisionsWithinEachTriangle > 0)
        {
            icosahedron.Subdivide(numOfSubdivisionsWithinEachTriangle);
        }

        icosahedron.CalculateMesh(this.gameObject, numOfMainTriangles, numOfSubdivisionsWithinEachTriangle, saveIcosahedron, toSpawn, this.transform);
        icosahedron.DisplayVertAndPolygonCount();
    }
}

public class Vector3Dictionary
{
    public List<Vector3> vector3List;
    public Dictionary<int, List<Vector3>> vector3Dictionary;

    public Vector3Dictionary()
    {
        vector3Dictionary = new Dictionary<int, List<Vector3>>();
        return;
    }

    public void Vector3DictionaryList(int x, int y, int z)
    {
        vector3List = new List<Vector3>();

        vector3List.Add(new Vector3(x, y, z));
        vector3Dictionary.Add(vector3Dictionary.Count, vector3List);

        return;
    }

    public void Vector3DictionaryList(int index, Vector3 vertice)
    {
        vector3List = new List<Vector3>();

        if (vector3Dictionary.ContainsKey(index))
        {
            vector3List = vector3Dictionary[index];
            vector3List.Add(vertice);
            vector3Dictionary[index] = vector3List;
        }
        else
        {
            vector3List.Add(vertice);
            vector3Dictionary.Add(index, vector3List);
        }

        return;
    }

    public void Vector3DictionaryList(int index, List<Vector3> vertice, bool list)
    {
        vector3List = new List<Vector3>();

        if (vector3Dictionary.ContainsKey(index))
        {
            vector3List = vector3Dictionary[index];
            for (int a = 0; a < vertice.Count; a++)
            {
                vector3List.Add(vertice[a]);
            }
            vector3Dictionary[index] = vector3List;
        }
        else
        {
            for (int a = 0; a < vertice.Count; a++)
            {
                vector3List.Add(vertice[a]);
            }
            vector3Dictionary.Add(index, vector3List);
        }

        return;
    }

    public void Vector3DictionaryList(int index, int x, int y, int z)
    {
        vector3List = new List<Vector3>();

        if (vector3Dictionary.ContainsKey(index))
        {
            vector3List = vector3Dictionary[index];
            vector3List.Add(new Vector3(x, y, z));
            vector3Dictionary[index] = vector3List;
        }
        else
        {
            vector3List.Add(new Vector3(x, y, z));
            vector3Dictionary.Add(index, vector3List);
        }

        return;
    }

    public void Vector3DictionaryList(int index, float x, float y, float z, bool replace)
    {
        if (replace)
        {
            vector3List = new List<Vector3>();

            vector3List.Add(new Vector3(x, y, z));
            vector3Dictionary[index] = vector3List;
        }

        return;
    }
}

public class IcosahedronGenerator : ScriptableObject
{
    public Vector3Dictionary icosahedronPolygonDict;
    public Vector3Dictionary icosahedronVerticeDict;
    public bool firstRun = true;

    public void GenBaseIcosahedron()
    {
        icosahedronPolygonDict = new Vector3Dictionary();
        icosahedronVerticeDict = new Vector3Dictionary();

        // An icosahedron has 12 vertices, and
        // since it's completely symmetrical the
        // formula for calculating them is kind of
        // symmetrical too:

        float t = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;

        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(-1, t, 0).normalized);
        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(1, t, 0).normalized);
        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(-1, -t, 0).normalized);
        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(1, -t, 0).normalized);
        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(0, -1, t).normalized);
        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(0, 1, t).normalized);
        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(0, -1, -t).normalized);
        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(0, 1, -t).normalized);
        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(t, 0, -1).normalized);
        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(t, 0, 1).normalized);
        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(-t, 0, -1).normalized);
        icosahedronVerticeDict.Vector3DictionaryList(0, new Vector3(-t, 0, 1).normalized);

        // And here's the formula for the 20 sides,
        // referencing the 12 vertices we just created.
        // Each side will be placed in it's own dictionary key.
        // The first number is the key/index, and the next 3 numbers reference the vertice index
        icosahedronPolygonDict.Vector3DictionaryList(0, 0, 11, 5);
        icosahedronPolygonDict.Vector3DictionaryList(1, 0, 5, 1);
        icosahedronPolygonDict.Vector3DictionaryList(2, 0, 1, 7);
        icosahedronPolygonDict.Vector3DictionaryList(3, 0, 7, 10);
        icosahedronPolygonDict.Vector3DictionaryList(4, 0, 10, 11);
        icosahedronPolygonDict.Vector3DictionaryList(5, 1, 5, 9);
        icosahedronPolygonDict.Vector3DictionaryList(6, 5, 11, 4);
        icosahedronPolygonDict.Vector3DictionaryList(7, 11, 10, 2);
        icosahedronPolygonDict.Vector3DictionaryList(8, 10, 7, 6);
        icosahedronPolygonDict.Vector3DictionaryList(9, 7, 1, 8);
        icosahedronPolygonDict.Vector3DictionaryList(10, 3, 9, 4);
        icosahedronPolygonDict.Vector3DictionaryList(11, 3, 4, 2);
        icosahedronPolygonDict.Vector3DictionaryList(12, 3, 2, 6);
        icosahedronPolygonDict.Vector3DictionaryList(13, 3, 6, 8);
        icosahedronPolygonDict.Vector3DictionaryList(14, 3, 8, 9);
        icosahedronPolygonDict.Vector3DictionaryList(15, 4, 9, 5);
        icosahedronPolygonDict.Vector3DictionaryList(16, 2, 4, 11);
        icosahedronPolygonDict.Vector3DictionaryList(17, 6, 2, 10);
        icosahedronPolygonDict.Vector3DictionaryList(18, 8, 6, 7);
        icosahedronPolygonDict.Vector3DictionaryList(19, 9, 8, 1);

        return;
    }

    public void SeparateAllPolygons()
    {
        // Separates all polygons and vertex keys/indicies into their own key/index
        // For example if the numOfMainTriangles is set to 2,
        // This function will separate each polygon/triangle into it's own index
        // By looping through all polygons in each dictionary key/index

        List<Vector3> originalPolygons = new List<Vector3>();
        List<Vector3> originalVertices = new List<Vector3>();
        List<Vector3> newVertices = new List<Vector3>();
        Vector3Dictionary tempIcosahedronPolygonDict = new Vector3Dictionary();
        Vector3Dictionary tempIcosahedronVerticeDict = new Vector3Dictionary();

        // Cycles through the polygon list
        for (int i = 0; i < icosahedronPolygonDict.vector3Dictionary.Count; i++)
        {
            originalPolygons = new List<Vector3>();
            originalVertices = new List<Vector3>();

            // Loads all the polygons in a certain index/key
            originalPolygons = icosahedronPolygonDict.vector3Dictionary[i];

            // Since the original script was set up without a dictionary index
            // It was easier to loop all the original triangle vertices into index 0
            // Thus the first time this function runs, all initial vertices will be 
            // redistributed to the correct indicies/index/key

            if (firstRun)
            {
                originalVertices = icosahedronVerticeDict.vector3Dictionary[0];
            }
            else
            {
                // i - 1 to account for the first iteration of pre-set vertices
                originalVertices = icosahedronVerticeDict.vector3Dictionary[i];
            }

            // Loops through all the polygons in a specific Dictionary key/index
            for (int a = 0; a < originalPolygons.Count; a++)
            {
                newVertices = new List<Vector3>();

                int x = (int)originalPolygons[a].x;
                int y = (int)originalPolygons[a].y;
                int z = (int)originalPolygons[a].z;

                // Adds three vertices/transforms for each polygon in the list
                newVertices.Add(originalVertices[x]);
                newVertices.Add(originalVertices[y]);
                newVertices.Add(originalVertices[z]);

                // Overwrites the Polygon indices from their original locations
                // index (20,11,5) for example would become (0,1,2) to correspond to the
                // three new Vector3's added to the list.
                // In the case of this function there will only be 3 Vector3's associated to each dictionary key
                tempIcosahedronPolygonDict.Vector3DictionaryList(0, 1, 2);

                // sets the index to the size of the temp dictionary list
                int tempIndex = tempIcosahedronPolygonDict.vector3Dictionary.Count;
                // adds the new vertices to the corresponding same key in the vertice index
                // which corresponds to the same key/index as the polygon dictionary
                tempIcosahedronVerticeDict.Vector3DictionaryList(tempIndex - 1, newVertices, true);
            }
        }
        firstRun = !firstRun;

        // Sets the temp dictionarys as the main dictionaries
        icosahedronVerticeDict = tempIcosahedronVerticeDict;
        icosahedronPolygonDict = tempIcosahedronPolygonDict;
    }

    public void Subdivide(int recursions)
    {
        // Divides each triangle into 4 triangles, and replaces the Dictionary entry

        var midPointCache = new Dictionary<int, int>();
        int polyDictIndex = 0;
        List<Vector3> originalPolygons = new List<Vector3>();
        List<Vector3> newPolygons;

        for (int x = 0; x < recursions; x++)
        {
            polyDictIndex = icosahedronPolygonDict.vector3Dictionary.Count;
            for (int i = 0; i < polyDictIndex; i++)
            {
                newPolygons = new List<Vector3>();
                midPointCache = new Dictionary<int, int>();
                originalPolygons = icosahedronPolygonDict.vector3Dictionary[i];

                for (int z = 0; z < originalPolygons.Count; z++)
                {
                    int a = (int)originalPolygons[z].x;
                    int b = (int)originalPolygons[z].y;
                    int c = (int)originalPolygons[z].z;

                    // Use GetMidPointIndex to either create a
                    // new vertex between two old vertices, or
                    // find the one that was already created.
                    int ab = GetMidPointIndex(i, midPointCache, a, b);
                    int bc = GetMidPointIndex(i, midPointCache, b, c);
                    int ca = GetMidPointIndex(i, midPointCache, c, a);

                    // Create the four new polygons using our original
                    // three vertices, and the three new midpoints.
                    newPolygons.Add(new Vector3(a, ab, ca));
                    newPolygons.Add(new Vector3(b, bc, ab));
                    newPolygons.Add(new Vector3(c, ca, bc));
                    newPolygons.Add(new Vector3(ab, bc, ca));
                }
                // Replace all our old polygons with the new set of
                // subdivided ones.
                icosahedronPolygonDict.vector3Dictionary[i] = newPolygons;
            }
        }
        return;
    }

    int GetMidPointIndex(int polyIndex, Dictionary<int, int> cache, int indexA, int indexB)
    {
        // We create a key out of the two original indices
        // by storing the smaller index in the upper two bytes
        // of an integer, and the larger index in the lower two
        // bytes. By sorting them according to whichever is smaller
        // we ensure that this function returns the same result
        // whether you call
        // GetMidPointIndex(cache, 5, 9)
        // or...
        // GetMidPointIndex(cache, 9, 5)

        int smallerIndex = Mathf.Min(indexA, indexB);
        int greaterIndex = Mathf.Max(indexA, indexB);
        int key = (smallerIndex << 16) + greaterIndex;

        // If a midpoint is already defined, just return it.
        int ret;
        if (cache.TryGetValue(key, out ret))
            return ret;

        // If we're here, it's because a midpoint for these two
        // vertices hasn't been created yet. Let's do that now!
        List<Vector3> tempVertList = icosahedronVerticeDict.vector3Dictionary[polyIndex];

        Vector3 p1 = tempVertList[indexA];
        Vector3 p2 = tempVertList[indexB];
        Vector3 middle = Vector3.Lerp(p1, p2, 0.5f).normalized;

        ret = tempVertList.Count;
        tempVertList.Add(middle);
        icosahedronVerticeDict.vector3Dictionary[polyIndex] = tempVertList;

        cache.Add(key, ret);
        return ret;
    }

    public void CalculateMesh(GameObject icosahedron, int numOfMainTriangles, int numOfSubdivisionsWithinEachTriangle, bool saveIcosahedron, GameObject go, Transform transform)
    {
        GameObject meshChunk;
        List<Vector3> meshPolyList;
        List<Vector3> meshVertList;
        List<int> triList;

        CreateFolders(numOfMainTriangles, numOfSubdivisionsWithinEachTriangle);
        CreateMaterial();

        // Loads a material from the Assets/Resources/ folder so that it can be saved with the prefab later
        Material material = Resources.Load("BlankSphere", typeof(Material)) as Material;

        int polyDictIndex = icosahedronPolygonDict.vector3Dictionary.Count;

        // Used to assign the child objects as well as to be saved as the .prefab
        // Sets the name
        icosahedron.gameObject.name = "Icosahedron" + numOfMainTriangles + "Recursion" + numOfSubdivisionsWithinEachTriangle;

        for (int i = 0; i < polyDictIndex; i++)
        {
            meshPolyList = new List<Vector3>();
            meshVertList = new List<Vector3>();
            triList = new List<int>();
            // Assigns the polygon and vertex indices
            meshPolyList = icosahedronPolygonDict.vector3Dictionary[i];
            meshVertList = icosahedronVerticeDict.vector3Dictionary[i];

            // Sets the child gameobject parameters
            meshChunk = new GameObject("MeshChunk");
            meshChunk.transform.parent = icosahedron.gameObject.transform;
            meshChunk.transform.localPosition = new Vector3(0, 0, 0);
            meshChunk.AddComponent<MeshFilter>();
            meshChunk.AddComponent<MeshRenderer>();
            meshChunk.GetComponent<MeshRenderer>().material = material;
            meshChunk.AddComponent<MeshCollider>();
            Mesh mesh = meshChunk.GetComponent<MeshFilter>().mesh;

            // Adds the triangles to the list
            for (int z = 0; z < meshPolyList.Count; z++)
            {
                triList.Add((int)meshPolyList[z].x);
                triList.Add((int)meshPolyList[z].y);
                triList.Add((int)meshPolyList[z].z);
            }

            mesh.vertices = meshVertList.ToArray();

            if(i % (polyDictIndex / 100) == 0)
            {
                GameObject g = Instantiate(go, transform, false);
                g.transform.localPosition = mesh.vertices[0];
                g.name = (i / 3).ToString();
            }

            mesh.triangles = triList.ToArray();
            mesh.uv = new Vector2[meshVertList.Count];

            /*
            //Not Needed because all normals have been calculated already
            Vector3[] _normals = new Vector3[meshVertList.Count];
            for (int d = 0; d < _normals.Length; d++){
                _normals[d] = meshVertList[d].normalized;
            }
            mesh.normals = _normals;
            */

            mesh.normals = meshVertList.ToArray();

            mesh.RecalculateBounds();

            // Saves each chunk mesh to a specified folder
            // The folder must exist
            if (saveIcosahedron)
            {
                string sphereAssetName = "icosahedronChunk" + numOfMainTriangles + "Recursion" + numOfSubdivisionsWithinEachTriangle + "_" + i + ".asset";
                AssetDatabase.CreateAsset(mesh, "Assets/Icosahedrons/Icosahedron" + numOfMainTriangles + "Recursion" + numOfSubdivisionsWithinEachTriangle + "/" + sphereAssetName);
                AssetDatabase.SaveAssets();
            }
        }

        // Removes the script for the prefab save
        // Saves the prefab to a specified folder
        // The folder must exist
        if (saveIcosahedron)
        {
            DestroyImmediate(icosahedron.GetComponent<SphericalSpawner>());
            PrefabUtility.CreatePrefab("Assets/Icosahedrons/Icosahedron" + numOfMainTriangles + "Recursion" + numOfSubdivisionsWithinEachTriangle + "/Icosahedron" + numOfMainTriangles + "Recursion" + numOfSubdivisionsWithinEachTriangle + ".prefab", icosahedron);
        }

        return;
    }

    void CreateFolders(int numOfMainTriangles, int numOfSubdivisionsWithinEachTriangle)
    {
        // Creates the folders if they don't exist
        if (!AssetDatabase.IsValidFolder("Assets/Icosahedrons"))
        {
            AssetDatabase.CreateFolder("Assets", "Icosahedrons");
        }
        if (!AssetDatabase.IsValidFolder("Assets/Icosahedrons/Icosahedron" + numOfMainTriangles + "Recursion" + numOfSubdivisionsWithinEachTriangle))
        {
            AssetDatabase.CreateFolder("Assets/Icosahedrons", "Icosahedron" + numOfMainTriangles + "Recursion" + numOfSubdivisionsWithinEachTriangle);
        }
        if (!AssetDatabase.IsValidFolder("Assets/Resources"))
        {
            AssetDatabase.CreateFolder("Assets", "Resources");
        }

        return;
    }

    static void CreateMaterial()
    {
        if (Resources.Load("BlankSphere", typeof(Material)) == null)
        {
            // Create a simple material asset if one does not exist
            Material material = new Material(Shader.Find("Standard"));
            material.color = Color.blue;
            AssetDatabase.CreateAsset(material, "Assets/Resources/BlankSphere.mat");
        }

        return;
    }

    // Displays the Total Polygon/Triangle and Vertice Count
    public void DisplayVertAndPolygonCount()
    {
        List<Vector3> tempVertices;
        HashSet<Vector3> verticeHash = new HashSet<Vector3>();

        int polygonCount = 0;
        List<Vector3> tempPolygons;

        // Saves Vertices to a hashset to ensure no duplicate vertices are counted
        for (int a = 0; a < icosahedronVerticeDict.vector3Dictionary.Count; a++)
        {
            tempVertices = new List<Vector3>();
            tempVertices = icosahedronVerticeDict.vector3Dictionary[a];
            for (int b = 0; b < tempVertices.Count; b++)
            {
                verticeHash.Add(tempVertices[b]);
            }
        }

        for (int a = 0; a < icosahedronPolygonDict.vector3Dictionary.Count; a++)
        {
            tempPolygons = new List<Vector3>();
            tempPolygons = icosahedronPolygonDict.vector3Dictionary[a];
            for (int b = 0; b < tempPolygons.Count; b++)
            {
                polygonCount++;
            }
        }

        //Debug.Log("Vertice Count: " + verticeHash.Count);
        //Debug.Log("Polygon Count: " + polygonCount);

        return;
    }
}