using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private float _speed = 0.7f;
    private float _aliveTime = 1.3f;
    private Explosion _explosion;


    private void Start()
    {
        Destroy(gameObject, _aliveTime);
        _explosion = Resources.Load<Explosion>("Prefabs/Explosion");
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, _speed * Time.deltaTime);
    }


    public void Explode()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Material material = GetComponent<MeshRenderer>().material;

        var explosion = Instantiate(_explosion , transform.position , Quaternion.identity);
        explosion.Construct(mesh, material);

        Destroy(gameObject);        
    }
}
