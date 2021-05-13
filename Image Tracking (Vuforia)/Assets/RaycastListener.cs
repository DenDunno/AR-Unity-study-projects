using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class RaycastListener : MonoBehaviour
{
    private Camera _camera;


    private void Start()
    {
        _camera = Camera.main;
    }


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                Shape shape = raycastHit.collider.GetComponent<Shape>();
                
                if (shape is Shape)
                {
                    shape.Explode();
                }
            }
        }
    }
}