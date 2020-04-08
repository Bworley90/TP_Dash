using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshBaking : MonoBehaviour
{
    public NavMeshSurface nms;
    
    void Start()  
    {
        Invoke("Build", .5f);
    }

   private void Build()
    {
        nms.BuildNavMesh();
    }
}
