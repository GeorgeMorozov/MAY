﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace StoreCheck.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class DBEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new DBEntities object using the connection string found in the 'DBEntities' section of the application configuration file.
        /// </summary>
        public DBEntities() : base("name=DBEntities", "DBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DBEntities object.
        /// </summary>
        public DBEntities(string connectionString) : base(connectionString, "DBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DBEntities object.
        /// </summary>
        public DBEntities(EntityConnection connection) : base(connection, "DBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Spr_CAP> Spr_CAP
        {
            get
            {
                if ((_Spr_CAP == null))
                {
                    _Spr_CAP = base.CreateObjectSet<Spr_CAP>("Spr_CAP");
                }
                return _Spr_CAP;
            }
        }
        private ObjectSet<Spr_CAP> _Spr_CAP;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Spr_Rights> Spr_Rights
        {
            get
            {
                if ((_Spr_Rights == null))
                {
                    _Spr_Rights = base.CreateObjectSet<Spr_Rights>("Spr_Rights");
                }
                return _Spr_Rights;
            }
        }
        private ObjectSet<Spr_Rights> _Spr_Rights;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Spr_Roles> Spr_Roles
        {
            get
            {
                if ((_Spr_Roles == null))
                {
                    _Spr_Roles = base.CreateObjectSet<Spr_Roles>("Spr_Roles");
                }
                return _Spr_Roles;
            }
        }
        private ObjectSet<Spr_Roles> _Spr_Roles;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Spr_SR> Spr_SR
        {
            get
            {
                if ((_Spr_SR == null))
                {
                    _Spr_SR = base.CreateObjectSet<Spr_SR>("Spr_SR");
                }
                return _Spr_SR;
            }
        }
        private ObjectSet<Spr_SR> _Spr_SR;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Spr_CAP EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSpr_CAP(Spr_CAP spr_CAP)
        {
            base.AddObject("Spr_CAP", spr_CAP);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Spr_Rights EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSpr_Rights(Spr_Rights spr_Rights)
        {
            base.AddObject("Spr_Rights", spr_Rights);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Spr_Roles EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSpr_Roles(Spr_Roles spr_Roles)
        {
            base.AddObject("Spr_Roles", spr_Roles);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Spr_SR EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSpr_SR(Spr_SR spr_SR)
        {
            base.AddObject("Spr_SR", spr_SR);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DBModel", Name="Spr_CAP")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Spr_CAP : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Spr_CAP object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static Spr_CAP CreateSpr_CAP(global::System.Guid id)
        {
            Spr_CAP spr_CAP = new Spr_CAP();
            spr_CAP.ID = id;
            return spr_CAP;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SKUКМУ
        {
            get
            {
                return _SKUКМУ;
            }
            set
            {
                OnSKUКМУChanging(value);
                ReportPropertyChanging("SKUКМУ");
                _SKUКМУ = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SKUКМУ");
                OnSKUКМУChanged();
            }
        }
        private global::System.String _SKUКМУ;
        partial void OnSKUКМУChanging(global::System.String value);
        partial void OnSKUКМУChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SKUгруппировка
        {
            get
            {
                return _SKUгруппировка;
            }
            set
            {
                OnSKUгруппировкаChanging(value);
                ReportPropertyChanging("SKUгруппировка");
                _SKUгруппировка = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SKUгруппировка");
                OnSKUгруппировкаChanged();
            }
        }
        private global::System.String _SKUгруппировка;
        partial void OnSKUгруппировкаChanging(global::System.String value);
        partial void OnSKUгруппировкаChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Приоритетность
        {
            get
            {
                return _Приоритетность;
            }
            set
            {
                OnПриоритетностьChanging(value);
                ReportPropertyChanging("Приоритетность");
                _Приоритетность = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Приоритетность");
                OnПриоритетностьChanged();
            }
        }
        private Nullable<global::System.Int32> _Приоритетность;
        partial void OnПриоритетностьChanging(Nullable<global::System.Int32> value);
        partial void OnПриоритетностьChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ПриоритетностьСчет
        {
            get
            {
                return _ПриоритетностьСчет;
            }
            set
            {
                OnПриоритетностьСчетChanging(value);
                ReportPropertyChanging("ПриоритетностьСчет");
                _ПриоритетностьСчет = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ПриоритетностьСчет");
                OnПриоритетностьСчетChanged();
            }
        }
        private Nullable<global::System.Int32> _ПриоритетностьСчет;
        partial void OnПриоритетностьСчетChanging(Nullable<global::System.Int32> value);
        partial void OnПриоритетностьСчетChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String КодАссортимент
        {
            get
            {
                return _КодАссортимент;
            }
            set
            {
                OnКодАссортиментChanging(value);
                ReportPropertyChanging("КодАссортимент");
                _КодАссортимент = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("КодАссортимент");
                OnКодАссортиментChanged();
            }
        }
        private global::System.String _КодАссортимент;
        partial void OnКодАссортиментChanging(global::System.String value);
        partial void OnКодАссортиментChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Ассортимент
        {
            get
            {
                return _Ассортимент;
            }
            set
            {
                OnАссортиментChanging(value);
                ReportPropertyChanging("Ассортимент");
                _Ассортимент = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Ассортимент");
                OnАссортиментChanged();
            }
        }
        private global::System.String _Ассортимент;
        partial void OnАссортиментChanging(global::System.String value);
        partial void OnАссортиментChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String КатегорияТРТ
        {
            get
            {
                return _КатегорияТРТ;
            }
            set
            {
                OnКатегорияТРТChanging(value);
                ReportPropertyChanging("КатегорияТРТ");
                _КатегорияТРТ = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("КатегорияТРТ");
                OnКатегорияТРТChanged();
            }
        }
        private global::System.String _КатегорияТРТ;
        partial void OnКатегорияТРТChanging(global::System.String value);
        partial void OnКатегорияТРТChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Guid _ID;
        partial void OnIDChanging(global::System.Guid value);
        partial void OnIDChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DBModel", Name="Spr_Rights")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Spr_Rights : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Spr_Rights object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static Spr_Rights CreateSpr_Rights(global::System.Guid id)
        {
            Spr_Rights spr_Rights = new Spr_Rights();
            spr_Rights.ID = id;
            return spr_Rights;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Guid _ID;
        partial void OnIDChanging(global::System.Guid value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DBModel", Name="Spr_Roles")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Spr_Roles : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Spr_Roles object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static Spr_Roles CreateSpr_Roles(global::System.Guid id)
        {
            Spr_Roles spr_Roles = new Spr_Roles();
            spr_Roles.ID = id;
            return spr_Roles;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Guid _ID;
        partial void OnIDChanging(global::System.Guid value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DBModel", Name="Spr_SR")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Spr_SR : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Spr_SR object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static Spr_SR CreateSpr_SR(global::System.Guid id)
        {
            Spr_SR spr_SR = new Spr_SR();
            spr_SR.ID = id;
            return spr_SR;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SBU
        {
            get
            {
                return _SBU;
            }
            set
            {
                OnSBUChanging(value);
                ReportPropertyChanging("SBU");
                _SBU = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SBU");
                OnSBUChanged();
            }
        }
        private global::System.String _SBU;
        partial void OnSBUChanging(global::System.String value);
        partial void OnSBUChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Регион
        {
            get
            {
                return _Регион;
            }
            set
            {
                OnРегионChanging(value);
                ReportPropertyChanging("Регион");
                _Регион = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Регион");
                OnРегионChanged();
            }
        }
        private global::System.String _Регион;
        partial void OnРегионChanging(global::System.String value);
        partial void OnРегионChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Область
        {
            get
            {
                return _Область;
            }
            set
            {
                OnОбластьChanging(value);
                ReportPropertyChanging("Область");
                _Область = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Область");
                OnОбластьChanged();
            }
        }
        private global::System.String _Область;
        partial void OnОбластьChanging(global::System.String value);
        partial void OnОбластьChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Дистрибутор
        {
            get
            {
                return _Дистрибутор;
            }
            set
            {
                OnДистрибуторChanging(value);
                ReportPropertyChanging("Дистрибутор");
                _Дистрибутор = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Дистрибутор");
                OnДистрибуторChanged();
            }
        }
        private global::System.String _Дистрибутор;
        partial void OnДистрибуторChanging(global::System.String value);
        partial void OnДистрибуторChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String КодСупервайзер
        {
            get
            {
                return _КодСупервайзер;
            }
            set
            {
                OnКодСупервайзерChanging(value);
                ReportPropertyChanging("КодСупервайзер");
                _КодСупервайзер = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("КодСупервайзер");
                OnКодСупервайзерChanged();
            }
        }
        private global::System.String _КодСупервайзер;
        partial void OnКодСупервайзерChanging(global::System.String value);
        partial void OnКодСупервайзерChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Супервайзер
        {
            get
            {
                return _Супервайзер;
            }
            set
            {
                OnСупервайзерChanging(value);
                ReportPropertyChanging("Супервайзер");
                _Супервайзер = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Супервайзер");
                OnСупервайзерChanged();
            }
        }
        private global::System.String _Супервайзер;
        partial void OnСупервайзерChanging(global::System.String value);
        partial void OnСупервайзерChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String КодТА
        {
            get
            {
                return _КодТА;
            }
            set
            {
                OnКодТАChanging(value);
                ReportPropertyChanging("КодТА");
                _КодТА = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("КодТА");
                OnКодТАChanged();
            }
        }
        private global::System.String _КодТА;
        partial void OnКодТАChanging(global::System.String value);
        partial void OnКодТАChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ТА
        {
            get
            {
                return _ТА;
            }
            set
            {
                OnТАChanging(value);
                ReportPropertyChanging("ТА");
                _ТА = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ТА");
                OnТАChanged();
            }
        }
        private global::System.String _ТА;
        partial void OnТАChanging(global::System.String value);
        partial void OnТАChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ТипТА
        {
            get
            {
                return _ТипТА;
            }
            set
            {
                OnТипТАChanging(value);
                ReportPropertyChanging("ТипТА");
                _ТипТА = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ТипТА");
                OnТипТАChanged();
            }
        }
        private global::System.String _ТипТА;
        partial void OnТипТАChanging(global::System.String value);
        partial void OnТипТАChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String МаршрутТА
        {
            get
            {
                return _МаршрутТА;
            }
            set
            {
                OnМаршрутТАChanging(value);
                ReportPropertyChanging("МаршрутТА");
                _МаршрутТА = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("МаршрутТА");
                OnМаршрутТАChanged();
            }
        }
        private global::System.String _МаршрутТА;
        partial void OnМаршрутТАChanging(global::System.String value);
        partial void OnМаршрутТАChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Guid _ID;
        partial void OnIDChanging(global::System.Guid value);
        partial void OnIDChanged();

        #endregion
    
    }

    #endregion
    
}
