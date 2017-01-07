﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using AGVCenterLib.Data;

namespace AGVCenterLib.Model.ViewModel
{

    [DataContract]
    public class PickListModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        private string nr;
        [DataMember]
        public string Nr
        {
            get { return this.nr; }
            set
            {
                this.nr = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Nr"));
            }
        }

        [DataMember]
        public int? State { get; set; }

        [DataMember]
        public string StateStr { get; set; }

        [DataMember]
        public DateTime? CreatedAt { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }

       
        public static List<PickListModel> Converts(List<PickList> items)
        {
            List<PickListModel> itemModels = new List<PickListModel>();
            foreach (var i in items)
            {
                itemModels.Add(Convert(i));
            }
            return itemModels;
        }

        public static PickListModel Convert(PickList item)
        {
            if (item == null) return null;
            PickListModel itemModel = new PickListModel();
            var ps = item.GetType().GetProperties();
            Type t = itemModel.GetType();
            foreach (var p in ps)
            {

                bool hasP = t.GetProperty(p.Name) != null;
                if (hasP)
                {
                    if (t.GetProperty(p.Name).CanWrite)
                    {
                        t.GetProperty(p.Name).SetValue(itemModel,
                            item.GetType().GetProperty(p.Name).GetValue(item, null),
                            null);
                    }
                }
            }
            return itemModel;
        }

    }
}