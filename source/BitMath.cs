/* Copyright 2013-2014 kasthack(kasthack@epicm.org)
 * 
 * BitMath is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * BitMath is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with BitMath.  If not, see <http://www.gnu.org/licenses/>
*/
using System.Runtime.CompilerServices;
// based on http://graphics.stanford.edu/~seander/bithacks.html
namespace kasthack.Tools {
    public static class BitMath {
        //sizes
        private const int BIT_BYTE = 8;
        private const int Isz = sizeof( int ) * BIT_BYTE - 1;
        private const int Lsz = sizeof( long ) * BIT_BYTE - 1;
        private const int Bsz = sizeof( sbyte ) * BIT_BYTE - 1;
        private const int Ssz = sizeof( short ) * BIT_BYTE - 1;

        // ( ( x >> 31 ) ^ x ) - ( x >> ( sizeof(x_type) - 1 ) )

        #region Abs
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static int Abs( int value ) {
            var a = value >> Isz;
            return ( value ^ a ) - a;
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static uint Abs( uint value ) {
            var a = value >> Isz;
            return ( value ^ a ) - a;
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static long Abs( long value ) {
            var a = value >> Lsz;
            return ( value ^ a ) - a;
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static ulong Abs( ulong value ) {
            var a = value >> Lsz;
            return ( value ^ a ) - a;
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static sbyte Abs( sbyte value ) {
            var a = (sbyte) ( value >> Bsz );
            return (sbyte) ( ( value ^ a ) - a );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static byte Abs( byte value ) {
            var a = (byte) ( value >> Bsz );
            return (byte) ( ( value ^ a ) - a );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static short Abs( short value ) {
            var a = (short) ( value >> Bsz );
            return (short) ( ( value ^ a ) - a );
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static ushort Abs( ushort value ) {
            var a = (ushort) ( value >> Bsz );
            return (ushort) ( ( value ^ a ) - a );
        }
        #endregion

        // a - ( ( a - b ) & ( ( a - b ) >> ( sizeof(x_type) - 1 ) ) )
        #region Max
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static int Max( int a, int b ) { return a - ( ( a - b ) & ( ( a - b ) >> Isz ) ); }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static uint Max( uint a, uint b ) { return a - ( ( a - b ) & ( ( a - b ) >> Isz ) ); }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static long Max( long a, long b ) { return a - ( ( a - b ) & ( ( a - b ) >> Lsz ) ); }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static ulong Max( ulong a, ulong b ) { return a - ( ( a - b ) & ( ( a - b ) >> Lsz ) ); }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static sbyte Max( sbyte a, sbyte b ) { return (sbyte) ( a - ( ( a - b ) & ( ( a - b ) >> Bsz ) ) ); }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static byte Max( byte a, byte b ) { return (byte) ( a - ( ( a - b ) & ( ( a - b ) >> Bsz ) ) ); }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static short Max( short a, short b ) { return (short) ( a - ( ( a - b ) & ( ( a - b ) >> Ssz ) ) ); }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static ushort Max( ushort a, ushort b ) { return (ushort) ( a - ( ( a - b ) & ( ( a - b ) >> Ssz ) ) ); }
        #endregion

        // b + ( ( a - b ) & ( ( a - b ) >> ( sizeof(x_type) - 1 ) ) )
        #region Min
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static int Min( int a, int b ) { return b + ( ( a - b ) & ( ( a - b ) >> Isz ) ); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Min(uint a, uint b) { return b + ((a - b) & ((a - b) >> Isz)); }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static long Min( long a, long b ) { return b + ( ( a - b ) & ( ( a - b ) >> Lsz ) ); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Min(ulong a, ulong b) { return b + ((a - b) & ((a - b) >> Lsz)); }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static byte Min( byte a, byte b ) { return (byte) ( b + ( ( a - b ) & ( ( a - b ) >> Bsz ) ) ); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min(sbyte a, sbyte b) { return (sbyte)(b + ((a - b) & ((a - b) >> Bsz))); }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Min( short a, short b ) { return (short) ( b + ( ( a - b ) & ( ( a - b ) >> Ssz ) ) ); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Min(ushort a, ushort b) { return (ushort)(b + ((a - b) & ((a - b) >> Ssz))); }
        #endregion

        // ( value != 0) | ( value >> ( sizeof(x_type) - 1 ) )
        #region Sign
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
        #endregion

        // ( ( a ^ b ) < 0 )
        #region OppositeSigns
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool OppositeSigns( int a, int b ) { return ( ( a ^ b ) < 0 ); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool OppositeSigns(long a, long b) { return ((a ^ b) < 0); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool OppositeSigns(short a, short b) { return ((a ^ b) < 0); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool OppositeSigns(sbyte a, sbyte b) { return ((a ^ b) < 0); }
        #endregion
        
        // value && !( value & ( value - 1) )
        #region IsPowerOfTwo
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsPowerOfTwo( uint value ) {
            value = value & ~( value & ( value - 1 ) );
            return *(bool*)&value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsPowerOfTwo(int value) {
            var v2 = (uint) value;
            v2 = v2 & ~(v2 & (v2 - 1));
            return *(bool*)&v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsPowerOfTwo(ulong value) {
            value = value & ~(value & (value - 1));
            return *(bool*)&value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsPowerOfTwo(long value) {
            var v2 = (ulong)value;
            v2 = v2 & ~(v2 & (v2 - 1));
            return *(bool*)&v2;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsPowerOfTwo(ushort value) {
            value = (ushort)(value & ~(value & (value - 1)));
            return *(bool*)&value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsPowerOfTwo(short value) {
            var v2 = (ushort)value;
            v2 = (ushort)(v2 & ~(v2 & (v2 - 1)));
            return *(bool*) &v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsPowerOfTwo(sbyte value) {
            var v2 = (byte)value;
            v2 = (byte)(v2 & ~(v2 & (v2 - 1)));
            return *(bool*)&v2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsPowerOfTwo(byte value) {
            value = (byte)(value & ~(value & (value - 1)));
            return *(bool*)&value;
        }
        #endregion
    }
}