using System.Runtime.CompilerServices;

namespace kasthack.Tools.BithackMath
{
    public  static class Math {
        //sizes
        const int BIT_BYTE = 8;
        const int Isz = sizeof( int ) * BIT_BYTE - 1;
        const int Lsz = sizeof( long ) * BIT_BYTE - 1;
        const int Bsz = sizeof( sbyte ) * BIT_BYTE - 1;
        const int Ssz = sizeof( short ) * BIT_BYTE - 1;



        // ( ( x >> 31 ) ^ x ) - ( x >> ( sizeof(x_type) - 1 ) )

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static int Abs( int value ) {
            var a = value >> Isz;
            return ( value ^ a ) - a;
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static long Abs( long value ) {
            var a = value >> Lsz;
            return ( value ^ a ) - a;
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static sbyte Abs( sbyte value ) {
            var a = (sbyte) ( value >> Bsz );
            return (sbyte) ( ( value ^ a ) - a );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static short Abs( short value ) {
            var a = (short) ( value >> Bsz );
            return (short) ( ( value ^ a ) - a );
        }


        // a - ( ( a - b ) & ( ( a - b ) >> ( sizeof(x_type) - 1 ) ) )

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static int Max( int a, int b ) {
            return a - ( ( a - b ) & ( ( a - b ) >> Isz ) );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static long Max( long a, long b ) {
            return a - ( ( a - b ) & ( ( a - b ) >> Lsz ) );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static sbyte Max( sbyte a, sbyte b ) {
            return (sbyte)(a - ( ( a - b ) & ( ( a - b ) >> Bsz ) ));
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static short Max( short a, short b ) {
            return (short) ( a - ( ( a - b ) & ( ( a - b ) >> Ssz ) ) );
        }

        // b + ( ( a - b ) & ( ( a - b ) >> ( sizeof(x_type) - 1 ) ) )

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static int Min( int a, int b ) {
            return b + ( ( a - b ) & ( ( a - b ) >> Isz ) );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static long Min( long a, long b ) {
            return b + ( ( a - b ) & ( ( a - b ) >> Lsz ) );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static sbyte Min( sbyte a, sbyte b ) {
            return (sbyte) ( b + ( ( a - b ) & ( ( a - b ) >> Bsz ) ) );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static short Min( short a, short b ) {
            return (short) ( b + ( ( a - b ) & ( ( a - b ) >> Ssz ) ) );
        }


        // ( x != 0) | ( x >> ( sizeof(x_type) - 1 ) )
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static unsafe int Sign( int value ) {
            var input = value != 0;
            return *( (byte*) &input ) | ( value >> Isz );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static unsafe int Sign( long value ) {
            var input = value != 0;
            return (int) ( *( (byte*) &input ) | ( value >> Lsz ) );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static unsafe int Sign( sbyte value ) {
            var input = value != 0;
            return *( (byte*) &input ) | ( value >> Bsz );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static unsafe int Sign( short value ) {
            var input = value != 0;
            return *( (byte*) &input ) | ( value >> Ssz );
        }
    }
}
