using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditControl : MonoBehaviour
{
    public GameObject[] Credit;
    
    void Start()
    {
        StartCoroutine(PlayCredit());
    }

    IEnumerator PlayCredit()
    {
        Credit[0].SetActive(true);
        yield return new WaitForSeconds(3);
        Credit[0].SetActive(false);
        Credit[1].SetActive(true);
        yield return new WaitForSeconds(6);
        Credit[1].SetActive(false);
        Credit[2].SetActive(true);
        yield return new WaitForSeconds(6);
        Credit[2].SetActive(false);
        Credit[3].SetActive(true);
    }
    
    
}
