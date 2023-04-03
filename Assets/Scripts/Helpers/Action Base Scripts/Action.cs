﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Climbing
{
    [CreateAssetMenu(menuName = "Climbing/Vaulting Action")]
    public class Action : ScriptableObject
    {
        public AnimationClip clip;

        public Vector3 kneeRaycastOrigin;
        public float kneeRaycastLength = 1.0f;
        public float landOffset = 0.7f;
        public float startDelay = 0.0f;
        public LayerMask layer;
        public string tag;
    }
}
