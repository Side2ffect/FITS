using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Vector3 positionOne;
    [SerializeField] private Vector3 positionTwo;
    private bool movingToTwo;
    [SerializeField] private float speed;
    private float step;
    private Vector3 target;

    private void Start()
    {
        target = positionTwo;
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        if (transform.position == target)
        {
            if (target == positionTwo)
            {
                target = positionOne;
            }
            else
            {
                target = positionTwo;
            }
        }
    }
}
