// <copyright file="JSonSerializeAttribute.cs" company="Growth Acceleration Partners, LLC">
//       Copyright © 2024 Growth Acceleration Partners, LLC. All Rights Reserved,
//       All classes are provided for customer use only,
//       all other use is prohibited without prior written consent from Growth Acceleration Partners, LLC,
//       no warranty express or implied,
//       use at own risk.
// </copyright>

using System;

namespace UpgradeHelpers.DB
{

    [AttributeUsage(AttributeTargets.Property| AttributeTargets.Field, AllowMultiple = false)]
    public class JSonSerializeAttribute : Attribute
    {        
    }
}