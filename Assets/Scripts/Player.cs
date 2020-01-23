using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MoveBehaviour _moveBehaviour;
    // Update is called once per frame

    [SerializeField]
    private GameObject _projectile;

    [SerializeField]
    private Transform _shotPoint;
    private void Awake()
    {
        _moveBehaviour = GetComponent<MoveBehaviour>();
    }

    public void Start()
    {
        StartCoroutine(DoSpawnShots());
    }
    public void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Space))
            
    }

    private IEnumerator DoSpawnShots()
    {
        yield return new WaitForSeconds(0.15f);
        ObjectPoolingManager.Instance.InstantiatePoolItem(
                _projectile,
                _shotPoint.position,
                Quaternion.identity);
        
        yield return DoSpawnShots();

    }
}
