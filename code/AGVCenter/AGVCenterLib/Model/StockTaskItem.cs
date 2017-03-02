﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using AGVCenterLib.Data;
using AGVCenterLib.Enum;
using Brilliantech.Framwork.Utils.EnumUtil;

namespace AGVCenterLib.Model
{
    [DataContract]
    public abstract class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 

        protected Action<string> OnPropertyChanged;
        SynchronizationContext context;
        public NotifyBase(SynchronizationContext _context)
        {
            context = _context;
            OnPropertyChanged = propertyName =>
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    context.Post(t => handler(this, new PropertyChangedEventArgs((string)t)), propertyName);
                }
            };
        }


        public NotifyBase()
        {
            this.OnPropertyChanged = propertyName =>
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            };
        }
    

    }

    public class StockTaskItem:NotifyBase //: INotifyPropertyChanged
    {
        public static List<StockTaskState> InPickRobotGetDbStates = new List<StockTaskState>() {
            StockTaskState.AgvInStcoking
        };
        public static List<StockTaskState> RoadMachineTaskGetDbStates = new List<StockTaskState>()
        {
            StockTaskState.RoadMachineStockBuffing,
            StockTaskState.RoadMachineOutStockInit
        };
        public static List<StockTaskState> ShouldDequeueStockTaskStates = new List<StockTaskState>() {
            StockTaskState.Canceled,
            StockTaskState.ManInStocked,
            StockTaskState.ManOutStocked
        };

        public static List<StockTaskState> CanCancelStates = StockTask.CanCancelStates;


        public static List<StockTaskState> ShouldLoadFromDbStates = new List<StockTaskState>()
        {
            StockTaskState.AgvInStcoking,
            StockTaskState.RoadMachineStockBuffing,
            StockTaskState.RoadMachineWaitOutStock
        };

        public StockTaskItem(SynchronizationContext _context):base(_context)
        {
            this.State = StockTaskState.Init;
            this.IsInProcessing = false;
            this.CreatedAt = DateTime.Now;
        }

        public StockTaskItem():base()
        {
            this.State = StockTaskState.Init;
            this.IsInProcessing = false;
            this.CreatedAt = DateTime.Now;
        }
        #region 状态改变事件
        /// <summary>
        /// 状态改变事件委托
        /// </summary>
        /// <param name="sensor"></param>
        /// <param name="toFlag"></param>
        public delegate void TaskStateChangeEventHandler(StockTaskItem taskItem, StockTaskState toState);
        /// <summary>
        /// 状态改变事件
        /// </summary>
        public event TaskStateChangeEventHandler TaskStateChangeEvent;

        #endregion

        /// <summary>
        /// 任务类型
        /// </summary>
        private StockTaskType stockTaskType;
        public StockTaskType StockTaskType
        {
            get
            {
                return this.stockTaskType;
            }
            set
            {
                this.stockTaskType = value;
                OnPropertyChanged("StockTaskType");
                OnPropertyChanged("StockTaskTypeStr");
                //  OnPropertyChanged(new PropertyChangedEventArgs("StockTaskType"));
                // OnPropertyChanged(new PropertyChangedEventArgs("StockTaskTypeStr"));
            }
        }

        public string StockTaskTypeStr
        {
            get
            {
                return EnumUtil.GetDescription((StockTaskType)this.StockTaskType);
            }
        }

        /// <summary>
        /// 巷道机序号，从1开始，目前使用1号或2号巷道机，
        /// 和库存中的库位AreaIndex对应，相当于1或2的分区
        /// </summary>
        private int roadMachineIndex;
        public int RoadMachineIndex
        {
            get { return this.roadMachineIndex; }
            set
            {
                this.roadMachineIndex = value;
                // OnPropertyChanged(new PropertyChangedEventArgs("RoadMachineIndex"));
                OnPropertyChanged( "RoadMachineIndex");

            }
        }

        /// <summary>
        /// 库位编号
        /// </summary>
        private string positionNr;
        public string PositionNr
        {
            get { return this.positionNr; }
            set
            {
                this.positionNr = value;
             //   OnPropertyChanged(new PropertyChangedEventArgs("PositionNr"));
                OnPropertyChanged("PositionNr");
            }
        }

        /// <summary>
        /// 库位，层，2
        /// </summary>
        private int positionFloor;
        public int PositionFloor
        {
            get { return this.positionFloor; }
            set
            {
                this.positionFloor = value;
               // OnPropertyChanged(new PropertyChangedEventArgs("PositionFloor"));
                OnPropertyChanged("PositionFloor");
            }
        }

        /// <summary>
        /// 库位，列，3
        /// </summary>
        private int positionColumn;
        public int PositionColumn
        {
            get
            {
                return this.positionColumn;
            }
            set
            {
                this.positionColumn = value;
             //   OnPropertyChanged(new PropertyChangedEventArgs("PositionColumn"));
                OnPropertyChanged("PositionColumn");
            }
        }

        /// <summary>
        /// 库位，排，4
        /// </summary>
        private int positionRow;
        public int PositionRow
        {
            get { return this.positionRow; }
            set
            {
                this.positionRow = value;
               // OnPropertyChanged(new PropertyChangedEventArgs("PositionRow"));
                OnPropertyChanged("PositionRow");
            }
        }

        /// <summary>
        /// 箱型，5
        /// </summary>
        private byte boxType;
        public byte BoxType
        {
            get { return this.boxType; }
            set
            {
                this.boxType = value;
              //  OnPropertyChanged(new PropertyChangedEventArgs("BoxType"));
                OnPropertyChanged("BoxType");
            }
        }

        /// <summary>
        /// AGV 放行标记，6
        /// </summary>
        private byte agvPassFlag;
        public byte AgvPassFlag
        {
            get { return this.agvPassFlag; }
            set
            {
                this.agvPassFlag = value;
              //  OnPropertyChanged(new PropertyChangedEventArgs("AgvPassFlag"));
                OnPropertyChanged("AgvPassFlag");
            }
        }

        /// <summary>
        /// 重置库位标记，7
        /// </summary>
        private byte restPositionFlag;
        public byte RestPositionFlag
        {
            get
            {
                return this.restPositionFlag;
            }
            set
            {
                this.restPositionFlag = value;
             //   OnPropertyChanged(new PropertyChangedEventArgs("RestPositionFlag"));
                OnPropertyChanged("RestPositionFlag");
            }
        }


        /// <summary>
        /// 托的剩余第几箱，从n...1
        /// </summary>
        private int trayReverseNo;
        public int TrayReverseNo
        {
            get
            {
                return this.trayReverseNo;
            }
            set
            {
                this.trayReverseNo = value;
             //   OnPropertyChanged(new PropertyChangedEventArgs("TrayReverseNo"));
                OnPropertyChanged("TrayReverseNo");
            }
        }

        /// <summary>
        /// 运单中托的个数
        /// </summary>
        private int trayNum;
        public int TrayNum
        {
            get { return this.trayNum; }
            set
            {
                this.trayNum = value;
             //   OnPropertyChanged(new PropertyChangedEventArgs("TrayNum"));
                OnPropertyChanged("TrayNum");
            }
        }

        /// <summary>
        /// 运单项的个数
        /// </summary>
        private int deliveryItemNum;
        public int PickItemNum
        {
            get { return this.deliveryItemNum; }
            set
            {
                this.deliveryItemNum = value;
              //  OnPropertyChanged(new PropertyChangedEventArgs("DeliveryItemNum"));
                OnPropertyChanged("DeliveryItemNum");
            }
        }

        /// <summary>
        /// 条码
        /// </summary>
        private string barCode;
        public string Barcode
        {
            get { return this.barCode; }
            set
            {
                this.barCode = value;
               // OnPropertyChanged(new PropertyChangedEventArgs("Barcode"));
                OnPropertyChanged("Barcode");
            }
        }

        /// <summary>
        /// 状态，不写入OPC
        /// </summary>
        private StockTaskState stateWas;
        public StockTaskState StateWas
        {
            get { return stateWas; }
            private set
            {
                stateWas = value;
              //  OnPropertyChanged(new PropertyChangedEventArgs("StateWas"));
                OnPropertyChanged("StateWas");
            }
        }
        private StockTaskState state;
        public StockTaskState State
        {
            get { return state; }
            set
            {
                stateWas = state;
                state = value;
               // OnPropertyChanged(new PropertyChangedEventArgs("State"));
                OnPropertyChanged("State");
              //  OnPropertyChanged(new PropertyChangedEventArgs("StateStr"));
                OnPropertyChanged("StateStr");
                if (stateWas != state)
                {
                    if (this.TaskStateChangeEvent != null)
                    {
                        this.TaskStateChangeEvent(this, value);
                    }
                }

            }
        }
        public string StateStr
        {
            get
            {
                return EnumUtil.GetDescription((StockTaskState)this.State);
            }
        }



        private bool isInProcessing;
        public bool IsInProcessing
        {
            get { return this.isInProcessing; }
            set
            {
                this.isInProcessing = value;
              //  OnPropertyChanged(new PropertyChangedEventArgs("IsInProcessing"));
                OnPropertyChanged("IsInProcessing");
            }
        }


        /// <summary>
        /// 目标库位编号
        /// </summary>
        private string toPositionNr;
        public string ToPositionNr
        {
            get { return this.toPositionNr; }
            set
            {
                this.toPositionNr = value;
                OnPropertyChanged("ToPositionNr");
            }
        }

        private int toPositionFloor = 0;
        /// <summary>
        /// 目标库位，层，12，移库中是目标库位
        /// </summary>
        public int ToPositionFloor { get {
                return this.toPositionFloor;
            } set {
                this.toPositionFloor = value;
                OnPropertyChanged("ToPositionFloor");
            }
        }

        private int toPositionColumn = 0;
        /// <summary>
        /// 库位，列，13，移库中是目标库位
        /// </summary>
        public int ToPositionColumn { get { return this.toPositionColumn; } set {
                this.toPositionColumn = value;
                OnPropertyChanged("ToPositionColumn");
            } }

        private int toPositionRow = 0;
        /// <summary>
        /// 库位，排，14，移库中是目标库位
        /// </summary>
        public int ToPositionRow
        {
            get
            {
                return this.toPositionRow;
            }
            set
            {
                this.toPositionRow = value;
                OnPropertyChanged("ToPositionRow");
            }
        }



        public bool IsInBuffingState
        {
            get
            {
                return this.State == StockTaskState.RoadMachineStockBuffing
                    || this.State == StockTaskState.RoadMachineWaitOutStock
                    || this.State== StockTaskState.RoadMachineMoveStockInit;
            }
        }


        public bool IsCanCancel
        {
            get
            {
                return CanCancelStates.Contains(this.State);
            }
        }

        public bool IsCanceled
        {
            get
            {
                return this.State == StockTaskState.Canceled;
            }
        }

        public bool ShouldDequeueStockTask {
            get
            {
                return ShouldDequeueStockTaskStates.Contains(this.state);
            }
        }




        /// <summary>
        /// DB id
        /// </summary>
        private int dbId;
        public int DbId
        {
            get { return this.dbId; }
            set
            {
                this.dbId = value;
           //     OnPropertyChanged(new PropertyChangedEventArgs("DbId"));
                OnPropertyChanged("DbId");
            }
        }

        private DateTime createdAt;
        public DateTime CreatedAt
        {
            get { return this.createdAt; }
            set
            {
                this.createdAt = value;
                //  OnPropertyChanged(new PropertyChangedEventArgs("CreatedAt"));
                //  OnPropertyChanged(new PropertyChangedEventArgs("CreatedAtStr"));
                OnPropertyChanged("CreatedAt");
                OnPropertyChanged("CreatedAtStr");
            }
        }

        public string CreatedAtStr
        {
            get
            {
                return this.createdAt.ToString("yy-MM-dd HH:mm:sss");
            }
        }

        public string ToDisplay()
        {
            return string.Format("【任务类型：{0}-巷道机-**{10}**】\r\n条码：{1},库位：{2}-{3}-{4},箱型：{5},AGV放行标记:{6},Rest标记{7},状态：{8},DbId:{9}\r\n",
                this.StockTaskType,
                this.Barcode,
                this.PositionFloor, this.PositionColumn, this.PositionRow,
                this.BoxType,
                this.AgvPassFlag,
                this.RestPositionFlag,
                this.State,
                this.DbId,
                this.RoadMachineIndex);
        }
    }
}
