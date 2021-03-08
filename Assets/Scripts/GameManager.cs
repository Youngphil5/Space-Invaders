using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public RawImage _image; 


    // Update is called once per frame
    void Update()
    {
        Destroy(_image);
    }
}
