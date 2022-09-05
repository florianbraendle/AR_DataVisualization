using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeeChartScript : MonoBehaviour
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

    public void whenCoffeeBtnClicked() {
        if(coffeeBarchart.activeInHierarchy == true) {
            coffeeBarchart.SetActive(false);
        } else {
            coffeeBarchart.SetActive(true);
            beerBarchart.SetActive(false);
            studentBarchart.SetActive(false);
        }
    }
}
