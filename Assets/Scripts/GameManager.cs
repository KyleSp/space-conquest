using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Generator generator;

    void Start()
    {
        generator = GetComponent<Generator>();
        generator.Generate();
        generator.AssignHomeworlds();
    }

    void Update()
    {
        
    }
}
