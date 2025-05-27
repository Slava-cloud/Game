using UnityEngine;

public class broke : MonoBehaviour
{
    public GameObject interactableObject;

    void DeformAndShrinkObject()
    {
        MeshFilter meshFilter = interactableObject.GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            Mesh mesh = meshFilter.mesh;
            Vector3[] vertices = mesh.vertices;

            // Modify some vertices to simulate deformation
            for (int i = 0; i < vertices.Length; i++)
            {
                if (Random.value > 0.5f) // Randomly select some vertices
                {
                    vertices[i] *= 0.9f; // Shrink the vertex slightly
                }
            }

            mesh.vertices = vertices;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
        }

        // Optionally shrink the entire object
        interactableObject.transform.localScale *= 0.9f;
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
