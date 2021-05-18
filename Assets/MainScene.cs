using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            rayCasting(ray);
        }
    }

    void rayCasting(Ray ray)
    {
        RaycastHit hitObj;
    if(Physics.Raycast(ray, out hitObj, Mathf.Infinity))
        {
            if (hitObj.transform.tag.Equals("Cube"))
            { CubeScript cubeScript = hitObj.transform.GetComponent<CubeScript>();
            if(null!=cubeScript)
                {
                    cubeScript.Hit();
                }
            }
        }
    }
}
