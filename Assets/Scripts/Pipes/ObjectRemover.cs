using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
   [SerializeField] private ObjectPool _pool;

   private void OnTriggerEnter2D(Collider2D other)
   {
      Debug.Log("ObjectRemover");
      if (other.TryGetComponent(out Pipe pipe))
      {
         Debug.Log("OnTriggerEnter2D");
         _pool.PutObject(pipe);
      }
   }
}
