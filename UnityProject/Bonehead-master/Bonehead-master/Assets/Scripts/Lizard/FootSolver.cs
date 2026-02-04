using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSystem : MonoBehaviour

{

    public LayerMask ground;

    public FootSystem otherFoot;

    public float stepDist, stepHeight, stepLength, footSpacing, speed;

    public Transform body;

    public Vector3 footOffset;



    Vector3 oldPos, newPos, currPos;

    Vector3 oldNormal, currNormal, newNormal;

    float lerp;



    private void Start()

    {

        footSpacing = transform.localPosition.x;

        oldPos = newPos = currPos = transform.position;

        oldNormal = newNormal = currNormal = transform.up;

        lerp = 1;

    }

    private void Update()

    {

        transform.position = currPos;

        transform.up = currNormal;

        Ray ray =  new Ray(body.position + (body.right * footSpacing), Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 10, ground))

        {

            if (Vector3.Distance(newPos, hit.point) > stepDist && !otherFoot.isMoving() && lerp >= 1)

            {

                lerp = 0;

                int direction = body.InverseTransformPoint(hit.point).z > body.InverseTransformPoint(newPos).z ? 1 : -1;

                newPos = hit.point + body.forward * stepLength * direction + footOffset;

                newNormal = hit.normal;

            }

        }

        if (lerp < 1)

        {

            Vector3 tempPos = Vector3.Lerp(oldPos, newPos, lerp);

            tempPos.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

            currPos = tempPos;

            currNormal = Vector3.Lerp(oldNormal, newNormal, lerp);

            lerp += Time.deltaTime * speed;

        }

        else

        {

            oldPos = newPos;

            oldNormal = newNormal;

        }

        

    }

    public bool isMoving()

    {

        return lerp < 1;

    }

}
