using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public GameObject starCanvasPrefab;
    public Material hoverMaterial;

    private GameObject starCanvas;
    private MeshRenderer meshRenderer;
    private Material currentMaterial;

    private bool mouseOver = false;
    private bool planetSelected = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        currentMaterial = meshRenderer.material;
    }

    void Update()
    {
        if (mouseOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                planetSelected = !planetSelected;

                if (planetSelected)
                {
                    meshRenderer.material = hoverMaterial;

                    starCanvas = Instantiate(starCanvasPrefab, transform.position + new Vector3(3, 0, -1), Quaternion.identity, transform);
                } else
                {
                    meshRenderer.material = currentMaterial;

                    Destroy(starCanvas);
                    starCanvas = null;
                }
            }
        }
    }

    private void OnMouseEnter()
    {
        mouseOver = true;
        meshRenderer.material = hoverMaterial;
    }

    private void OnMouseOver()
    {

    }

    private void OnMouseExit()
    {
        mouseOver = false;
        if (!planetSelected)
        {
            meshRenderer.material = currentMaterial;
        }
    }
}
