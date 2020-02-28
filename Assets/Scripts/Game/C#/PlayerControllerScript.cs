using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public bool IA;
    public int Lane;
    public Transform[] Lanes;
    public Vector3 targetPos;
    public bool moving;
    public float JumpTime;
    public float JumpPower= 150;
    public bool Jump;
    private float Speed = 100;
    private Rigidbody PlayerRigidbody;
    public GameObject[] Particles;
    public SkinnedMeshRenderer MeshRenderer;
    
    // Start is called before the first frame update

    private void Awake()
    {
        Jump = false;
        GameMasterScript.PlayerControler = this.gameObject.GetComponent<PlayerControllerScript>();
    }
    void Start()
    {
        targetPos = Lanes[1].position;
        PlayerRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IA)
        {
            RaycastHit hit;

            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 10))
            {
                if (hit.transform.tag != "Point")
                {
                    IAChangeLane();
                }
            }
        }

        if (transform.position.x> targetPos.x + 0.2f || transform.position.x < targetPos.x - 0.2f)
        {
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, -0.50f, 0), new Vector3(targetPos.x, -0.50f, 0), Time.deltaTime * 4);            
            moving = true;
        }
        else {
            moving = false;
            Particles[1].GetComponent<ParticleSystem>().Stop();
            Particles[0].GetComponent<ParticleSystem>().Stop();
        }

        if (Jump && moving == false )
            PlayerRigidbody.AddForce(Vector2.up * JumpPower);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            GameMasterScript.life -= 0.2f;
        }
        if (collision.transform.tag == "Point")
        {
            GameMasterScript.score += 100;
            collision.transform.gameObject.GetComponent<EnemyController>().GetHit();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag == "Ground") {
        JumpPower = 0;
        Jump = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Jump==false)
            JumpPower = 150;
    }

    public void IAChangeLane()
    {
        switch (Lane)
        {
            case 0:
                MoveToLane(1);
                break;
            case 1:
                MoveToLane(1);
                break;
            case 2:
                MoveToLane(0);
                break;
        }
    }

    public void MoveToLane(int x)
    {
        if(x == 1) //Direita
        {
            Particles[0].GetComponent<ParticleSystem>().Play();
            Particles[1].GetComponent<ParticleSystem>().Stop();
            switch (Lane)
            {
                case 0:
                    targetPos = Lanes[1].position;
                    Lane = 1;
                    break;
                case 1:
                    targetPos = Lanes[2].position;
                    Lane = 2;
                    break;
                case 2:
                    Lane = 2;
                    break;
            }
        }
        else if(x == 0) { //Esquerda
            Particles[1].GetComponent<ParticleSystem>().Play();
            Particles[0].GetComponent<ParticleSystem>().Stop();
            switch (Lane)
            {
                case 0:
                    Lane = 0;
                    break;
                case 1:
                    targetPos = Lanes[0].position;
                    Lane = 0;
                    break;
                case 2:
                    targetPos = Lanes[1].position;
                    Lane = 1;
                    break;
            }
        }
    }

    public void JumpAction()
    {
        Jump = true;
    }

 

}
