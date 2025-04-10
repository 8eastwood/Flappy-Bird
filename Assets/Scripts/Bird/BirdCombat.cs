using UnityEngine;

public class BirdCombat : MonoBehaviour
{
    [SerializeField] BulletSpawner bulletSpawner;
    
    private Vector3 _bulletPosition ;
    private float _offsetX = 2f;
    private int _directionChanger = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _bulletPosition = transform.position;
            _bulletPosition.x += _offsetX;
            
            Shoot();
        }
    }

    private void Shoot()
    {
        bulletSpawner.GetBulletFromPool(_bulletPosition, _directionChanger);
    }
}