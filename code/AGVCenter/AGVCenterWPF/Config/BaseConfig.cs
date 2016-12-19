﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.Framwork.Utils.ConfigUtil;
using Brilliantech.Framwork.Utils.LogUtil;

namespace AGVCenterWPF.Config
{
 public   class BaseConfig
    {
        private static ConfigUtil config;
        private static bool autoConnectOPC = true;
    //    private static string connectString = string.Empty;
        private static bool roadMachine1Enabled = true;
        private static bool roadMachine2Enabled = true;
        private static int maxMonitorTaskNum = 300;
        private static int keepMonitorTaskNum = 200;
        static BaseConfig()
        {
            try
            {
                config = new ConfigUtil("BASE", "Config/base.ini");
                autoConnectOPC = bool.Parse(config.Get("autoConnectOPC"));
            //    connectString = config.Get("connectString");

                roadMachine1Enabled = bool.Parse(config.Get("roadMachine1Enabled"));
                roadMachine2Enabled = bool.Parse(config.Get("roadMachine2Enabled"));
                maxMonitorTaskNum = int.Parse(config.Get("maxMonitorTaskNum"));
                keepMonitorTaskNum = int.Parse(config.Get("keepMonitorTaskNum"));

            }
            catch (Exception ex)
            {
                LogUtil.Logger.Error(ex.Message, ex);
            }
        }

        public static bool AutoConnectOPC
        {
            get
            {
                return autoConnectOPC;
            }

            set
            {
                autoConnectOPC = value;
                config.Set("autoConnectOPC", value);
                config.Save();
            }
        }
         

        public static bool RoadMachine1Enabled
        {
            get
            {
                return roadMachine1Enabled;
            }

            set
            {
                roadMachine1Enabled = value;
                config.Set("roadMachine1Enabled", value);
                config.Save();
            }
        }

        public static bool RoadMachine2Enabled
        {
            get
            {
                return roadMachine2Enabled;
            }

            set
            {
                roadMachine2Enabled = value;
                config.Set("roadMachine2Enabled", value);
                config.Save();
            }
        }

        public static int MaxMonitorTaskNum
        {
            get
            {
                return maxMonitorTaskNum;
            }
            set
            {
                maxMonitorTaskNum = value;
                config.Set("maxMonitorTaskNum", value);
                config.Save();
            }
        }

        public static int KeepMonitorTaskNum
        {
            get
            {
                return keepMonitorTaskNum;
            }
            set
            {
                keepMonitorTaskNum = value;
                config.Set("keepMonitorTaskNum", value);
                config.Save();

            }
        }
    }
}