using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beerChartScript : MonoBehaviour
{
    public GameObject coffeeBarchart, beerBarchart, studentBarchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenBeerBtnClicked() {
        if(beerBarchart.activeInHierarchy == true) {
            beerBarchart.SetActive(false);
        } else {
            beerBarchart.SetActive(true);
            coffeeBarchart.SetActive(false);
            studentBarchart.SetActive(false);
        }
    }
}
