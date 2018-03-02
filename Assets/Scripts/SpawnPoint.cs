using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(2, 2, 0));
    }
}
