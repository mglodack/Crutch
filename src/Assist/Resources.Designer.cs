﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assist {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Assist.Resources", typeof(Resources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Did you mean to assign the property to something else?.
        /// </summary>
        internal static string InvalidPropertyAssignmentDescription {
            get {
                return ResourceManager.GetString("InvalidPropertyAssignmentDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property named &apos;{0}&apos; should not be assigned to itself..
        /// </summary>
        internal static string InvalidPropertyAssignmentMessageFormat {
            get {
                return ResourceManager.GetString("InvalidPropertyAssignmentMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid property assignment..
        /// </summary>
        internal static string InvalidPropertyAssignmentTitle {
            get {
                return ResourceManager.GetString("InvalidPropertyAssignmentTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Did you mean to use the unused parameter?.
        /// </summary>
        internal static string UnusedParameterDescription {
            get {
                return ResourceManager.GetString("UnusedParameterDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parameter &apos;{0}&apos; is not being used..
        /// </summary>
        internal static string UnusedParameterMessageFormat {
            get {
                return ResourceManager.GetString("UnusedParameterMessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unused argument parameter..
        /// </summary>
        internal static string UnusedParameterTitle {
            get {
                return ResourceManager.GetString("UnusedParameterTitle", resourceCulture);
            }
        }
    }
}