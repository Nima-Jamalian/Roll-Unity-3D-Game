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

/*
 * References:
 * https://answers.unity.com/questions/203726/how-exactly-does-the-operator-work.html
 * https://docs.unity3d.com/ScriptReference/Quaternion.html
 * https://docs.unity3d.com/ScriptReference/SerializeField.html
 * https://www.udemy.com/unity-game-development-make-professional-3d-games/learn/v4/t/lecture/6707974?start=0
 * https://www.youtube.com/watch?v=7jdL5538bEo&list=PLLH3mUGkfFCXps_IYvtPcE9vcvqmGMpRK
 * https://www.youtube.com/watch?v=zASQswHVphY
 * https://www.youtube.com/watch?v=zASQswHVphY
 */
