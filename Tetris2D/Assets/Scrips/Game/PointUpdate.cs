using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointUpdate : MonoBehaviour
{
    public static TextMeshPro Points;
    //public static TextMeshProUGUI EndPoint;
    public static int point;

    // Start is called before the first frame update
    void Start()
    {
        Points = GetComponent<TextMeshPro>();
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Points.text = point.ToString();
        
        if (PlayerPrefs.GetInt("Highscore") < point)
        {
            PlayerPrefs.SetInt("Highscore", point);
        }

    }


        
 

}
