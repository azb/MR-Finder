using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToObject : MonoBehaviour
{
    public Transform objectToParentTo;
    public Vector3 localPos;
    public Vector3 localRot;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = objectToParentTo;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = localPos;
        transform.localRotation = Quaternion.Euler(localRot);
    }
}
