using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
   
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1) * 90 * Time.deltaTime);
    }
}
