using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector2 _direction;

    [SerializeField]
    private float _velocity;
    public void move()
    {
        transform.position = new Vector3(transform.position.x + _velocity * Time.deltaTime*_direction.x,
                                       transform.position.y + _velocity * Time.deltaTime*_direction.y,
                                       0);
    }
}
