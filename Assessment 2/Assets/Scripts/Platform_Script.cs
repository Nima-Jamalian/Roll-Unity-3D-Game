using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Script : MonoBehaviour
{
    private Rigidbody MyPlatform;

    //for generating the golds
    [SerializeField]
    private GameObject Golds;
    [SerializeField]
    private float GoldRate;
    // Start is called before the first frame update
    void Start()
    {
        //getting the component
        MyPlatform = GetComponent<Rigidbody>();
        if(Random.value < GoldRate)
        {
            Vector3 temp = transform.position;
            temp.y += 2f;
            Instantiate(Golds, temp, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //start falling down
    IEnumerator Falling_Down()
    {
        yield return new WaitForSeconds(0.1f);
        MyPlatform.isKinematic = false;
        StartCoroutine(Deleting_GameObject());
    }

    //deleting the game objects
    IEnumerator Deleting_GameObject()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    void OnTriggerExit(Collider target)
    {
        //check if player has exit the trigger of platform
        if (target.tag == "Player")
        {
            StartCoroutine(Falling_Down());
            //platform falls down
            //MyPlatform.isKinematic = false;
        }
    }

    }



/*
 * References:
 * https://answers.unity.com/questions/796881/c-how-can-i-let-something-happen-after-a-small-del.html
 */
