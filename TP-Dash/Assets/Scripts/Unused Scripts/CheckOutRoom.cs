using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckOutRoom : MonoBehaviour
{
    public GameObject cubeBoy;


    private void Update()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(cubeBoy.transform.position, out hit, 2f, NavMesh.AllAreas))
        {
            cubeBoy.GetComponent<NavMeshAgent>().enabled = true;
            cubeBoy.GetComponent<CubeBoyBehavior>().enabled = true;
        }
    }
}
