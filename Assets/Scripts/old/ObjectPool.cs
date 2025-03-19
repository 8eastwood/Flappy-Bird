using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   [SerializeField] private Transform _container;
   [SerializeField] private EnemyBird _enemyPrefab;
   
   private Queue<EnemyBird> _pool;
   
   public IEnumerable<EnemyBird> PooledObjects => _pool;

   private void Awake()
   {
      _pool = new Queue<EnemyBird>();
   }

   public EnemyBird GetObject()
   {
      if (_pool.Count == 0)
      {
         var enemyBird = Instantiate(_enemyPrefab);
         enemyBird.transform.parent = _container;
         
         return enemyBird;
      }
      
      return _pool.Dequeue();
   }

   public void PutObject(EnemyBird enemyBird)
   {
      _pool.Enqueue(enemyBird);
      enemyBird.gameObject.SetActive(false);
   }

   public void Reset()
   {
      _pool.Clear();
   }
}
