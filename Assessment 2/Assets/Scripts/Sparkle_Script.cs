using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparkle_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Deactive_Effect());
    }

    IEnumerator Deactive_Effect()
    {
        yield return new WaitForSeconds(1.3f);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
