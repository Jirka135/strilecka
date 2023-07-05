using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform pocemkamdeš;
    Vector3 moveDirection;

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    public void SetTargetPosition(Transform target)
    {
        pocemkamdeš = target;
        StartCoroutine(MoveTowardsTarget());
    }

    IEnumerator MoveTowardsTarget()
    {
        while (true)
        {
           WhereIsPlayer();
           yield return new WaitForSeconds(0.2f);
        }
    }

    void WhereIsPlayer()
    {
        moveDirection = (pocemkamdeš.position - transform.position).normalized;
    }

    void Move()
    {
        if (pocemkamdeš == null) return;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}