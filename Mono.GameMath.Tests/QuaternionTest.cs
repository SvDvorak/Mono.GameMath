﻿using System;
using NUnit.Framework;

namespace Mono.GameMath.Tests
{
    class QuaternionTest
    {
        private static void Compare(Quaternion expected, Quaternion source)
        {
            Assert.That(expected, Is.EqualTo(source).Using(QuaternionComparer.Epsilon));
        }

        private static void Compare(Vector3 expected, Vector3 source)
        {
            Assert.That(expected, Is.EqualTo(source).Using(Vector3Comparer.Epsilon));
        }

        private static void Compare(float expected, float source)
        {
            Assert.That(expected, Is.EqualTo(source).Using(FloatComparer.Epsilon));
        }

        [Test]
        public void Constructors()
        {
            Quaternion expected;
            expected.X = 1;
            expected.Y = 2;
            expected.Z = 3;
            expected.W = 4;
            Compare(expected, new Quaternion(1, 2, 3, 4));
            Compare(expected, new Quaternion(new Vector3(1, 2, 3), 4));
#if !XNA
            Compare(expected, new Quaternion(new Vector4(1, 2, 3, 4)));
#endif
        }

        [Test]
        public void Properties()
        {
            Compare(new Quaternion(0, 0, 0, 1), Quaternion.Identity);
        }

        [Test]
        public void Add()
        {
            Quaternion q1 = new Quaternion(1, 2, 3, 4);
            Quaternion q2 = new Quaternion(1, 2, 3, 4);
            Quaternion expected = new Quaternion(2, 4, 6, 8);
            Compare(expected, Quaternion.Add(q1, q2));

            Quaternion result;
            Quaternion.Add(ref q1, ref q2, out result);
            Compare(expected, result);
        }

        [Test]
        public void Concatenate()
        {
            Quaternion q1 = new Quaternion(1, 2.5f, 3, 4);
            Quaternion q2 = new Quaternion(1, 2, -3.8f, 2);
            Quaternion expected = new Quaternion(21.5f, 6.2f, -8.7f, 13.4f);
            Compare(expected, Quaternion.Concatenate(q1, q2));

            Quaternion result;
            Quaternion.Concatenate(ref q1, ref q2, out result);
            Compare(expected, result);
        }

        [Test]
        public void Conjugate()
        {
            Quaternion q = new Quaternion(1, 2, 3, 4);
            Quaternion expected = new Quaternion(-1, -2, -3, 4);
            Compare(expected, Quaternion.Conjugate(q));

            Quaternion result;
            Quaternion.Conjugate(ref q, out result);
            Compare(expected, result);

            q.Conjugate();
            Compare(expected, q);
        }

        public class LookAt
        {
            [Test]
            public void CorrectRotationLookingAtArbitraryDirection()
            {
                ShouldLookAt(Vector3.Forward);
                ShouldLookAt(Vector3.Backward);
                ShouldLookAt(Vector3.Left);
                ShouldLookAt(Vector3.Right);
                ShouldLookAt(Vector3.Forward + Vector3.Right);
                ShouldLookAt(new Vector3(0.3f, 0.6f, 0.1f));
            }

            private static void ShouldLookAt(Vector3 direction)
            {
                direction = direction.Normalized();
                var quaternionLook = Quaternion.LookAt(direction)*Vector3.Forward;
                Compare(quaternionLook, direction);
            }

            [Test]
            public void IdentityWithForwardSameAsUnitForward()
            {
                var lookAt = Quaternion.LookAt(Vector3.Forward);

                Compare(lookAt, Quaternion.Identity);
            }

            [Test]
            public void Rotated180WhenForwardIsUnitBackward()
            {
                var lookAt = Quaternion.LookAt(Vector3.Backward);

                Compare(lookAt, new Quaternion(0, 1, 0, MathHelper.Pi));
            }
        }

        [Test]
        public void CreateFromAxisAngle()
        {
            Vector3 axis = new Vector3(0.5f, 1.1f, -3.8f);
            float angle = 0.25f;
            Quaternion expected = new Quaternion(0.06233737f, 0.1371422f, -0.473764f, 0.9921977f);

            Compare(expected, Quaternion.CreateFromAxisAngle(axis, angle));

            Quaternion result;
            Quaternion.CreateFromAxisAngle(ref axis, angle, out result);
            Compare(expected, result);
        }

        [Test]
        public void CreateFromRotationMatrix()
        {
            var matrix = Matrix.CreateFromYawPitchRoll(0.15f, 1.18f, -0.22f);
            Quaternion expected = new Quaternion(0.5446088f, 0.1227905f, -0.1323988f, 0.8190203f);
            Compare(expected, Quaternion.CreateFromRotationMatrix(matrix));

            Quaternion result;
            Quaternion.CreateFromRotationMatrix(ref matrix, out result);
            Compare(expected, result);
        }

        [Test]
        public void CreateFromYawPitchRoll()
        {
            Quaternion expected = new Quaternion(0.5446088f, 0.1227905f, -0.1323988f, 0.8190203f);
            Compare(expected, Quaternion.CreateFromYawPitchRoll(0.15f, 1.18f, -0.22f));

            Quaternion result;
            Quaternion.CreateFromYawPitchRoll(0.15f, 1.18f, -0.22f, out result);
            Compare(expected, result);
        }

        [Test]
        public void Divide()
        {
            Quaternion q1 = new Quaternion(1, 2, 3, 4);
            Quaternion q2 = new Quaternion(0.2f, -0.6f, 11.9f, 0.01f);
            Quaternion expected = new Quaternion(-0.1858319f, 0.09661285f, -0.3279344f, 0.2446305f);
            Compare(expected, Quaternion.Divide(q1, q2));

            Quaternion result;
            Quaternion.Divide(ref q1, ref q2, out result);
            Compare(expected, result);
        }

        [Test]
        public void Length()
        {
            Quaternion q1 = new Quaternion(1, 2, 3, 4);
            Compare(5.477226f, q1.Length());
        }

        [Test]
        public void LengthSquared()
        {
            Quaternion q1 = new Quaternion(1, 2, 3, 4);
            Compare(30.0f, q1.LengthSquared());
        }

        [Test]
        public void Normalize()
        {
            Quaternion q = new Quaternion(1, 2, 3, 4);
            Quaternion expected = new Quaternion(0.1825742f, 0.3651484f, 0.5477226f, 0.7302967f);

            Compare(expected, Quaternion.Normalize(q));

            Quaternion result;
            Quaternion.Normalize(ref q, out result);
            Compare(expected, result);


            q.Normalize();
            Compare(expected, q);
        }
    }
}
