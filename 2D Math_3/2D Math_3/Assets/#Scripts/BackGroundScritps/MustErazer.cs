using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustErazer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            Destroy(other.gameObject);
        }

    }

    
}
