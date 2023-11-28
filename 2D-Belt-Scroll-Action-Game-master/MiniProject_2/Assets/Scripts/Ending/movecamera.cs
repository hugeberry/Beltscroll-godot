using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class movecamera : MonoBehaviour
{
    public GameObject Tracan;
    public GameObject Text;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;
    public GameObject Text7;
    public GameObject Text8;
    public GameObject Text9;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    bool start = true;
    bool handang1 = true;
    bool handang2 = true;
    public GameObject Camera;

    float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
      if(start == true)
        {
            start = false;
            transform.position = new Vector3(0, 20, -25f);
        }
        timer += Time.deltaTime;

        Vector3 velo = Vector3.zero;

        if(transform.position.x <= 150)
            transform.position = new Vector3(
            transform.position.x + (Time.deltaTime*5), transform.position.y, transform.position.z);

       
        if(timer >= 1)
        {
            Image2.SetActive(true);
            Image1.SetActive(true);
        }

        if(timer >= 8)
        {            
            Image3.SetActive(true);
            Text.SetActive(true);
            if (timer >= 15)
            {
                Text2.SetActive(true);
            }
        }



        if(timer >= 22 && handang1 == true)
        {
            handang1 = false;
            transform.position = new Vector3(-748f, 26, -25f);            
            Text3.SetActive(true);


            
        }

        if (timer >= 29)
        {
            Text4.SetActive(true);
        }

        if (timer >= 36 && handang2 == true)
        {
            handang2 = false;
            transform.position = new Vector3(-1230f, 15, -25f);
            Text5.SetActive(true);


        }

        if (timer >= 43)
        {
            Text6.SetActive(true);
        }

        if(timer >= 51)
        {
            Text7.SetActive(true);
        }
        if(timer >= 58)
        {
            Text8.SetActive(true);
        }
                
        if(timer >=65)
        {            
            Image4.SetActive(true);
            
        }

        if(timer >=68.5f)
        {
            transform.position = new Vector3(0, 20, -25f);
            Tracan.SetActive(true);
            Text9.SetActive(true);
        }
    }
}
