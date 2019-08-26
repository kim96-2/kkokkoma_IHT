using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountUI : MonoBehaviour
{
    public static int count = 0;
    Text CountText;
    // Start is called before the first frame update
    void Start()
    {
        CountText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CountText.text = "Count is :" + count;
        
    }
    void CountUp()
    {
        count++;

    }

}
