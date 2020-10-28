using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToGroupDetail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toDetailedList(){
        string name = this.transform.Find("GroupName").GetComponent<Text>().text;
        SceneTransition.load("ListScene");
        GeneratePlaces.group = name;
    }
}
