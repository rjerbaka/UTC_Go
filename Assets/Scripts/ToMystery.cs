using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* à retester mais à priori ça marche */

public class ToMystery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMysteryImage(){
        SceneTransition.load("MysteryImageScene");
    }
}
