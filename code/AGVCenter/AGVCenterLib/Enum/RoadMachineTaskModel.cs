﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AGVCenterLib.Enum
{
    public enum RoadMachineTaskModel
    {
        /// <summary>
        /// 出库优先，默认
        /// </summary>
        [Description("出库优先")]
        OutHigherThanIn =100,


        /// <summary>
        /// 入库优先
        /// </summary>
        [Description("入库优先")]
        InHigherThanOut =200,


        /// <summary>
        /// 只出库
        /// </summary>
        [Description("只出库")]
        OnlyOut =300,


        /// <summary>
        /// 只入库
        /// </summary>
        [Description("只入库")]
        OnlyIn = 400
    }
}