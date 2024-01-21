using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trees : MonoBehaviour
{
    [SerializeField] GameObject[] treetypes;
    public void Spawnblock()
    {
        GameObject appeartree = Instantiate(treetypes[Random.Range(0, 3)], transform);
        appeartree.transform.position = new Vector3(9.5f, -0.15f, 0);
    }
}
