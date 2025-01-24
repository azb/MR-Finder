using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosManager : MonoBehaviour
{
    public Vector3 PositionFix;
    public Vector3 RotationFix;

    void Start()
    {

    }

    //Fresh new Pos follow Camera
    public void PositionFresh()
    {
        gameObject.transform.position = new Vector3(Camera.main.transform.position.x + PositionFix.x, Camera.main.transform.position.y + PositionFix.y, Camera.main.transform.position.z + PositionFix.z);
        gameObject.transform.rotation = Quaternion.Euler(RotationFix);
    }


    void Update()
    {
        PositionFresh();
    }
}
