using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionRock : MonoBehaviour
{

    private bool used = false;
    

    void OnCollisionEnter()
    {
        if (!used)
        {
            GameObject.FindGameObjectWithTag("Worm").GetComponent<EnemyController>().distract(this.gameObject);
            used = true;
            StartCoroutine(Cleaner());
        }
        
    }

    IEnumerator Cleaner()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
        
    }
}
