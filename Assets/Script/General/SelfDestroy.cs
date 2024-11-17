using System;
using System.Collections;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float timerForDestruction;
    void Start()
    {
        StartCoroutine(DestroySelf(timerForDestruction));
    }

    private IEnumerator DestroySelf(float timerForDestruction)
    {
        yield return new WaitForSeconds(timerForDestruction);
        Destroy(gameObject);
    }

    
}
