using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindArrow : MonoBehaviour
{
    public Transform objectToPointAt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (objectToPointAt != null)
        {
            transform.LookAt(objectToPointAt);
        }
    }
}
