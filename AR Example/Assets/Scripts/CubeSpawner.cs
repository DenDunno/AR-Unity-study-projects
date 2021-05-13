using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class CubeSpawner : MonoBehaviour
{
    private Cube _cube;
    private Camera _camera;
    private ARRaycastManager _raycastManager;


    private void Start()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
        _cube = Resources.Load<Cube>("Prefabs/Cube");
        _camera = Camera.main;
    }


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 inputPosition = touch.position;

            if (CheckCube(inputPosition) == false && touch.phase == TouchPhase.Began)
            { 
                SpawnCube(inputPosition);
            }
        }
    }


    private bool CheckCube(Vector2 inputPosition)
    {
        Cube cube = null;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit))
        {
            cube = raycastHit.collider.GetComponent<Cube>();
        }

        return cube != null;
    }


    private void SpawnCube(Vector2 inputPosition)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        _raycastManager.Raycast(inputPosition, hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            var cube = Instantiate(_cube, hits[0].pose.position, hits[0].pose.rotation);
            cube.GetComponent<ARDragging>().Construct(_raycastManager);
        }
    }
}
