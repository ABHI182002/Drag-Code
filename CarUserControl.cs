using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to 

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            if (SaveScript.RaceStart == true)
            {
                // pass the input to the car!
                if (SaveScript.RaceStart == true)
                {
                    float h = CrossPlatformInputManager.GetAxis("Horizontal");
                    float v = CrossPlatformInputManager.GetAxis("Vertical");


                    if (SaveScript.Joypad == true)
                    {
                        if (CrossPlatformInputManager.GetButton("Fire1"))
                        {
                            v = 2.0f;
                        }
                        if (CrossPlatformInputManager.GetButton("Fire2"))
                        {
                            v = -0.5f;
                        }
                        if (!CrossPlatformInputManager.GetButton("Fire2") && !CrossPlatformInputManager.GetButton("Fire1"))
                        {
                            v = 0;
                        }
                    }

                    if ( v < 0 && h != 0)
                    {
                        SaveScript.BrakeSlide = true;
                    }
                    if(v >= 0)
                    {
                        SaveScript.BrakeSlide = false;
                        SaveScript.IsReversing = false;
                    }

                    if(v < 0 && SaveScript.Speed > 0 && SaveScript.Speed < 1)
                    {
                        Debug.Log("Reversing");
                        SaveScript.IsReversing = true;
                    }

#if !MOBILE_INPUT
                    float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                    m_Car.Move(h, v, v, handbrake);
#else
                
            m_Car.Move(h, v, v, 0f);
#endif
                }
            }
        }
        
    }
}
