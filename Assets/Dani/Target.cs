using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    public float timeToDisappear = 5f; 

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(timeToDisappear);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {       
        gameManager.IncreaseScore();

        Destroy(gameObject);
    }
}