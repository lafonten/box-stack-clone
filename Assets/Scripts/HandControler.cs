
using System.Collections.Generic;
using UnityEngine;

public class HandControler : MonoBehaviour
{
    [Header("Hand Features")] 
    [SerializeField] private float swap_speed;
    public float forward_speed;

    public List<GameObject> Boxes = new List<GameObject>();
    private Touch touch;

    public static HandControler handInstance;

    void Start()
    {
        handInstance = this;
    }

    void Update()
    {
        SwapControler();
        ForwardSpeed(forward_speed,transform.forward);
        BoxesListControl();
        BoxesPositionControl();
    }

    void SwapControler()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                this.transform.position += transform.right * touch.deltaPosition.x * Time.deltaTime * swap_speed;
            }
        }
    }

    public void ForwardSpeed(float speed,Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Boxes.Add(other.gameObject);
            other.gameObject.transform.position = new Vector3(this.transform.position.x,
                other.gameObject.transform.position.y, this.transform.position.z + 1f*Boxes.Count);
            other.gameObject.transform.SetParent(this.transform);
            this.GetComponent<BoxCollider>().center = new Vector3(this.GetComponent<BoxCollider>().center.x,
                this.GetComponent<BoxCollider>().center.y, this.GetComponent<BoxCollider>().center.z + 1f);
        }
    }

    void BoxesListControl()
    {
        for (int index = 0; index < Boxes.Count; index++)
        {
            if (Boxes[index] == null)
            {
                Boxes.RemoveAt(index);
            }
        }
    }

    void BoxesPositionControl()
    {
        for (int index = 0; index < Boxes.Count; index++)
        {
            if ((Boxes[index].gameObject.transform.position.z-this.transform.position.z) !=1)
            {
                Boxes[index].gameObject.transform.position = new Vector3(this.transform.position.x,
                    Boxes[index].gameObject.transform.position.y, this.transform.position.z + (1f * index));
            }
        }
    }
}
