using UnityEngine;

public class broke : MonoBehaviour
{
    public GameObject interactableObject;

    void DeformAndShrinkObject()
    {
        Mesh mesh = interactableObject.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        // Check if there are more than 4 vertices
        if (vertices.Length > 4)
        {
            foreach (Vector3 vertex in vertices)
            {
                // Deform each vertex
                for (int i = 0; i < vertices.Length; i++)
                {
                    // Perform custom deformation logic here
                    vertices[i] += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));

                }
            }

            mesh.vertices = vertices;
            mesh.RecalculateTangents();
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
        }
        
        
    }
    

    void Interact()
    {
        DeformAndShrinkObject();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
}
