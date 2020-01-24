using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    // Update is called once per frame

    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
    }
    public void FixedUpdate()
    {
        
    }
}
