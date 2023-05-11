using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX2 : MonoBehaviour
{
    private bool isDragging;
    private Vector3 initialMousePosition;
    Vector3 currentMousePosition;
    private Quaternion initialRotation;
   [SerializeField] float rotationSpeed = 20f;
   
    private void FixedUpdate()
    {
        if (checkInput())
        {
            CheckPointTo();
        }
    }
    private bool checkInput()
    {
      return Input.GetButton("Fire1");
    }    
    private void CheckPointTo()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // raycast hit to contain thing that  ray collide with
        RaycastHit hit;
        //physic.raycase to check whether ray hit thing or not 
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Quad")
        {
            isDragging = true;
            initialMousePosition = hit.point;
            initialRotation = transform.rotation;
            //Debug.Log(initialRotation);
        }
        else
        {
            isDragging = false;
        }
        Debug.Log(isDragging);
        if (isDragging)
        {
            StartCoroutine(RotateQuad(hit));
        }
    }

    private IEnumerator RotateQuad(RaycastHit hit)
    {
         currentMousePosition = hit.point;
        Vector3 direction = currentMousePosition - transform.position;
        float angle = Vector3.SignedAngle(direction, Vector3.up, Vector3.back);
        Debug.Log("angle" + angle);
        if(angle>=0&&angle<=180)
        {
        Quaternion rotation = Quaternion.Euler(0, 0, -direction.x * rotationSpeed);
            Debug.Log("rt1" + rotation);
            transform.rotation = initialRotation * rotation;
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(0, 0, -direction.x * rotationSpeed);
            Debug.Log("rt2"+rotation);
            transform.rotation = initialRotation * rotation;
        }
        yield return new WaitForSeconds(0.05f);
    }
}
