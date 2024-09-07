using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTest : MonoBehaviour
{

    private FadeScreen fadeController;
    // Start is called before the first frame update
    void Start()
    {

        fadeController = FindObjectOfType<FadeScreen>();
        StartCoroutine(fadeController.FadeIn());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
