﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Cinemachine.Utility;

namespace Climbing
{
    public class SwitchCameras : MonoBehaviour
    {
        // Start is called before the first frame update
        Animator animator;

        enum CameraType
        {
            None,
            Freelook,
            Slide
        }

        CameraType curCam = CameraType.None;

        [SerializeField] private CinemachineFreeLook FreeLook;
        [SerializeField] private CinemachineVirtualCamera Slide;


        void Start()
        {
            animator = GetComponent<Animator>();

            FreeLookCam();
        }

        //Switches To FreeLook Cam
        public void FreeLookCam()
        {
            if (curCam != CameraType.Freelook)
            {
                Slide.Priority = 0;
                FreeLook.Priority = 1;
            }
        }

        //Switches To Slide Cam
        public void SlideCam()
        {
            if (curCam != CameraType.Slide)
            {
                FreeLook.Priority = 0;
                Slide.Priority = 1;
            }
        }
    }
}
