using System;


namespace Assets.Scripts.Extention_Methods {

    public static class ArrayExtensions {

        public static T GetRandom<T>( this T[] source, Random rand = null ) {
            if ( rand == null ) {
                rand = new Random();
            }
            return source[rand.Next( source.Length - 1 )];
        }

    }

}