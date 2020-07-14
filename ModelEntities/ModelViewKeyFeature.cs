﻿using Entities;
using System;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewKeyFeature
    {
        public ModelViewKeyFeature()
        { }
        public ModelViewKeyFeature(KeyFeature keyFeat) : this()
        {            
            Id = keyFeat.Id;
            IdFeature = keyFeat.IdFeature;
            IdHaspKey = keyFeat.IdHaspKey;
            StartDate = keyFeat.StartDate;
            EndDate = keyFeat.EndDate;
        }
        public KeyFeature KeyFeature { get; private set; } = new KeyFeature();        
        public int Id
        {
            get { return KeyFeature.Id; }
            set { KeyFeature.Id = value; }
        }
        [Browsable(false)]
        public int IdHaspKey
        {
            get { return KeyFeature.IdHaspKey; }
            set { KeyFeature.IdHaspKey = value; }
        }
        [Browsable(false)]
        public int IdFeature
        {
            get { return KeyFeature.IdFeature; }
            set { KeyFeature.IdFeature = value; }
        }
        [DisplayName("Начало действия")]
        public DateTime StartDate
        {
            get { return KeyFeature.StartDate; }
            set { KeyFeature.StartDate = value; }
        }
        [DisplayName("Окончание действия")]
        public DateTime EndDate
        {
            get { return KeyFeature.EndDate; }
            set { KeyFeature.EndDate = value; }
        }

        public override bool Equals(object obj) => KeyFeature.Equals(obj);
        public override int GetHashCode() => KeyFeature.GetHashCode();
    }
}
