using UnityEngine;

public class EnemyBird : MonoBehaviour, IInteractable
{
    public void Construct(BirdShit bullet)
    {
        bullet.Move();
    }
}
