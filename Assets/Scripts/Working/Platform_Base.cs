using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Platform_Base : MonoBehaviour
{
    [SerializeField] private Platform_PlatformFollowPath WayPointPath;
    [SerializeField] private float Speed = 2;

    private int TargetWayPointIndex;

    private Transform PreviousWayPoint;
    private Transform TargetWayPoint;

    private float TimeToWayPoint;
    private float ElapsedTime;


    void Start()
    {
        TargetNextWayPoint();
    }

    
    void FixedUpdate()
    {

        //La plataforma se mueve en función al tiempo transcurrido
        ElapsedTime += Time.deltaTime;

        float ElapsedPercentage = ElapsedTime/TimeToWayPoint;
        ElapsedPercentage = Mathf.SmoothStep(0, 1, ElapsedPercentage);
        
        transform.position = Vector3.Lerp(PreviousWayPoint.position, TargetWayPoint.position, ElapsedPercentage);
        transform.rotation = Quaternion.Lerp(PreviousWayPoint.rotation, TargetWayPoint.rotation, ElapsedPercentage);
        
        if (ElapsedPercentage >= 1)
        { TargetNextWayPoint(); }


    }
    //------------------------------------
    private void TargetNextWayPoint() //Al llamar a esta función cambia al siguiente destino en la ruta

    {
        //Plataforma anterior, siguiente del Indice y plataforma siguiente
        
        PreviousWayPoint = WayPointPath.GetWayPoint(TargetWayPointIndex); 
        TargetWayPointIndex = WayPointPath.GetNwxtWayPointIndex(TargetWayPointIndex);
        TargetWayPoint = WayPointPath.GetWayPoint(TargetWayPointIndex);


        ElapsedTime = 0;

        //Tiempo que tarda en recorrer
        float DistanceToWayPoint = Vector3.Distance(PreviousWayPoint.position, TargetWayPoint.position);
        TimeToWayPoint = DistanceToWayPoint / Speed; 

    }

    //-----------------------------
    //Para que el personaje no caiga de la plataforma, deberá ser hijo momentaneamente de la plataforma
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }

}
