using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] Vector3 windDirection;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wind")
        {
            GetComponent<Rigidbody>().AddForce(windDirection, ForceMode.Acceleration);
        }  
    }
}
