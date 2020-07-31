using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed=8f;
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(transform.position.y>=8f)
        {
            Destroy(this.gameObject);
        }
    }
}
