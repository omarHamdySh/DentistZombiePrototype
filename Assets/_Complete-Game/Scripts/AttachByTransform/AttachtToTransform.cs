using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachtToTransform : MonoBehaviour
{

    public GameObject attachTo;
    // Update is called once per frame
    void Update()
    {
        transform.position = attachTo.transform.position;
    }
}
