using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MoveBehaviour _movebehaviour;
    // Start is called before the first frame update
    void Start()
    {
        _movebehaviour = GetComponent<MoveBehaviour>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _movebehaviour.move();
    }
}
