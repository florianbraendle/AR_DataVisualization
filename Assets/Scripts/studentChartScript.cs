using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class studentChartScript : MonoBehaviour
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

    public void whenStudentBtnClicked() {
        if(studentBarchart.activeInHierarchy == true) {
            studentBarchart.SetActive(false);
        } else {
            studentBarchart.SetActive(true);
            beerBarchart.SetActive(false);
            coffeeBarchart.SetActive(false);
        }
    }
}
