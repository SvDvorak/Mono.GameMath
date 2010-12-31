// 
// Vector3.cs
//  
// Author:
//       Michael Hutchinson <mhutchinson@novell.com>
// 
// Copyright (c) 2010 Novell, Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;

namespace Mono.GameMath
{
	[Serializable]
	public struct Vector3 : IEquatable<Vector3>
	{
		public float X, Y, Z;
		
		public Vector3 (float value) : this (value, value, value)
		{
		}
		
		public Vector3 (Vector2 value, float z) : this (value.X, value.Y, z)
		{
		}
		
		public Vector3 (float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}
		
		#region Static properties
		
		public static Vector3 Right {
			get { return new Vector3 (1f, 0f, 0f); }
		}
		
		public static Vector3 Left {
			get { return new Vector3 (-1f, 0f, 0f); }
		}
		
		public static Vector3 Up {
			get { return new Vector3 (0f, 1f, 0f); }
		}
		
		public static Vector3 Down {
			get { return new Vector3 (0f, -1f, 0f); }
		}
		
		public static Vector3 Backward {
			get { return new Vector3 (0f, 0f, 1f); }
		}
		
		public static Vector3 Forward {
			get { return new Vector3 (0f, 0f, -1f); }
		}
		
		public static Vector3 UnitX {
			get { return new Vector3 (1f, 0f, 0f); }
		}
		
		public static Vector3 UnitY {
			get { return new Vector3 (0f, 1f, 0f); }
		}
		
		public static Vector3 UnitZ {
			get { return new Vector3 (0f, 0f, 1f); }
		}
		
		public static Vector3 One {
			get { return new Vector3 (1f); }
		}
		
		public static Vector3 Zero {
			get { return new Vector3 (0f); }
		}
		
		#endregion
		
		#region Arithmetic
		
		public static Vector3 Add (Vector3 value1, Vector3 value2)
		{
			Add (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Add (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X + value2.X;
			result.Y = value1.Y + value2.Y;
			result.Z = value1.Z + value2.Z;
		}
		
		public static Vector3 Divide (Vector3 value1, float value2)
		{
			Divide (ref value1, value2, out value1);
			return value1;
		}
		
		public static void Divide (ref Vector3 value1, float value2, out Vector3 result)
		{
			result.X = value1.X / value2;
			result.Y = value1.Y / value2;
			result.Z = value1.Z / value2;
		}
		
		public static Vector3 Divide (Vector3 value1, Vector3 value2)
		{
			Divide (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Divide (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X / value2.X;
			result.Y = value1.Y / value2.Y;
			result.Z = value1.Z / value2.Z;
		}
		
		public static Vector3 Multiply (Vector3 value1, float scaleFactor)
		{
			Multiply (ref value1, scaleFactor, out value1);
			return value1;
		}
		
		public static void Multiply (ref Vector3 value1, float scaleFactor, out Vector3 result)
		{
			result.X = value1.X * scaleFactor;
			result.Y = value1.Y * scaleFactor;
			result.Z = value1.Z * scaleFactor;
		}
		
		public static Vector3 Multiply (Vector3 value1, Vector3 value2)
		{
			Multiply (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Multiply (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X * value2.X;
			result.Y = value1.Y * value2.Y;
			result.Z = value1.Z * value2.Z;
		}
		
		public static Vector3 Negate (Vector3 value)
		{
			Negate (ref value, out value);
			return value;
		}
		
		public static void Negate (ref Vector3 value, out Vector3 result)
		{
			result.X = - value.X;
			result.Y = - value.Y;
			result.Z = - value.Z;
		}
		
		public static Vector3 Subtract (Vector3 value1, Vector3 value2)
		{
			Subtract (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Subtract (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X - value2.X;
			result.Y = value1.Y - value2.Y;
			result.Z = value1.Z - value2.Z;
		}
		
		#endregion
		
		#region Operator overloads
		
		public static Vector3 operator + (Vector3 value1, Vector3 value2)
		{
			return Add (value1, value2);
		}
		
		public static Vector3 operator / (Vector3 value, float divider)
		{
			return Divide (value, divider);
		}
		
		public static Vector3 operator / (Vector3 value1, Vector3 value2)
		{
			return Divide (value1, value2);
		}
		
		public static Vector3 operator * (Vector3 value1, Vector3 value2)
		{
			return Multiply (value1, value2);
		}
		
		public static Vector3 operator * (Vector3 value, float scaleFactor)
		{
			return Multiply (value, scaleFactor);
		}
		
		public static Vector3 operator * (float scaleFactor, Vector3 value)
		{
			return Multiply (value, scaleFactor);
		}
		
		public static Vector3 operator - (Vector3 value1, Vector3 value2)
		{
			return Subtract (value1, value2);
		}
		
		public static Vector3 operator - (Vector3 value)
		{
			return Negate (value);
		}
		
		#endregion
		
		#region Interpolation
		
		public static Vector3 CatmullRom (Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float amount)
		{
			CatmullRom (ref value1, ref value2, ref value3, ref value4, amount, out value1);
			return value1;
		}
		
		public static void CatmullRom (ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4,
			float amount, out Vector3 result)
		{
			//FIXME: probably more efficient to share work between values
			result.X = MathHelper.CatmullRom (value1.X, value2.X, value3.X, value4.X, amount);
			result.Y = MathHelper.CatmullRom (value1.Y, value2.Y, value3.Y, value4.Y, amount);
			result.Z = MathHelper.CatmullRom (value1.Z, value2.Z, value3.Z, value4.Z, amount);
		}
		
		public static Vector3 Hermite (Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
		{
			Hermite (ref value1, ref tangent1, ref value2, ref tangent2, amount, out value1);
			return value1;
		}
		
		public static void Hermite (ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2,
			float amount, out Vector3 result)
		{
			//FIXME: probably more efficient to share work between values
			result.X = MathHelper.Hermite (value1.X, tangent1.X, value2.X, tangent2.X, amount);
			result.Y = MathHelper.Hermite (value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
			result.Z = MathHelper.Hermite (value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
		}
		
		public static Vector3 Lerp (Vector3 value1, Vector3 value2, float amount)
		{
			Lerp (ref value1, ref value2, amount, out value1);
			return value1;
		}
		
		public static void Lerp (ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
		{
			Subtract (ref value2, ref value1, out result);
			Multiply (ref result, amount, out result);
			Add (ref value1, ref result, out result);
		}
		
		public static Vector3 SmoothStep (Vector3 value1, Vector3 value2, float amount)
		{
			SmoothStep (ref value1, ref value2, amount, out value1);
			return value1;
		}
		
		public static void SmoothStep (ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
		{
			float scale = (amount * amount * (3 - 2 * amount));
			Subtract (ref value2, ref value1, out result);
			Multiply (ref result, scale, out result);
			Add (ref value1, ref result, out result);
		}
		
		#endregion
		
		#region Other maths
		
		public static Vector3 Barycentric (Vector3 value1, Vector3 value2, Vector3 value3, float amount1, float amount2)
		{
			Barycentric (ref value1, ref value2, ref value3, amount1, amount2, out value1);
			return value1;
		}
		
		public static void Barycentric (ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, float amount1,
			float amount2, out Vector3 result)
		{
			//FIXME: probably more efficient to share work between values
			result.X = MathHelper.Barycentric (value1.X, value2.X, value3.X, amount1, amount2);
			result.Y = MathHelper.Barycentric (value1.Y, value2.Y, value3.Y, amount1, amount2);
			result.Z = MathHelper.Barycentric (value1.Z, value2.Z, value3.Z, amount1, amount2);
		}
		
		public static Vector3 Clamp (Vector3 value1, Vector3 min, Vector3 max)
		{
			Clamp (ref value1, ref min, ref max, out value1);
			return value1;
		}
		
		public static void Clamp (ref Vector3 value1, ref Vector3 min, ref Vector3 max, out Vector3 result)
		{
			result.X = MathHelper.Clamp (value1.X, min.X, max.X);
			result.Y = MathHelper.Clamp (value1.Y, min.Y, max.Y);
			result.Z = MathHelper.Clamp (value1.Z, min.Z, max.Z);
		}
		
		public static Vector3 Cross (Vector3 vector1, Vector3 vector2)
		{
			Vector3 result;
			Cross (ref vector1, ref vector2, out result);
			return result;
		}
		
		public static void Cross (ref Vector3 vector1, ref Vector3 vector2, out Vector3 result)
		{
			result.X = vector1.Y * vector2.Z - vector1.Z * vector2.Y;
			result.Y = vector1.Z * vector2.X - vector1.X * vector2.Z;
			result.Z = vector1.X * vector2.Y - vector1.Y * vector2.X;
		}
		
		public static float Distance (Vector3 value1, Vector3 value2)
		{
			float result;
			Distance (ref value1, ref value2, out result);
			return result;
		}
		
		public static void Distance (ref Vector3 value1, ref Vector3 value2, out float result)
		{
			DistanceSquared (ref value1, ref value2, out result);
			result = (float) System.Math.Sqrt (result);
		}
		
		public static float DistanceSquared (Vector3 value1, Vector3 value2)
		{
			float result;
			DistanceSquared (ref value1, ref value2, out result);
			return result;
		}
		
		public static void DistanceSquared (ref Vector3 value1, ref Vector3 value2, out float result)
		{
			Subtract (ref value1, ref value2, out value1);
			result = value1.LengthSquared ();
		}
		
		public static float Dot (Vector3 vector1, Vector3 vector2)
		{
			float result;
			Dot (ref vector1, ref vector2, out result);
			return result;
		}
		
		public static void Dot (ref Vector3 vector1, ref Vector3 vector2, out float result)
		{
			result = (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z);
		}
		
		public float Length ()
		{
			return (float) System.Math.Sqrt (LengthSquared ());
		}
		
		public float LengthSquared ()
		{
			return (X * X) + (Y * Y) + (Z * Z);
		}
		
		public static Vector3 Max (Vector3 value1, Vector3 value2)
		{
			Max (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Max (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = System.Math.Max (value1.X, value2.X);
			result.Y = System.Math.Max (value1.Y, value2.Y);
			result.Z = System.Math.Max (value1.Z, value2.Z);
		}
		
		public static Vector3 Min (Vector3 value1, Vector3 value2)
		{
			Min (ref value1, ref value2, out value1);
			return value1;
		}
		
		public static void Min (ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = System.Math.Min (value1.X, value2.X);
			result.Y = System.Math.Min (value1.Y, value2.Y);
			result.Z = System.Math.Min (value1.Z, value2.Z);
		}
		
		public void Normalize ()
		{
			Normalize (ref this, out this);
		}
		
		public static Vector3 Normalize (Vector3 value)
		{
			value.Normalize ();
			return value;
		}
		
		public static void Normalize (ref Vector3 value, out Vector3 result)
		{
			Multiply (ref value, 1f / value.Length (), out result);
		}
		
		public static Vector3 Reflect (Vector3 vector, Vector3 normal)
		{
			Vector3 result;
			Reflect (ref vector, ref normal, out result);
			return result;
		}
		
		public static void Reflect (ref Vector3 vector, ref Vector3 normal, out Vector3 result)
		{
			throw new NotImplementedException ();
		}
		
		#endregion
		
		#region Transform
		
		public static Vector3 Transform (Vector3 position, Matrix matrix)
		{
			Vector3 result;
			Transform (ref position, ref matrix, out result);
			return result;
		}
		
		public static void Transform (ref Vector3 position, ref Matrix matrix, out Vector3 result)
		{
			throw new NotImplementedException ();
		}
		
		public static Vector3 Transform (Vector3 value, Quaternion rotation)
		{
			Vector3 result;
			Transform (ref value, ref rotation, out result);
			return result;
		}
		
		public static void Transform (ref Vector3 value, ref Quaternion rotation, out Vector3 result)
		{
			throw new NotImplementedException ();
		}
		
		static void CheckArrayArgs (Vector3[] sourceArray, int sourceIndex, Vector3[] destinationArray,
			int destinationIndex, int length)
		{
			if (sourceArray == null)
				throw new ArgumentNullException ("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException ("destinationArray");
			if (sourceIndex + length > sourceArray.Length)
				throw new ArgumentException ("Source is smaller than specified length and index");
			if (destinationIndex + length > destinationArray.Length)
				throw new ArgumentException ("Destination is smaller than specified length and index");
		}
		
		static void CheckArrayArgs (Vector3[] sourceArray, Vector3[] destinationArray)
		{
			if (sourceArray == null)
				throw new ArgumentNullException ("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException ("destinationArray");
			if (destinationArray.Length < sourceArray.Length)
				throw new ArgumentException ("Destination is smaller than source", "destinationArray");
		}
		
		public static void Transform (Vector3[] sourceArray, int sourceIndex, ref Matrix matrix,
			Vector3[] destinationArray, int destinationIndex, int length)
		{
			CheckArrayArgs (sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			
			int smax = sourceIndex + length;
			for (int s = sourceIndex, d = destinationIndex; s < smax; s++, d++)
				Transform (ref sourceArray[s], ref matrix, out destinationArray[d]);
		}
		
		public static void Transform (Vector3[] sourceArray, int sourceIndex, ref Quaternion rotation,
			Vector3[] destinationArray, int destinationIndex, int length)
		{
			CheckArrayArgs (sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			
			int smax = sourceIndex + length;
			for (int s = sourceIndex, d = destinationIndex; s < smax; s++, d++)
				Transform (ref sourceArray[s], ref rotation, out destinationArray[d]);
		}
		
		public static void Transform (Vector3[] sourceArray, ref Matrix matrix, Vector3[] destinationArray)
		{
			CheckArrayArgs (sourceArray, destinationArray);
			
			for (int i = 0; i < sourceArray.Length; i++)
				Transform (ref sourceArray[i], ref matrix, out destinationArray[i]);
		}
		
		public static void Transform (Vector3[] sourceArray, ref Quaternion rotation, Vector3[] destinationArray)
		{
			CheckArrayArgs (sourceArray, destinationArray);
			
			for (int i = 0; i < sourceArray.Length; i++)
				Transform (ref sourceArray[i], ref rotation, out destinationArray[i]);
		}
		
		#endregion
		
		#region TransformNormal
		
		public static Vector3 TransformNormal (Vector3 normal, Matrix matrix)
		{
			Vector3 result;
			TransformNormal (ref normal, ref matrix, out result);
			return result;
		}
		
		public static void TransformNormal (ref Vector3 normal, ref Matrix matrix, out Vector3 result)
		{
			throw new NotImplementedException ();
		}
		
		public static void TransformNormal (Vector3[] sourceArray, int sourceIndex, ref Matrix matrix,
			Vector3[] destinationArray, int destinationIndex, int length)
		{
			CheckArrayArgs (sourceArray, sourceIndex, destinationArray, destinationIndex, length);
			
			int smax = sourceIndex + length;
			for (int s = sourceIndex, d = destinationIndex; s < smax; s++, d++)
				TransformNormal (ref sourceArray[s], ref matrix, out destinationArray[d]);
		}
		
		public static void TransformNormal (Vector3[] sourceArray, ref Matrix matrix, Vector3[] destinationArray)
		{
			CheckArrayArgs (sourceArray, destinationArray);
			
			for (int i = 0; i < sourceArray.Length; i++)
				TransformNormal (ref sourceArray[i], ref matrix, out destinationArray[i]);
		}
		
		#endregion
		
		#region Equality
		
		public bool Equals (Vector3 other)
		{
			return other == this;
		}
		
		public override bool Equals (object obj)
		{
			return obj is Vector3 && ((Vector3)obj) == this;
		}
		
		public override int GetHashCode ()
		{
			return X.GetHashCode () ^ Y.GetHashCode () ^ Z.GetHashCode ();
		}
		
		public static bool operator == (Vector3 a, Vector3 b)
		{
			return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
		}
		
		public static bool operator != (Vector3 a, Vector3 b)
		{
			return a.X != b.X || a.Y != b.Y || a.Z != b.Z;
		}
		
		# endregion
		
		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	}
}