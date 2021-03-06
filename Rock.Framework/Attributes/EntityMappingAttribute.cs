﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rock.Framework.Attributes
{
    /// <summary>
    /// 实体类映射特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true)]
    public class EntityMappingAttribute : Attribute
    {
        public string TableName { get; set; }

        public string ColumnName { get; set; }
    }
}
