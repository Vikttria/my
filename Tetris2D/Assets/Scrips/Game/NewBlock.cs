using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBlock : MonoBehaviour
{
    public GameObject[] element;

    public int blockNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        blockNext();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void blockNext()
    {
        int i = Random.Range(0, element.Length);

        GameObject instance = Instantiate(element[i]);
        instance.transform.position = new Vector3(4, 14, -5);

        switch (i)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                blockNumber = 4;
                break;
            case 7:
                blockNumber = 3;
                break;
            case 8:
                blockNumber = 2;
                break;
        }
        
    }
}
