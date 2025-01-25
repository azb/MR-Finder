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
        transform.position = Camera.main.transform.position + new Vector3( Camera.main.transform.forward.x * .3f, -.2f, Camera.main.transform.forward.z * .3f);

        if (objectToPointAt != null)
        {
            transform.LookAt(objectToPointAt);
        }
    }
}
