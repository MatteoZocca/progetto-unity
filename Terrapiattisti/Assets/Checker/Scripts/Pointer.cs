using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float radius;
    public Transform castPosition;
    
    public Collider2D[] CheckIfFailed()
    {
       return Physics2D.OverlapCircleAll(castPosition.position,radius);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(castPosition.position, radius);
    }
}
