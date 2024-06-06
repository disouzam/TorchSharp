// Copyright (c) .NET Foundation and Contributors.  All Rights Reserved.  See LICENSE in the project root for license information.
using System;
using static TorchSharp.torch;
using static TorchSharp.PInvoke.NativeMethods;

namespace TorchSharp
{
    using Modules;

    namespace Modules
    {
        /// <summary>
        /// This class is used to represent a Softmax2d module.
        /// </summary>
        public sealed class Softmax2d : ParamLessModule<Tensor, Tensor>
        {
            internal Softmax2d() : base(nameof(Softmax2d)) { }

            public override Tensor forward(Tensor tensor)
            {
                return torch.nn.functional.softmax2d(tensor);
            }

           // Rather than spending cycles only to discover that this module has neither
            // parameters nor buffers, just shortcut the move completely.
            protected internal override nn.Module _to(Device device, ScalarType dtype, bool non_blocking) => this;
            protected internal override nn.Module _to(DeviceType deviceType, int deviceIndex, bool non_blocking) => this;
            protected internal override nn.Module _to(ScalarType dtype, bool non_blocking) => this;
        }
    }
    public static partial class torch
    {
        public static partial class nn
        {
            /// <summary>
            /// Applies Softmax over features to each spatial location
            /// </summary>
            /// <returns></returns>
            public static Softmax2d Softmax2d()
            {
                return new Softmax2d();
            }

            public static partial class functional
            {
                /// <summary>
                /// Applies Softmax over features to each spatial location
                /// </summary>
                /// <param name="x">The input tensor</param>
                /// <returns></returns>
                public static Tensor softmax2d(Tensor x)
                {
                    return torch.nn.functional.softmax(x, -3);
                }
            }
        }
    }
}
