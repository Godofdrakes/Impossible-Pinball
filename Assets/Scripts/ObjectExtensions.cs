using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts {

    public static class ObjectExtensions {

        public static void LogError( this object o, string message ) {
            Debug.LogErrorFormat( "#{0}# {1}", o.GetType().Name, message );
        }

        public static void LogMessage( this object o, string message ) {
            Debug.LogFormat( "#{0}# {1}", o.GetType().Name, message );
        }

        public static void LogWarning( this object o, string message ) {
            Debug.LogWarningFormat( "#{0}# {1}", o.GetType().Name, message );
        }

    }

}
