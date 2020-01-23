using UnityEngine;

public class DestroyBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _sfx;


    public void DestroyObject()
    {
        if (_sfx != null)
        {
            ObjectPoolingManager.Instance.InstantiatePoolItem(_sfx, transform.position, Quaternion.identity);
        }

        ObjectPoolingManager.Instance.DestroyPoolItem(gameObject);
    }

}
