using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChargeAt : MonoBehaviour
{

    public GameObject blueGuy;
    public GameObject greenGuy;
    public GameObject redGuy;

    public bool isAttacked = false;

    public Vector3 impulse = new Vector3(5.0f, 5.0f, 5.0f);
    Vector3 currentPos;
    void Start()
    {
        currentPos = redGuy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Attack());

        if(isAttacked)
        {
            greenGuy.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
        }
    }

    IEnumerator Attack()
    {
        Debug.Log("Charging");
        yield return new WaitForSeconds(1.3f);
        transform.position = Vector3.MoveTowards(transform.position, blueGuy.transform.position, 33 * Time.deltaTime);
        Debug.Log("Attacked");
        yield return new WaitForSeconds(0.3f);
        isAttacked = true;
    }
}
