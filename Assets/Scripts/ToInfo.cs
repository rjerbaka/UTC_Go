using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadInfo(){
        string name = this.transform.Find("PlaceName").GetComponent<Text>().text;
        SceneTransition.load("InfoScene");
        GenerateInfo.place = name;
    }
}
