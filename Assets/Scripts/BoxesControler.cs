using System;
using UnityEngine;

public class BoxesControler : MonoBehaviour
{
    
    public bool CanMov=false;
    public float speed;
    public bool Can_X1=false;
    public bool Can_X2=false;
    public bool Can_X3=false;
    public bool Can_X4=false;
    public bool Can_X5=false;

    void Start()
    {
        
    }

    void Update()
    {
        if (CanMov)
        {
            BreakUpConnection();
            MoveToSend(Vector3.right);
        }

        if (Can_X1)
        {
            X1();
        }else if (Can_X2)
        {
            X2();
        }else if (Can_X3)
        {
            X3();
        }else if (Can_X4)
        {
            X4();
        }else if (Can_X5)
        {
            X5();
        }



    }


    void BreakUpConnection()
    {
        this.gameObject.transform.SetParent(null);
        for (int i = 0; i < HandControler.handInstance.Boxes.Count; i++)
        {
            if (HandControler.handInstance.Boxes[i] == this.gameObject)
            {
                HandControler.handInstance.Boxes.RemoveAt(i);
            }
        }

        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    void MoveToSend(Vector3 direction)
    {
        transform.position += direction*speed*Time.deltaTime;
    }

    

    void X1()
    {
        BreakUpConnection();
        MoveToSend(Vector3.right);
    }

    void X2()
    {
        BreakUpConnection();
        MoveToSend(Vector3.left);
    }

    void X3()
    {
        BreakUpConnection();
        MoveToSend(Vector3.right);
    }

    void X4()
    {
        BreakUpConnection();
        MoveToSend(Vector3.left);
    }

    void X5()
    {
        BreakUpConnection();
        MoveToSend(Vector3.forward);

    }
}
