using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Adds amount to max hit points when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    Enemy enemy;

    int currentHitPoints = 0;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            this.gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
