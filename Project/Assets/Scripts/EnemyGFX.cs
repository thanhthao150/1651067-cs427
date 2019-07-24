using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            //moving right
            transform.localScale = new Vector3(-10f, 10f, 10f);
        }else if(aiPath.desiredVelocity.x < -0.01f)
        {
            //moving left
            transform.localScale = new Vector3(10f, 10f, 10f);
        }
    }
}
