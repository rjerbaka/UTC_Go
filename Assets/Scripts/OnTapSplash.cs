using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  script destiné à la transition entre le Splash_Screen et le Map_Screen
    La transition doit être déclenchée au premier tap sur le splash

*/

public class OnTapSplash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transition(){
        SceneManager.LoadScene("MapScene");

        // unload the splash screen because it's not needed anymore
        SceneManager.UnloadSceneAsync("SplashScene");
    }
}
