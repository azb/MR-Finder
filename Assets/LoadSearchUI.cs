using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSearchUI : MonoBehaviour
{
    public Vector3 PositionFix;
    private void OnEnable()
    {
        PositionFresh();
    }

    void PositionFresh()
    {
        gameObject.transform.position = new Vector3(Camera.main.transform.position.x - PositionFix.x, Camera.main.transform.position.y - PositionFix.y, Camera.main.transform.position.z - PositionFix.z);
    }


}
