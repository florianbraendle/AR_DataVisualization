using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class stateScript : MonoBehaviour
{
    public GameObject coffeeBarchart, beerBarchart, studentBarchart;
    public TMPro.TextMeshProUGUI detailText;
    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    public GameObject detailCard;
    public string coffeeAmount;
    public string beerAmount;
    public string studentAmount;
    //public TextMeshPro detailText;
    // Start is called before the first frame update
    void Start()
    {
        definedButton = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if(Input.GetMouseButtonDown(0)) {
            if(Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject) {
                Debug.Log("Clicked bw");
                OnClick.Invoke();
            } else {
                print("Clicked outside bw!");
            }
        }
    }

    public void showDetail() {
        detailCard.SetActive(true);
        if(coffeeBarchart.activeInHierarchy == true) {
            detailText.text =  coffeeAmount + " cups per day";
            coffeeBarchart.SetActive(false);
        } else if (beerBarchart.activeInHierarchy == true) {
            detailText.text =  beerAmount + " hectoliters in 2021";
            beerBarchart.SetActive(false);
        } else if(studentBarchart.activeInHierarchy == true) {
            studentBarchart.SetActive(false);
            detailText.text = studentAmount + " students in 2021/2022";
        }

    }
}
