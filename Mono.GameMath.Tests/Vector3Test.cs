using NUnit.Framework;

namespace Mono.GameMath.Tests
{
    class Vector3Test
    {
        public class QuaternionMultiplication
        {
            [Test]
            public void MultipliesWithVector()
            {
                var vector = new Vector3(1, 0, 0);
                var quaternion = Quaternion.CreateFromAxisAngle(new Vector3(0, 1, 0), MathHelper.PiOver2);

                var expected = new Vector3(0, 0, -1);
                Assert.AreEqual(expected, Vector3.Transform(vector, quaternion));
                Assert.AreEqual(expected, quaternion * vector);
            }
        }

        public class ClampLength
        {
            [Test]
            public void DoesNothingIfMagnitudeIsWithinMax()
            {
                var sut = new Vector3(1, 0, 0);

                Assert.AreEqual(new Vector3(1, 0, 0), sut.ClampLength(10));
            }

            [Test]
            public void ClampsWhenLargerThanMax()
            {
                var sut = new Vector3(1, 0, 0);

                Assert.AreEqual(new Vector3(0.5f, 0, 0), sut.ClampLength(0.5f));
            }
        }

        public class MoveTowards
        {
            private Vector3 _position;
            private readonly Vector3 _target;

            public MoveTowards()
            {
                _position = new Vector3(1, 0, 0);
                _target = new Vector3(10, 0, 0);
            }

            [Test]
            public void MovesToTargetWhenMaxDeltaIsLargeEnough()
            {
                var newPosition = _position.MoveTowards(_target, float.PositiveInfinity);

                Assert.AreEqual(_target, newPosition);
            }

            [Test]
            public void OnlyMovesAsFarAsDelta()
            {
                var newPosition = _position.MoveTowards(_target, 2);

                Assert.AreEqual(new Vector3(3, 0, 0), newPosition);
            }
        }

        public class Equality
        {
            [Test]
            public void SameAreEqual()
            {
                var v = new Vector3(10, 10, 10);

                Assert.IsTrue(v.Equals(v), "Vector with same values should be equal");
            }

            [Test]
            public void DifferentAreNotEqual()
            {
                var v1 = new Vector3(10, 10, 10);
                var v2 = new Vector3(1, 1, 1);

                Assert.IsFalse(v1.Equals(v2), "Vector with different values should not be equal");
            }

            [Test]
            public void SimilarWithinMarginAreEqual()
            {
                var v1 = new Vector3(10, 10, 10);
                var v2 = new Vector3(10.0001f, 10.0001f, 10.0001f);

                Assert.IsTrue(v1.Equals(v2, 0.001f), "Vector with values within margin should be equal");
            }

            [Test]
            public void SimilarOutsideOfMarginAreNotEqual()
            {
                var v1 = new Vector3(10, 10, 10);
                var v2 = new Vector3(10.001f, 10.001f, 10.001f);

                Assert.IsFalse(v1.Equals(v2, 0.001f), "Vector with values outside margin should not be equal");
            }
        }

        [Test]
        public void DistanceSquared()
        {
            var v1 = new Vector3(0.1f, 100.0f, -5.5f);
            var v2 = new Vector3(1.1f, -2.0f, 5.5f);
            var d = Vector3.DistanceSquared(v1, v2);
            var expectedResult = 10526f;
            Assert.AreEqual(expectedResult, d);
        }

        [Test]
        public void Normalize()
        {
            Vector3 v1 = new Vector3(-10.5f, 0.2f, 1000.0f);
            Vector3 v2 = new Vector3(-10.5f, 0.2f, 1000.0f);
            v1.Normalize();
            var expectedResult = new Vector3(-0.0104994215f, 0.000199988979f, 0.999944866f);
            Assert.That(expectedResult, Is.EqualTo(v1).Using(Vector3Comparer.Epsilon));
            var normalizedV2 = Vector3.Normalize(v2);
            Assert.That(expectedResult, Is.EqualTo(normalizedV2).Using(Vector3Comparer.Epsilon));
            Assert.That(expectedResult, Is.EqualTo(v2.Normalized()).Using(Vector3Comparer.Epsilon));
            Assert.That(expectedResult, Is.Not.EqualTo(v2).Using(Vector3Comparer.Epsilon));
        }

        [Test]
        public void Transform()
        {
            // STANDART OVERLOADS TEST

            var expectedResult1 = new Vector3(51, 58, 65);
            var expectedResult2 = new Vector3(33, -14, -1);

            var v1 = new Vector3(1, 2, 3);
            var m1 = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            var v2 = new Vector3(1, 2, 3);
            var q1 = new Quaternion(2, 3, 4, 5);

            Vector3 result1;
            Vector3 result2;

            Assert.That(expectedResult1, Is.EqualTo(Vector3.Transform(v1, m1)).Using(Vector3Comparer.Epsilon));
            Assert.That(expectedResult2, Is.EqualTo(Vector3.Transform(v2, q1)).Using(Vector3Comparer.Epsilon));

            // OUTPUT OVERLOADS TEST

            Vector3.Transform(ref v1, ref m1, out result1);
            Vector3.Transform(ref v2, ref q1, out result2);

            Assert.That(expectedResult1, Is.EqualTo(result1).Using(Vector3Comparer.Epsilon));
            Assert.That(expectedResult2, Is.EqualTo(result2).Using(Vector3Comparer.Epsilon));
        }
    }
}
