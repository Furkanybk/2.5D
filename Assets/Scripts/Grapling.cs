using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapling : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 GrapplePoint;
    public LayerMask GrappleableObject;
    public Transform GunTip, Camera, Player;
    private float maxDistance = 100f;
    private SpringJoint Joint;

    private void Awake()
    {
        lr = gameObject.GetComponent<LineRenderer>();  
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            StartGrapple();
        }
        else
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void DrawRope()
    {
        if (!Joint) return;

        lr.SetPosition(0, GunTip.position);
        lr.SetPosition(1, GrapplePoint);
    }

    void StartGrapple()
    { 
        RaycastHit hit;
        if (Physics.Raycast(Camera.position, Camera.forward, out hit, maxDistance, GrappleableObject))
        {
            GrapplePoint = hit.point;
            Joint = Player.gameObject.AddComponent<SpringJoint>();
            Joint.autoConfigureConnectedAnchor = false;
            Joint.connectedAnchor = GrapplePoint;

            float DistanceFromPoint = Vector3.Distance(Player.position, GrapplePoint);

            Joint.maxDistance = DistanceFromPoint * 0.8f;
            Joint.minDistance = DistanceFromPoint * 0.25f;

            Joint.spring = 4.5f;
            Joint.damper = 7f;
            Joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    } 
    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(Joint);
    }
} 
