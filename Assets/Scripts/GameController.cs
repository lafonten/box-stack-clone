using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Random = System.Random;

public class GameController : MonoBehaviour
{
    [Header("Select Type:")]
    [SerializeField]
    private bool PackingArea;

    [SerializeField] private bool TapingArea;
    [SerializeField] private bool FillingArea;
    [SerializeField] private bool ShreddingArea;
    [SerializeField] private bool CrushArea;
    [SerializeField] private bool Hammer;
    [SerializeField] private bool ColorSection;
    [SerializeField] private bool SendingArea;
    [SerializeField] private bool X1;
    [SerializeField] private bool X2;
    [SerializeField] private bool X3;
    [SerializeField] private bool X4;
    [SerializeField] private bool X5;

    
    public GameObject saw1;
    public GameObject saw2;
    public ParticleSystem pS;
    public GameObject hammer;
    


    [Header("Rotation Features")]
    [SerializeField] private float angle_x;
    [SerializeField] private float angle_y;
    [SerializeField] private float angle_z;
    [SerializeField] private bool canturn;
    private int direction;


    [Header("Smash Features")]
    [SerializeField] private float smashpower;


    [Header("Color Features")]
    [SerializeField] private List<GameObject> colors = new List<GameObject>();
    [SerializeField] private float speed_color;


    void Start()
    {

    }

    void Update()
    {
        if (ColorSection)
        {
            
        }

        if (ShreddingArea)
        {
            ShreddingControl();
        }

        if (Hammer)
        {
            HammerControler();
        }
    }

    void RotationControl(GameObject obj)
    {
        obj.gameObject.transform.Rotate(angle_x, angle_y, angle_z);
    }

    void HammerControler()
    {

        if (hammer.transform.eulerAngles.z <= 1 && canturn)
        {
            direction = 1;
            canturn = false;
        }
        else if (hammer.transform.eulerAngles.z >= 130 && !canturn)
        {
            direction = -1;
            canturn = true;
        }
        hammer.gameObject.transform.Rotate(0, 0, angle_z * direction * Time.deltaTime);
    }

    private void ShreddingControl()
    {
        RotationControl(saw1);
        RotationControl(saw2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            if (PackingArea)
                Packing(other.gameObject);
            else if (TapingArea)
                Taping(other.gameObject);
            else if (FillingArea)
                Filling(other.gameObject);
            else if (ShreddingArea)
                Shredding(other.gameObject);
            else if (CrushArea)
                Crush(other.gameObject);
            else if (SendingArea)
            {
                SendingSection(other.gameObject);
            }else if (X1 )
            {
                other.gameObject.GetComponent<BoxesControler>().Can_X1 = true;
                GameObject.FindGameObjectWithTag("X1").GetComponent<BoxCollider>().enabled = false;

            }
            else if (X2)
            {
                other.gameObject.GetComponent<BoxesControler>().Can_X2 = true;
                GameObject.FindGameObjectWithTag("X2").GetComponent<BoxCollider>().enabled = false;

            }
            else if (X3 )
            {
                other.gameObject.GetComponent<BoxesControler>().Can_X3 = true;
                GameObject.FindGameObjectWithTag("X3").GetComponent<BoxCollider>().enabled = false;

            }
            else if (X4 )
            {
                other.gameObject.GetComponent<BoxesControler>().Can_X4 = true;
                GameObject.FindGameObjectWithTag("X4").GetComponent<BoxCollider>().enabled = false;

            }
            else if (X5 )
            {
                other.gameObject.GetComponent<BoxesControler>().Can_X5 = true;
                GameObject.FindGameObjectWithTag("X5").GetComponent<BoxCollider>().enabled = false;
                GameObject.FindGameObjectWithTag("Hand").GetComponent<HandControler>().forward_speed = 0;

            }
        }
        else
        {
            if (ShreddingArea)
            {
                pS.Stop();
            }
        }
    }



    void Packing(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
    }

    void Taping(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().materials[0].color = Color.red;
    }

    void Filling(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().materials[0].color = Color.magenta;
    }

    void Shredding(GameObject obj)
    {
        pS.Play();
        Destroy(obj,1.5f);
    }

    void Crush(GameObject obj)
    {
        obj.gameObject.transform.localScale += Vector3.down * Time.deltaTime * smashpower;
        if (obj.gameObject.transform.localScale.y <= 1f)
        {
            Destroy(obj.gameObject, 0.3f);
        }
    }

    void SendingSection(GameObject obj)
    {
        ////obj.gameObject.transform.SetParent(null);
        obj.gameObject.GetComponent<BoxesControler>().CanMov = true;
        ////obj.gameObject.GetComponent<BoxesControler>().direction = Vector3.right;
        ////obj.gameObject.GetComponent<BoxCollider>().isTrigger = true;

        ////for (int i = 0; i < obj.gameObject.GetComponentInParent<HandControler>().Boxes.Count; i++)
        ////{
        ////    if (obj.gameObject.GetComponentInParent<HandControler>().Boxes[i] == obj.gameObject)
        ////    {
        ////        Destroy(obj.gameObject,3f);
        ////    }
        ////}
    }

}
