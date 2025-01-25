using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverInFrontOfPlayer : MonoBehaviour
{
    float verticalOffset = 0;
    Transform mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, mainCamera.position);

        float direction = Mathf.Atan2(mainCamera.forward.z, mainCamera.forward.x);

        float xc = Mathf.Cos(direction);
        float yc = Mathf.Sin(direction);

        transform.position = mainCamera.position + new Vector3(
            xc * .3f, 
            verticalOffset,
            yc * .3f
        );

    }


}
