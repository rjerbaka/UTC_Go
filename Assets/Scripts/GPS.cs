using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Access latitude and longitude :
// GPS.Instance.latitude
// GPS.Instance.longitude

public class GPS : MonoBehaviour
{
    public static GPS Instance {set; get;}
    public float latitude;
    public float longitude;

    public void Start(){
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    IEnumerator StartLocationService()
    {
        
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser){
            Debug.Log("User has not enabled service location");
            yield break;
        }
            

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Localisation init Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        // Input.location.Stop();
    }
}