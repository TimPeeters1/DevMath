using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Matrix4x4
    {
        public float[][] m = new float[4][] { new float[4], new float[4], new float[4], new float[4] };

        public Matrix4x4(float[][] matrix)
        {
            this.m = matrix;
        }

        public static Matrix4x4 Identity
        {
            get
            {
                return new Matrix4x4(
                         new float[4][] {
                    new float[4] { 1, 0, 0, 0 },
                    new float[4] { 0,1,0,0 },
                    new float[4] { 0,0,1,0 },
                    new float[4] { 0, 0, 0, 1 } }
                         );
            }
        }

        public float Determinant
        {
            get
            {
                //return new Matrix4x4(
                //    new float[4][]{
                //        new float[]{ m[0][0] * m[1][1], m[0][0] * m[1][2], m[0][0] * m[1][3],
                //                         m[0][0] * m[2][1], m[0][0] * m[2][2], m[0][0] * m[2][3],
                //                          m[0][0] * m[3][1], m[0][0] * m[3][2], m[0][0] * m[3][3] },
                //        new float[]{ },
                //        new float[]{ },
                //        new float[]{ },
                //        }

                //})

                //Too much.
                throw new NotImplementedException();
            }
        }

        public Matrix4x4 Inverse
        {
            get { throw new NotImplementedException(); }
        }

        public static Matrix4x4 Translate(Vector3 translation)
        {
            return new Matrix4x4(
                new float[4][]
                { new float[4] { 1, 0, 0, translation.x },
                  new float[4] { 0, 1, 0, translation.y },
                  new float[4] { 0, 0, 1, translation.z },
                  new float[4] { 0, 0, 0, 1 }
                });
        }

        public static Matrix4x4 Rotate(Vector3 rotation)
        {
            return RotateX(rotation.x) * (RotateY(rotation.y) * RotateZ(rotation.z));
        }

        public static Matrix4x4 RotateX(float rotation)
        {
            return new Matrix4x4(
                new float[4][]
                { new float[4] { 1, 0, 0, 0 },
                  new float[4] { 0, (float)Math.Cos(rotation), (float)-Math.Sin(rotation), 0 },
                  new float[4] { 0, (float)Math.Sin(rotation), (float)Math.Cos(rotation), 0 },
                  new float[4] { 0, 0, 0, 1 }
                });
        }

        public static Matrix4x4 RotateY(float rotation)
        {
            return new Matrix4x4(
                new float[4][]
                { new float[4] { (float)Math.Cos(rotation), 0, (float)-Math.Sin(rotation), 0 },
                  new float[4] { 0, 1, 0, 0 },
                  new float[4] { (float)Math.Sin(rotation), 0, (float)Math.Cos(rotation), 0 },
                  new float[4] { 0, 0, 0, 1 }
                });
        }

        public static Matrix4x4 RotateZ(float rotation)
        {
            return new Matrix4x4(
                new float[4][]
                { new float[4] { (float)Math.Cos(rotation), (float)-Math.Sin(rotation), 0, 0 },
                  new float[4] { (float)Math.Sin(rotation), (float)Math.Cos(rotation), 0, 0 },
                  new float[4] { 0, 0, 1, 0 },
                  new float[4] { 0, 0, 0, 1 }
                });
        }

        public static Matrix4x4 Scale(Vector3 scale)
        {
            return new Matrix4x4(
                new float[4][]
                { new float[4] { scale.x, 0, 0, 0 },
                  new float[4] { 0, scale.y, 0, 0 },
                  new float[4] { 0, 0, scale.z, 0 },
                  new float[4] { 0, 0, 0, 1 }
                });
        }

        private static float[] dotMatrixRow(Matrix4x4 lhs, Matrix4x4 rhs, int i)
        {
            return new float[4] {
                lhs.m[i][0] * rhs.m[0][0] + lhs.m[i][1] * rhs.m[1][0] + lhs.m[i][2] * rhs.m[2][0] + lhs.m[i][3] * rhs.m[3][0],
                lhs.m[i][0] * rhs.m[0][1] + lhs.m[i][1] * rhs.m[1][1] + lhs.m[i][2] * rhs.m[2][1] + lhs.m[i][3] * rhs.m[3][1],
                lhs.m[i][0] * rhs.m[0][2] + lhs.m[i][1] * rhs.m[1][2] + lhs.m[i][2] * rhs.m[2][2] + lhs.m[i][3] * rhs.m[3][2],
                lhs.m[i][0] * rhs.m[0][3] + lhs.m[i][1] * rhs.m[1][3] + lhs.m[i][2] * rhs.m[2][3] + lhs.m[i][3] * rhs.m[3][3] };
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            float[][] m =
                        new float[4][]
                        {
                            dotMatrixRow(lhs, rhs, 0),
                            dotMatrixRow(lhs, rhs, 1),
                            dotMatrixRow(lhs, rhs, 2),
                            dotMatrixRow(lhs, rhs, 3)
                        };
            return new Matrix4x4(m);
        }


        public static Vector4 operator *(Matrix4x4 lhs, Vector4 rhs)
        {
            throw new NotImplementedException();
        }
    }
}
