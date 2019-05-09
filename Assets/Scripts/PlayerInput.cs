using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float minZoom;
    public float maxZoom;
    public float deltaZoom;

    private float edgeTranslateX;
    private float edgeTranslateY;
    public float translateDelta;

    public GameObject mainCamera;

    void Start()
    {
        edgeTranslateX = GetComponent<Generator>().width;
        edgeTranslateY = GetComponent<Generator>().height;
    }

    void Update()
    {
        float newCameraX = mainCamera.transform.position.x;
        float newCameraY = mainCamera.transform.position.y;
        float newCameraZ = mainCamera.transform.position.z;

        if (Input.mouseScrollDelta.y > 0)
        {
            newCameraZ = Mathf.Min(maxZoom, newCameraZ + deltaZoom);
        } else if (Input.mouseScrollDelta.y < 0)
        {
            newCameraZ = Mathf.Max(minZoom, newCameraZ - deltaZoom);
        }

        float zoomedRatio = (newCameraZ - maxZoom) / (minZoom - maxZoom) + 0.3f;
        if (Input.GetKey(KeyCode.W))
        {
            newCameraY = Mathf.Min(edgeTranslateY, newCameraY + zoomedRatio * translateDelta);
        } else if (Input.GetKey(KeyCode.S))
        {
            newCameraY = Mathf.Max(-edgeTranslateY, newCameraY - zoomedRatio * translateDelta);
        }

        if (Input.GetKey(KeyCode.A))
        {
            newCameraX = Mathf.Max(-edgeTranslateX, newCameraX - zoomedRatio * translateDelta);
        } else if (Input.GetKey(KeyCode.D))
        {
            newCameraX = Mathf.Min(edgeTranslateX, newCameraX + zoomedRatio * translateDelta);
        }

        mainCamera.transform.position = new Vector3(newCameraX, newCameraY, newCameraZ);
    }
}
