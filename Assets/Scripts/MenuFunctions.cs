using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    
    public GameObject sidePanel;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //sidePanel.SetActive(false);
        animator = sidePanel.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void menuPressed(){
        // if (!sidePanel.activeSelf){
        //     sidePanel.SetActive(true);
        // } else {
            animator.SetBool("panel_onScreen", true);
       // }
        
    }

    public void placesPressed(){
        SceneTransition.load("GroupScene");
    }

    public void mapPressed(){
        animator.SetBool("panel_onScreen", false);
        //sidePanel.SetActive(false);
    }

    public void langPressed(){
        SceneTransition.load("LanguageScene");
    }

}
