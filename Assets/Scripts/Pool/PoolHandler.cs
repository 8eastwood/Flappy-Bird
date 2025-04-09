using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Pool;

public class PoolHandler<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    protected ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>
        (createFunc: () => Instantiate(_prefab),
            actionOnGet: GetFromPool,
            actionOnRelease: ReleaseInPool,
            actionOnDestroy: Destroy,
            collectionCheck: true,
            _poolCapacity,
            _poolMaxSize
        );
    }

    private void GetFromPool(T prefab)
    {
        // prefab.gameObject.SetActive(true);
    }

    private void ReleaseInPool(T prefab)
    {
        prefab.gameObject.SetActive(false);
    }
}