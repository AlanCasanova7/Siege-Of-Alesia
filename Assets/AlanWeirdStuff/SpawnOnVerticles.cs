using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnVerticles : MonoBehaviour {

    public GameObject goToSpawn;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3[] verts = this.GetComponent<MeshFilter>().mesh.vertices;

            for (int i = 0; i < verts.Length; i++)
            {
                if(i % (verts.Length / 100) == 0)
                    Instantiate(goToSpawn, verts[i], Quaternion.identity, this.transform);
            }
        }
		
	}
}
