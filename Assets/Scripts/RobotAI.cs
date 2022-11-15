using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotAI : MonoBehaviour
{
    public byte State;
    //public Vector3 Point;//, lastPosition;
    public float
        MaxSpeed = 4,//Максимальная скорость
        DischargeK = 0.75f,//Разрядка в секунду при макс. скорости
        CurrentCharge = 100,//Текущий заряд
        ElectroConsume = 1.5f,//Потребление энергии у станции
        ChargeSpeed = 1f,//Скорость зарядки в секунду
        Endurance = 2;//Прочность

    public float Timer = 0;
    //float Speed = 0;

    public int InventoryCapacity = 256;
    public NavMeshAgent nma;

    public float remaining_dist, charge_needed;
    public Transform wh1, wh2, wh3;

    public Vector3 NearestPlatform = new Vector3(0, 1.4f, 5);
    public float vel;
    private void Start()
    {
        nma = gameObject.AddComponent<NavMeshAgent>();
        //nma.agentTypeID = 1;
        nma.baseOffset = 1.32f;
        nma.stoppingDistance = 7;
        nma.speed = MaxSpeed;
        State = 0;
        nma.SetDestination(new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)));
        wh1 = transform.Find("root").transform.Find("Circle");
        wh2 = transform.Find("root").transform.Find("Circle.001");
        wh3 = transform.Find("root").transform.Find("Circle.003");
    }
    void FixedUpdate()
    {
        //Speed = Mathf.Lerp(speed, (transform.position - lastPosition).magnitude / Time.deltaTime, 0.75f);
        //lastPosition = transform.position;
    }
    void Update()
    {
        /*
            GoingToResource,
            ProcessingResource,
            GoingToCharge,
            LiftingToCharge,
            Charging,
            LiftingFromCharge
         */
        nma.speed = MaxSpeed;
        vel = nma.velocity.magnitude;
        CurrentCharge -= (vel / MaxSpeed) * Time.deltaTime * DischargeK;
        wh1.Rotate(-vel, 0, 0);
        wh2.Rotate(0, 0, vel);
        wh3.Rotate(0, 0, vel);
        if (State == 0)
        {
            var dist = Vector3.Distance(transform.position, NearestPlatform);
            charge_needed = dist / MaxSpeed * DischargeK * 1.5f;
            if (CurrentCharge <= charge_needed)
            {
                nma.SetDestination(NearestPlatform);
                nma.stoppingDistance = 0;
                State = 2;
            }
            else
            {
                remaining_dist = nma.remainingDistance;
                if (nma.remainingDistance < 7)
                {
                    nma.ResetPath();
                    State = 1;
                    Timer = Random.Range(1f, 5f);
                }
            }
        }
        if (State == 1)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                nma.SetDestination(new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)));
                State = 0;
            }
        }
        if (State == 2)
        {
            if (nma.remainingDistance < 1)
            {
                nma.isStopped = true;
                nma.ResetPath();
                //nma.enabled = false;
                State = 3;
            }
        }
        if (State == 3)
        {
            transform.position = new Vector3(0, 2, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            State = 4;
        }
        if (State == 4)
        {
            transform.position = new Vector3(0, 2, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            CurrentCharge += Time.deltaTime * ChargeSpeed;
            //cp.??? -= Time.deltaTime * ElectroConsume;
            if (CurrentCharge >= 100)
            {
                CurrentCharge = 100;
                State = 5;
            }
        }
        if (State == 5)
        {
            transform.position = NearestPlatform;
            nma.isStopped = false;
            nma.stoppingDistance = 7;
            State = 0;
        }

    }
}
