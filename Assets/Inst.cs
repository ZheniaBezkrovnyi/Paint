using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inst : MonoBehaviour
{
    public GameObject gb;
    public GameObject gbPoint;
    public float speedPrefab; 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject goPrefab = Instantiate(gb, gbPoint.transform.position, gbPoint.transform.rotation);
                goPrefab.GetComponent<Rigidbody>().velocity = transform.forward * speedPrefab;
            }
        }
    }
}
