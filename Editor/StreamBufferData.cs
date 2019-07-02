﻿using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

namespace Unity.Labs.FacialRemote
{
    [StructLayout(LayoutKind.Explicit)]
    public struct StreamBufferData
    {
        [FieldOffset(0)] public byte ErrorCheck;
        [FieldOffset(1)] public BlendShapeValues blendshapeValues;
        [FieldOffset(209)] public Pose HeadPose;
        [FieldOffset(237)] public Pose CameraPose;
        [FieldOffset(265)] public int FrameNumber;
        [FieldOffset(269)] public float FrameTime;
        [FieldOffset(273)] public int InputState;
        [FieldOffset(277)] public byte FaceTrackingActiveState;
        [FieldOffset(278)] public byte CameraTrackingActiveState;

        public static StreamBufferData Create(byte[] bytes)
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (StreamBufferData)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(StreamBufferData));
            }
            finally
            {
                handle.Free();
            }
        }
    }
}
