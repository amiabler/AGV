﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AGVCenterWPF.Config;
using AGVCenterWPF.Properties;

namespace AGVCenterWPF
{
   public class OPCConfig
    {
        #region 基本设置
        /// <summary>
        /// 数据库连接
        /// </summary>
        public static string DbString = Settings.Default.dbString;
        /// <summary>
        /// OPC 服务器列表
        /// </summary>
        public static List<string> OPCServers = new List<string>() { "OPC.SimaticNET.DP.1", "OPC.SimaticNET.1", "OPC.SimaticNET.PD.1" };

        /// <summary>
        /// OPC 服务
        /// </summary>
        public static string OPCServerName = Settings.Default.OPCServerName;//"OPC.SimaticNET.1";

        public static string OPCNodeName = Settings.Default.OPCNodeName; //"192.168.1.105";

        #region OPC组
        /// <summary>
        /// OPCCheckInStockBarcodeOPCGroup , 扫码入库
        /// </summary>
        public static string OPCCheckInStockBarcodeOPCGroupName = "OPCCheckInStockBarcodeOPCGroup";
        public static int OPCCheckInStockBarcodeOPCGroupRate = 100;
        public static int OPCCheckInStockBarcodeOPCGroupDeadBand = 0;

        /// <summary>
        /// OPCAgvInStockPassOPCGroup ，AGV 放行
        /// </summary>
        public static string OPCAgvInStockPassOPCGroupName = "OPCAgvInStockPassOPCGroup";
        public static int OPCAgvInStockPassOPCGroupRate = 100;
        public static int OPCAgvInStockPassOPCGroupDeadBand = 0;
        public static int SetOPCAgvInStockPassTimerInterval = 300;

        /// <summary>
        /// OPCInRobootPickOPCGroup ，入库机械手抓取
        /// </summary>
        public static string OPCInRobootPickOPCGroupName = "OPCInRobootPickOPCGroup";
        public static int OPCInRobootPickOPCGroupRate = 100;
        public static int OPCInRobootPickOPCGroupDeadBand = 0;
        public static int SetOPCInRobootPickTimerInterval = 300;


        /// <summary>
        /// OPCSetStockTaskRM1OPCGroup，库存操作任务 巷道机1
        /// </summary>
        public static string OPCSetStockTaskRM1OPCGroupName = "OPCSetStockTaskRM1OPCGroup";
        public static int OPCSetStockTaskRM1OPCGroupRate = 100;
        public static int OPCSetStockTaskRM1OPCGroupDeadBand = 0;

        /// <summary>
        /// OPCSetStockTaskRM2OPCGroup，库存操作任务 巷道机2
        /// </summary>
        public static string OPCSetStockTaskRM2OPCGroupName = "OPCSetStockTaskRM2OPCGroup";
        public static int OPCSetStockTaskRM2OPCGroupRate = 100;
        public static int OPCSetStockTaskRM2OPCGroupDeadBand = 0;

        /// <summary>
        /// 库存操作任务定时器Interval
        /// </summary>
        public static int SetOPCStockTaskTimerInterval = 300;

        /// <summary>
        /// OPCTaskFeedRM1OPCGroup，库存操作反馈 巷道机1
        /// </summary>
        public static string OPCTaskFeedRM1OPCGroupName = "OPCTaskFeedRM1OPCGroup";
        public static int OPCTaskFeedRM1OPCGroupRate = 100;
        public static int OPCTaskFeedRM1OPCGroupDeadBand = 0;

        /// <summary>
        /// OPCTaskFeedRM2OPCGroup，库存操作反馈 巷道机2
        /// </summary>
        public static string OPCTaskFeedRM2OPCGroupName = "OPCTaskFeedRM2OPCGroup";
        public static int OPCTaskFeedRM2OPCGroupRate = 100;
        public static int OPCTaskFeedRM2OPCGroupDeadBand = 0;

        /// <summary>
        /// OPCOutRobootPickOPCGroup, 出库机械手任务，反馈大小箱、托盘个数
        /// </summary>
        public static string OPCOutRobootPickOPCGroupName = "OPCOutRobootPickOPCGroup";
        public static int OPCOutRobootPickOPCGroupRate = 100;
        public static int OPCOutRobootPickOPCGroupDeadBand = 0;
        public static int DispatchTrayOutStockTaskTimerInterval = 300;
        #endregion


        /// <summary>
        /// 加载数据库出库任务定时器Interval
        /// </summary>
        public static int LoadOutStockTaskFromDbTimerInterval = 1000;

        #endregion


        //#region 测试配置
        ///// <summary>
        ///// 出库任务完成是否删除库存，如果删除就无法重新出库，必须重新入库，即，生成库存
        ///// 不删除的话，出库任务只要重新都置为等待出库状态(7),就可以重新出库了
        ///// </summary>
        //public static bool TEST_OutStockTaskDelStorage = Settings.Default.TEST_OUTSTOCK_NOT_DEL_STOTAGE;
        //#endregion


        /// <summary>
        /// OPCDataResetOPCGroup , 设置OPC值
        /// </summary>
        public static string OPCDataResetOPCGroupName = "OPCDataResetOPCGroup";
        public static int OPCDataResetOPCGroupRate = 100;
        public static int OPCDataResetOPCGroupDeadBand = 0;

    }
}
