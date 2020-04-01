using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    private float enemyMoveSpeed=5f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(transform.forward * enemyMoveSpeed * Time.deltaTime);
    }
}
