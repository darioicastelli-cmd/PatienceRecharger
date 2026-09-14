using UnityEngine;

public class Platform_PlatformFollowPath : MonoBehaviour
{
    public Transform GetWayPoint(int waypointIndex)
    { 
        return transform.GetChild(waypointIndex);
    }
    //-------------------------------------------

    public int GetNwxtWayPointIndex(int currentWayPointIndex)
    { 
        int nextWayPointIndex = currentWayPointIndex + 1;
        if (nextWayPointIndex == transform.childCount)
        {
            nextWayPointIndex = 0;
        }


        return nextWayPointIndex;
    }

}
