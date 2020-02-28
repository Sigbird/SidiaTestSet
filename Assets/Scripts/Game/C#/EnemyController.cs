using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Destroy(this.gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, -10);
    }

    public void GetHit()
    {
        Destroy(this.gameObject);
        //StartCoroutine(WaitAndBlink());
    }

    IEnumerator WaitAndBlink()
    {
        GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.3f);
        GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1f);
        yield return new WaitForSeconds(0.3f);
        GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.3f);
        GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1f);
        Destroy(this.gameObject);
    }

}
