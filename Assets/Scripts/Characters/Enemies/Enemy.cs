using UnityEngine;

public enum EnemyType
{
    None,
    Goblin,
    Skeleton,
    Werewolf
}
public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
}
