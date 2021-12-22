using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelslipValue : MonoBehaviour
{
    WheelCollider WheelC;
    public float RoadForwardStiffness = 3f;
    public float TerrainForwardStiffness = 0.6f;
    public float RoadSidewaysStiffness = 1.1f;
    public float TerrainSidewaysStiffness;
    public float SlidingForwardStiffness = 0.5f;
    public float SlidingSidewaysStiffness = 1.5f;
    private bool SlideChange = false;
    private bool Changed = false;

    // Start is called before the first frame update
    void Start()
    {
        WheelC = GetComponent<WheelCollider>();
        SaveScript.BrakeSlide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.BrakeSlide == false)
        {
            if (SaveScript.OnTheRoad == true)
            {
                if (Changed == false)
                {
                    Changed = true;
                    WheelFrictionCurve fFriction = WheelC.forwardFriction;
                    fFriction.stiffness = RoadForwardStiffness;
                    WheelC.forwardFriction = fFriction;

                    WheelFrictionCurve sFriction = WheelC.sidewaysFriction;
                    sFriction.stiffness = RoadSidewaysStiffness;
                    WheelC.sidewaysFriction = sFriction;
                }

            }

            if (SaveScript.OnTheTerrain == true)
            {
                if (Changed == true)
                {
                    Changed = false;
                    WheelFrictionCurve fFriction = WheelC.forwardFriction;
                    fFriction.stiffness = TerrainForwardStiffness;
                    WheelC.forwardFriction = fFriction;

                    WheelFrictionCurve sFriction = WheelC.sidewaysFriction;
                    sFriction.stiffness = TerrainSidewaysStiffness;
                    WheelC.sidewaysFriction = sFriction;
                }

            }
        }

        if(SaveScript.BrakeSlide == true)
        {
            if(SlideChange == true)
            {
                SlideChange = false;
                WheelFrictionCurve fFriction = WheelC.forwardFriction;
                fFriction.stiffness = SlidingForwardStiffness;
                WheelC.forwardFriction = fFriction;

                WheelFrictionCurve sFriction = WheelC.sidewaysFriction;
                sFriction.stiffness = SlidingSidewaysStiffness;
                WheelC.sidewaysFriction = sFriction;
            }
            if(SlideChange == false)
            {
                SlideChange = true;
                WheelFrictionCurve fFriction = WheelC.forwardFriction;
                fFriction.stiffness = RoadForwardStiffness;
                WheelC.forwardFriction = fFriction;

                WheelFrictionCurve sFriction = WheelC.sidewaysFriction;
                sFriction.stiffness = RoadSidewaysStiffness;
                WheelC.sidewaysFriction = sFriction;
            }
        }
    }
}
