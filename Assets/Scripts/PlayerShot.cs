using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private MoveBehaviour _movebehaviour;
    private DestroyBehavior _destroyer;
    // Start is called before the first frame update
    void Start()
    {
        _movebehaviour = GetComponent<MoveBehaviour>();
        _destroyer = GetComponent<DestroyBehavior>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _movebehaviour.move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _destroyer.DestroyObject();
    }
}
