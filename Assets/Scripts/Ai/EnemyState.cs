using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSourceDead, audioSourceAttack;
    public BoxCollider attackCollider;
    public CapsuleCollider enemyCollider;
    public float health = 2;
    public bool isDead = false, isAtacking = false;

    float timeInactive = 3.7f, countDownDead, timeAttack = 0.7f, countDownAttack;

    void Start()
    {
        countDownDead = timeInactive;
        countDownAttack = timeAttack;
    }

    void Update()
    {
        if (health <= 0)
        {
            EnemyDead();
            EnemyNotAttacking();
        }

        if (isAtacking && !isDead)
        {
            EnemyAttack();
        }
        else
        {
            EnemyNotAttacking();
        }
    }


    [ContextMenu("EnemyDead")]
    public void EnemyDead()
    {
        countDownDead -= Time.deltaTime;
        isDead = true;
        enemyCollider.enabled = false;

        animator.SetBool("isDead", true);

        if (!audioSourceDead.isPlaying)
        {
            audioSourceDead.Play();
        }

        if (countDownDead <= 0)
        {
            GameManager.Instance.enemiesNumber--;
            animator.SetBool("isDead", false);
            countDownDead = timeInactive;
            health = 2;
            isDead = false;
            enemyCollider.enabled = true;
            gameObject.SetActive(false);
        }
    }

    public void EnemyAttack()
    {
        countDownAttack -= Time.deltaTime;

        animator.SetBool("isAtacking", true);

        if (!audioSourceAttack.isPlaying)
        {
            audioSourceAttack.Play();
        }

        if (countDownAttack <= 0 && !isDead)
        {
            attackCollider.enabled = true;
            countDownAttack = timeAttack;
        }
    }

    public void EnemyNotAttacking()
    {
        animator.SetBool("isAtacking", false);
        attackCollider.enabled = false;
        countDownAttack = timeAttack;
    }
}
