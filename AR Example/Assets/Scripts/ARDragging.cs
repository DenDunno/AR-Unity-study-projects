using Lean.Common;
using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARDragging : LeanDragTranslate
{
	private Camera _ccamera;
    private ARRaycastManager _raycastManager;


    public void Construct(ARRaycastManager raycastManager)
    {
        _raycastManager = raycastManager;
    }


    private void Start()
    {
        _ccamera = Camera.main;
	}


    protected override void Translate(Vector2 screenDelta)
    {
        Vector2 screenPoint =  Input.GetTouch(0).position;

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        _raycastManager.Raycast(screenPoint, hits, TrackableType.Planes);


        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
        }

        else
        {
            transform.position = _ccamera.ScreenToWorldPoint(screenPoint);
        }
	}
}
