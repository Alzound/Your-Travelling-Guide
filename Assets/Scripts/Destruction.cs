using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public Rigidbody one;
    public Rigidbody two;
    public Rigidbody three;
    public Rigidbody four;
    public Rigidbody five;
    public Rigidbody six;
    public Rigidbody seven;
    public Rigidbody eight;
    public Rigidbody nine;
    public Rigidbody ten;
    public Rigidbody eleven;
    public Rigidbody twelve;
    public Rigidbody thirteen;
    public Rigidbody fourtheen;
    public Rigidbody fifthteen;
    public Rigidbody sixteen;
    public Rigidbody seventeen;
    public Rigidbody eighteen;
    public Rigidbody nineteen;
    public Rigidbody twenty;
    private int count = 0; 

    private void Start()
    {
        StartCoroutine(Fall());
        
    }

    private void FixedUpdate()
    {
        Fall();
      
        Debug.Log(count); 
        FallPhase_one(); 
    }


    void FallPhase_one()
    {
        switch(count)
        {
            case 1:
                one.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;

            case 2:
                two.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;

            case 3:
                three.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 4:
                four.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 5:
                five.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 6:
                six.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 7:
                seven.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 8:
                eight.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 9:
                nine.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;

            case 10:
                ten.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;

            case 11:
                eleven.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 12:
                twelve.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 13:
                thirteen.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 14:
                fourtheen.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 15:
                fifthteen.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 16:
                sixteen.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 17:
                seventeen.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 18:
                eighteen.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 19:
                nineteen.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
            case 20:
                twenty.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                break;
        }
      
       
      
    }

    IEnumerator Fall()
    {
        for (int i = 0; i <= 20; i++)
        {
            yield return new WaitForSeconds(5);
            count++;
        }
    }
}
