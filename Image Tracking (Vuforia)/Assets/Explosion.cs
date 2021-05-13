using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class Explosion : MonoBehaviour
{
    private ParticleSystem _particleSystem;


    private void Start()
    {
        Destroy(gameObject, 2);
    }


    public void Construct(Mesh mesh , Material material)
    {
        _particleSystem = GetComponent<ParticleSystem>();
        var renderer = _particleSystem.GetComponent<ParticleSystemRenderer>();

        renderer.mesh = mesh;
        renderer.material = material;
    }
}