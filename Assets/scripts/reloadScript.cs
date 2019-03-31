using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) //WHY IS THE DEBUG NOT PRINTING??
        {
            SceneManager.LoadScene("mainLabScene");
            Debug.Log("Loading");
        }
  
    }
}
