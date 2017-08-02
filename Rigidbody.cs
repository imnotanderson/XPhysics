using JMath;

namespace XPhysics
{
    public class Rigidbody
    {
        internal Shape shape;
        internal bool isStatic = false;
        internal Vector2 speed;
        internal bool dead = false;

        public Rigidbody(bool isStatic,Vector2 pos, params Vector2[] points)
        {
            shape = new Shape(pos, points);
            this.isStatic = isStatic;
        }
    }
}