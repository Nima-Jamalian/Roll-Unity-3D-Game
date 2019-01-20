using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Script : MonoBehaviour
{
    private float Speed = 1.2f;
    private float Angle;

    [SerializeField]
    private GameObject Sparkel_Effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //% -> operator, 
        /*
         * It computes the emainder after dividing its fist operand by its second.
         * All numeric type have predifind remainder operatores.
         * From Unty website    
         * example 5 % 2 -> 1
         * can go two times 2*2 =4 then 5-4 is equal to 1       
         */      
        Angle = (Angle + Speed) % 360f;
        //rotate only on Y axis
        transform.localRotation = Quaternion.Euler(new Vector3(45f, Angle, 0f));
    }


    void OnTriggerEnter(Collider target)
    {
        //check if player has collided with gold
        if(target.tag == "Player")
        {
            //playing sparkel effect
            Instantiate(Sparkel_Effect, transform.position, Quaternion.identity);
            //playing audio
            //Debug.Log("Audio should play");
            Game_Controller.current.Play_Gold_Collection_Sound();
            gameObject.SetActive(false);
        }
    }
}


/*
 * References:
 * https://answers.unity.com/questions/203726/how-exactly-does-the-operator-work.html
 * https://docs.unity3d.com/ScriptReference/Quaternion.html
 * https://docs.unity3d.com/ScriptReference/SerializeField.html
 */
