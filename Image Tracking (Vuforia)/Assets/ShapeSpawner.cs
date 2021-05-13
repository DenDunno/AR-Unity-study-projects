using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    private Shape[] _shapes = new Shape[3];
    private Color[] _colors =
    {
        Color.red , Color.green , Color.yellow , Color.blue , Color.cyan
    };

    private float _coolDownTime = 0.5f;
    private float _offsetCoef = 0.1f;
    private int _positionIndex = 0;


    private void Awake()
    {
        _shapes = Resources.LoadAll<Shape>("Prefabs");
    }


    public void StartMiniGane()
    {
        StartCoroutine(SpawnShapes());
    }


    public IEnumerator SpawnShapes()
    {
        while (gameObject.activeInHierarchy == true)
        {            
            var shape = Instantiate(_shapes[Random.Range(0, _shapes.Length)], transform);
            ConstructShape(shape);

            yield return new WaitForSeconds(_coolDownTime);
        }
    }


    private void ConstructShape(Shape shape)
    {
        if (_positionIndex > 5)
            _positionIndex = 0;

        Vector3 offset = transform.forward * _offsetCoef * (_positionIndex % 2 == 0 ? -1 : 1);
        shape.transform.position = transform.position + offset;

        ++_positionIndex;

        Material material = shape.GetComponent<MeshRenderer>().material;
        material.color = _colors[Random.Range(0 , _colors.Length)];

        shape.GetComponent<MeshRenderer>().material = material;
    }
}
