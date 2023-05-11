using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX1 : MonoBehaviour
{
    private void FixedUpdate()
    {
        MoveCube();
    }
    private void MoveCube()
    {
        if(Input.GetButton("Fire1"))
        {
            // draw a ray from camera to mouse position 
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            // raycast hit to contain thing that  ray collide with
            RaycastHit hit;
            //physic.raycase to check whether ray hit thing or not 
            if(Physics.Raycast(ray, out hit)&&hit.collider.tag== "Quad")
            {
                transform.position = hit.point+new Vector3(0,0.5f,0);
            }
        }
    }
}
