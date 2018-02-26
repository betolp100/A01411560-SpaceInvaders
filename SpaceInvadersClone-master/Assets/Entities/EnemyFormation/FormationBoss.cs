using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationBoss : MonoBehaviour {
    private bool bossLimit;
    private int bossAppeared = -1;
    public float speed;
    private int bossCount = 3;
    public GameObject[] bossArray;
    private GameObject bossI, bossII, bossIII;
    public GameObject bossPrefab;   //	GameObject to instantiate the bosses's ships		//	Height to draw the enemy's formation gizmo		//	Speed of the enemy's ships horizontal movement.
    public float spawnDelay;     //	How fast are the enemy's ships spawned
                                 //	Left boundary of our gamespace

    public void Update()
    {
        if (bossAppeared == 0)
        {
            Debug.Log("QESAD");
            // remember, 10 - 5 is 5, so target - position is always your direction.
            Vector3 dir = new Vector3(0, 4.3f, 0) - bossI.transform.position;

            // magnitude is the total length of a vector.
            // getting the magnitude of the direction gives us the amount left to move
            float dist = dir.magnitude;

            // this makes the length of dir 1 so that you can multiply by it.
            dir = dir.normalized;

            // the amount we can move this frame
            float move = speed * Time.deltaTime;

            // limit our move to what we can travel.
            if (move > dist) move = dist;

            // apply the movement to the object.
            bossI.transform.Translate(dir * move);
        }
        else
        if (bossAppeared == 1)
        {
            Debug.Log("QESADX2");
            Vector3 dir = new Vector3(10, 4.3f, 0) - bossII.transform.position;
            // magnitude is the total length of a vector.
            // getting the magnitude of the direction gives us the amount left to move
            float dist = dir.magnitude;

            // this makes the length of dir 1 so that you can multiply by it.
            dir = dir.normalized;

            // the amount we can move this frame
            float move = speed * Time.deltaTime;

            // limit our move to what we can travel.
            if (move > dist) move = dist;

            // apply the movement to the object.
            bossII.transform.Translate(dir * move);
        }
        else
        if (bossAppeared == 2)
        {
            Debug.Log("QESADX3");
            Vector3 dir = new Vector3(-10,4.3f,0) - bossIII.transform.position;
            // magnitude is the total length of a vector.
            // getting the magnitude of the direction gives us the amount left to move
            float dist = dir.magnitude;

            // this makes the length of dir 1 so that you can multiply by it.
            dir = dir.normalized;

            // the amount we can move this frame
            float move = speed * Time.deltaTime;

            // limit our move to what we can travel.
            if (move > dist) move = dist;

            // apply the movement to the object.
            bossIII.transform.Translate(dir * move);
        }
    }
    public IEnumerator SpawnUntilFull()
    {
        if (bossLimit==false)
        {
            for (int i=0; i<=bossCount;i++)
            {
                bossAppeared++;
                if (bossAppeared == 0) { bossI = Instantiate(bossPrefab, bossArray[i].transform.position, Quaternion.identity) as GameObject; }
                if (bossAppeared == 1) { bossII = Instantiate(bossPrefab, bossArray[i].transform.position, Quaternion.identity) as GameObject; }
                if (bossAppeared == 2) { bossIII = Instantiate(bossPrefab, bossArray[i].transform.position, Quaternion.identity) as GameObject; }
                yield return new WaitForSeconds(spawnDelay);
            }
            bossLimit = true;
        }
    }
}
