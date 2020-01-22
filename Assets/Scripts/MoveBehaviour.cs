using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector2 _direction;

    [SerializeField]
    private float _velocity;

    private Rigidbody2D _rb;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void move()
    {
        _rb.MovePosition(new Vector3(transform.position.x + _velocity * Time.deltaTime * _direction.x,
                                       transform.position.y + _velocity * Time.deltaTime * _direction.y,
                                       0));
    }

    public void move(Vector2 newdir)
    {
        _rb.MovePosition(new Vector3(transform.position.x + _velocity * Time.deltaTime * newdir.x,
                                       transform.position.y + _velocity * Time.deltaTime * newdir.y,
                                       0));
    }
}
