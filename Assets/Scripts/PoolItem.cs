using UnityEngine;

public class PoolItem : MonoBehaviour
{
    [SerializeField]
    private string _name;

    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }

}
