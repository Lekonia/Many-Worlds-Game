using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthBehaviour : MonoBehaviour
{
    public GameObject[] Item;
    public float Time;

    void Start()
    {
        StartCoroutine("enable");
        //SendMessage("enable");
        //gameObject.SendMessage("enable");
    }

    void Update()
    {

    }

    IEnumerator enable()
    {
        yield return new WaitForSeconds(Time);
        Item[0].SetActive(true);
        yield return new WaitForSeconds(Time);
        Item[0].SetActive(false);
        Item[1].SetActive(true);
        yield return new WaitForSeconds(Time);
        Item[1].SetActive(false);
        Item[2].SetActive(true);
        yield return new WaitForSeconds(Time);
        Item[2].SetActive(false);
        Item[3].SetActive(true);
    }
}
