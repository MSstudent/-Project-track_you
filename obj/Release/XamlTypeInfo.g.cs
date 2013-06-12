﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace kter_myelement
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
        private global::kter_myelement.track_you_XamlTypeInfo.XamlTypeInfoProvider _provider;

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::kter_myelement.track_you_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.String fullName)
        {
            if(_provider == null)
            {
                _provider = new global::kter_myelement.track_you_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace kter_myelement.track_you_XamlTypeInfo
{
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            string standardName;
            global::Windows.UI.Xaml.Markup.IXamlType xamlType = null;
            if(_xamlTypeToStandardName.TryGetValue(type, out standardName))
            {
                xamlType = GetXamlTypeByName(standardName);
            }
            else
            {
                xamlType = GetXamlTypeByName(type.FullName);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (global::System.String.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypes.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            xamlType = CreateXamlType(typeName);
            if (xamlType != null)
            {
                _xamlTypes.Add(typeName, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (global::System.String.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType> _xamlTypes = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();
        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember> _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();
        global::System.Collections.Generic.Dictionary<global::System.Type, string> _xamlTypeToStandardName = new global::System.Collections.Generic.Dictionary<global::System.Type, string>();

        private void AddToMapOfTypeToStandardName(global::System.Type t, global::System.String str)
        {
            if(!_xamlTypeToStandardName.ContainsKey(t))
            {
                _xamlTypeToStandardName.Add(t, str);
            }
        }

        private object Activate_0_QuickStartTask() { return new global::kter_myelement.QuickStartTask(); }

        private object Activate_1_AMap() { return new global::Com.AMap.Maps.Api.AMap(); }

        private object Activate_6_MainPage() { return new global::kter_myelement.MainPage(); }


        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(string typeName)
        {
            global::kter_myelement.track_you_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::kter_myelement.track_you_XamlTypeInfo.XamlUserType userType;

            switch (typeName)
            {
            case "Windows.UI.Xaml.Controls.UserControl":
                xamlType = new global::kter_myelement.track_you_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::Windows.UI.Xaml.Controls.UserControl));
                break;

            case "Int32":
                xamlType = new global::kter_myelement.track_you_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::System.Int32));
                break;

            case "String":
                xamlType = new global::kter_myelement.track_you_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::System.String));
                break;

            case "Windows.UI.Xaml.Controls.Canvas":
                xamlType = new global::kter_myelement.track_you_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::Windows.UI.Xaml.Controls.Canvas));
                break;

            case "Windows.UI.Xaml.Controls.UIElementCollection":
                xamlType = new global::kter_myelement.track_you_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::Windows.UI.Xaml.Controls.UIElementCollection));
                break;

            case "Windows.Foundation.Size":
                xamlType = new global::kter_myelement.track_you_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::Windows.Foundation.Size));
                break;

            case "Boolean":
                xamlType = new global::kter_myelement.track_you_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::System.Boolean));
                break;

            case "Object":
                xamlType = new global::kter_myelement.track_you_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::System.Object));
                break;

            case "Windows.UI.Xaml.Controls.Page":
                xamlType = new global::kter_myelement.track_you_XamlTypeInfo.XamlSystemBaseType(typeName, typeof(global::Windows.UI.Xaml.Controls.Page));
                break;

            case "kter_myelement.QuickStartTask":
                userType = new global::kter_myelement.track_you_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::kter_myelement.QuickStartTask), GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
                userType.Activator = Activate_0_QuickStartTask;
                userType.AddMemberName("Number");
                AddToMapOfTypeToStandardName(typeof(global::System.Int32),
                                                   "Int32");
                userType.AddMemberName("Title");
                AddToMapOfTypeToStandardName(typeof(global::System.String),
                                                   "String");
                userType.AddMemberName("Description");
                AddToMapOfTypeToStandardName(typeof(global::System.String),
                                                   "String");
                xamlType = userType;
                break;

            case "Com.AMap.Maps.Api.AMap":
                userType = new global::kter_myelement.track_you_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::Com.AMap.Maps.Api.AMap), GetXamlTypeByName("Windows.UI.Xaml.Controls.Canvas"));
                userType.Activator = Activate_1_AMap;
                userType.SetContentPropertyName("Com.AMap.Maps.Api.AMap.Children");
                userType.AddMemberName("Children");
                userType.AddMemberName("MapSize");
                userType.AddMemberName("IsMapLoaded");
                AddToMapOfTypeToStandardName(typeof(global::System.Boolean),
                                                   "Boolean");
                userType.AddMemberName("Center");
                userType.AddMemberName("Zoom");
                AddToMapOfTypeToStandardName(typeof(global::System.Int32),
                                                   "Int32");
                userType.AddMemberName("MinZoomLevel");
                AddToMapOfTypeToStandardName(typeof(global::System.Int32),
                                                   "Int32");
                userType.AddMemberName("MaxZoomLevel");
                AddToMapOfTypeToStandardName(typeof(global::System.Int32),
                                                   "Int32");
                userType.AddMemberName("MapType");
                xamlType = userType;
                break;

            case "Com.AMap.Maps.Api.BaseTypes.ALngLat":
                userType = new global::kter_myelement.track_you_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::Com.AMap.Maps.Api.BaseTypes.ALngLat), GetXamlTypeByName("Object"));
                xamlType = userType;
                break;

            case "Com.AMap.Maps.Api.MapType":
                userType = new global::kter_myelement.track_you_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::Com.AMap.Maps.Api.MapType), GetXamlTypeByName("System.Enum"));
                userType.AddEnumValue("Road", global::Com.AMap.Maps.Api.MapType.Road);
                userType.AddEnumValue("Aerial", global::Com.AMap.Maps.Api.MapType.Aerial);
                xamlType = userType;
                break;

            case "System.Enum":
                userType = new global::kter_myelement.track_you_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::System.Enum), GetXamlTypeByName("System.ValueType"));
                xamlType = userType;
                break;

            case "System.ValueType":
                userType = new global::kter_myelement.track_you_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::System.ValueType), GetXamlTypeByName("Object"));
                xamlType = userType;
                break;

            case "kter_myelement.MainPage":
                userType = new global::kter_myelement.track_you_XamlTypeInfo.XamlUserType(this, typeName, typeof(global::kter_myelement.MainPage), GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_6_MainPage;
                xamlType = userType;
                break;

            }
            return xamlType;
        }


        private object get_0_QuickStartTask_Number(object instance)
        {
            var that = (global::kter_myelement.QuickStartTask)instance;
            return that.Number;
        }
        private void set_0_QuickStartTask_Number(object instance, object Value)
        {
            var that = (global::kter_myelement.QuickStartTask)instance;
            that.Number = (global::System.Int32)Value;
        }
        private object get_1_QuickStartTask_Title(object instance)
        {
            var that = (global::kter_myelement.QuickStartTask)instance;
            return that.Title;
        }
        private void set_1_QuickStartTask_Title(object instance, object Value)
        {
            var that = (global::kter_myelement.QuickStartTask)instance;
            that.Title = (global::System.String)Value;
        }
        private object get_2_QuickStartTask_Description(object instance)
        {
            var that = (global::kter_myelement.QuickStartTask)instance;
            return that.Description;
        }
        private void set_2_QuickStartTask_Description(object instance, object Value)
        {
            var that = (global::kter_myelement.QuickStartTask)instance;
            that.Description = (global::System.String)Value;
        }
        private object get_3_AMap_Children(object instance)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            return that.Children;
        }
        private object get_4_AMap_MapSize(object instance)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            return that.MapSize;
        }
        private void set_4_AMap_MapSize(object instance, object Value)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            that.MapSize = (global::Windows.Foundation.Size)Value;
        }
        private object get_5_AMap_IsMapLoaded(object instance)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            return that.IsMapLoaded;
        }
        private object get_6_AMap_Center(object instance)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            return that.Center;
        }
        private void set_6_AMap_Center(object instance, object Value)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            that.Center = (global::Com.AMap.Maps.Api.BaseTypes.ALngLat)Value;
        }
        private object get_7_AMap_Zoom(object instance)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            return that.Zoom;
        }
        private void set_7_AMap_Zoom(object instance, object Value)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            that.Zoom = (global::System.Int32)Value;
        }
        private object get_8_AMap_MinZoomLevel(object instance)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            return that.MinZoomLevel;
        }
        private void set_8_AMap_MinZoomLevel(object instance, object Value)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            that.MinZoomLevel = (global::System.Int32)Value;
        }
        private object get_9_AMap_MaxZoomLevel(object instance)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            return that.MaxZoomLevel;
        }
        private void set_9_AMap_MaxZoomLevel(object instance, object Value)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            that.MaxZoomLevel = (global::System.Int32)Value;
        }
        private object get_10_AMap_MapType(object instance)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            return that.MapType;
        }
        private void set_10_AMap_MapType(object instance, object Value)
        {
            var that = (global::Com.AMap.Maps.Api.AMap)instance;
            that.MapType = (global::Com.AMap.Maps.Api.MapType)Value;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::kter_myelement.track_you_XamlTypeInfo.XamlMember xamlMember = null;
            global::kter_myelement.track_you_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "kter_myelement.QuickStartTask.Number":
                userType = (global::kter_myelement.track_you_XamlTypeInfo.XamlUserType)GetXamlTypeByName("kter_myelement.QuickStartTask");
                xamlMember = new global::kter_myelement.track_you_XamlTypeInfo.XamlMember(this, "Number", "Int32");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_0_QuickStartTask_Number;
                xamlMember.Setter = set_0_QuickStartTask_Number;
                break;
            case "kter_myelement.QuickStartTask.Title":
                userType = (global::kter_myelement.track_you_XamlTypeInfo.XamlUserType)GetXamlTypeByName("kter_myelement.QuickStartTask");
                xamlMember = new global::kter_myelement.track_you_XamlTypeInfo.XamlMember(this, "Title", "String");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_1_QuickStartTask_Title;
                xamlMember.Setter = set_1_QuickStartTask_Title;
                break;
            case "kter_myelement.QuickStartTask.Description":
                userType = (global::kter_myelement.track_you_XamlTypeInfo.XamlUserType)GetXamlTypeByName("kter_myelement.QuickStartTask");
                xamlMember = new global::kter_myelement.track_you_XamlTypeInfo.XamlMember(this, "Description", "String");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_2_QuickStartTask_Description;
                xamlMember.Setter = set_2_QuickStartTask_Description;
                break;
            case "Com.AMap.Maps.Api.AMap.Children":
                userType = (global::kter_myelement.track_you_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Com.AMap.Maps.Api.AMap");
                xamlMember = new global::kter_myelement.track_you_XamlTypeInfo.XamlMember(this, "Children", "Windows.UI.Xaml.Controls.UIElementCollection");
                xamlMember.Getter = get_3_AMap_Children;
                xamlMember.SetIsReadOnly();
                break;
            case "Com.AMap.Maps.Api.AMap.MapSize":
                userType = (global::kter_myelement.track_you_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Com.AMap.Maps.Api.AMap");
                xamlMember = new global::kter_myelement.track_you_XamlTypeInfo.XamlMember(this, "MapSize", "Windows.Foundation.Size");
                xamlMember.Getter = get_4_AMap_MapSize;
                xamlMember.Setter = set_4_AMap_MapSize;
                break;
            case "Com.AMap.Maps.Api.AMap.IsMapLoaded":
                userType = (global::kter_myelement.track_you_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Com.AMap.Maps.Api.AMap");
                xamlMember = new global::kter_myelement.track_you_XamlTypeInfo.XamlMember(this, "IsMapLoaded", "Boolean");
                xamlMember.Getter = get_5_AMap_IsMapLoaded;
                xamlMember.SetIsReadOnly();
                break;
            case "Com.AMap.Maps.Api.AMap.Center":
                userType = (global::kter_myelement.track_you_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Com.AMap.Maps.Api.AMap");
                xamlMember = new global::kter_myelement.track_you_XamlTypeInfo.XamlMember(this, "Center", "Com.AMap.Maps.Api.BaseTypes.ALngLat");
                xamlMember.Getter = get_6_AMap_Center;
                xamlMember.Setter = set_6_AMap_Center;
                break;
            case "Com.AMap.Maps.Api.AMap.Zoom":
                userType = (global::kter_myelement.track_you_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Com.AMap.Maps.Api.AMap");
                xamlMember = new global::kter_myelement.track_you_XamlTypeInfo.XamlMember(this, "Zoom", "Int32");
                xamlMember.Getter = get_7_AMap_Zoom;
                xamlMember.Setter = set_7_AMap_Zoom;
                break;
            case "Com.AMap.Maps.Api.AMap.MinZoomLevel":
                userType = (global::kter_myelement.track_you_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Com.AMap.Maps.Api.AMap");
                xamlMember = new global::kter_myelement.track_you_XamlTypeInfo.XamlMember(this, "MinZoomLevel", "Int32");
                xamlMember.Getter = get_8_AMap_MinZoomLevel;
                xamlMember.Setter = set_8_AMap_MinZoomLevel;
                break;
            case "Com.AMap.Maps.Api.AMap.MaxZoomLevel":
                userType = (global::kter_myelement.track_you_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Com.AMap.Maps.Api.AMap");
                xamlMember = new global::kter_myelement.track_you_XamlTypeInfo.XamlMember(this, "MaxZoomLevel", "Int32");
                xamlMember.Getter = get_9_AMap_MaxZoomLevel;
                xamlMember.Setter = set_9_AMap_MaxZoomLevel;
                break;
            case "Com.AMap.Maps.Api.AMap.MapType":
                userType = (global::kter_myelement.track_you_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Com.AMap.Maps.Api.AMap");
                xamlMember = new global::kter_myelement.track_you_XamlTypeInfo.XamlMember(this, "MapType", "Com.AMap.Maps.Api.MapType");
                xamlMember.Getter = get_10_AMap_MapType;
                xamlMember.Setter = set_10_AMap_MapType;
                break;
            }
            return xamlMember;
        }

    }

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(global::System.String input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::kter_myelement.track_you_XamlTypeInfo.XamlSystemBaseType
    {
        global::kter_myelement.track_you_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::kter_myelement.track_you_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public global::System.Object CreateFromString(global::System.String input)
        {
            if (_enumValues != null)
            {
                global::System.Int32 value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    global::System.Int32 enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( global::System.String.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::kter_myelement.track_you_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::kter_myelement.track_you_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(global::System.String targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}


