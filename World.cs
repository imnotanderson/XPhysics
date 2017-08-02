using System.Collections.Generic;
using JMath;

namespace XPhysics
{
    public class World
    {
        private Float timeStep = 0.02f;
        Vector2 g = new Vector2(0, -10);
        public List<Rigidbody> bodyList = new List<Rigidbody>();

        public void AddRigidBody(Rigidbody body)
        {
            bodyList.Add(body);
        }

        public void Upt()
        {
            Move();
            Collision();
        }

        void Move()
        {
            for (int i = 0; i < bodyList.Count; i++)
            {
                var body = bodyList[i];
                if (body.dead || body.isStatic) continue;
                body.speed += timeStep * g;
                body.shape.pos += timeStep * body.speed;
            }
        }

        void Collision()
        {
            for (int i = 0; i < bodyList.Count; i++)
            {
                var body = bodyList[i];
                if (body.dead || body.isStatic) continue;
                Vector2 dir = Vector2.zero;
                for (int j = 0; j < bodyList.Count; j++)
                {
                    var otherBody = bodyList[j];
                    if (otherBody.dead) continue;
                    HandleCollision(body, otherBody, ref dir);
                }
                body.shape.pos += dir;
            }
        }

        void HandleCollision(Rigidbody body, Rigidbody otherBody, ref Vector2 dir)
        {
            if (body == otherBody) return;
            var depth = body.shape.GetGjkDepth(otherBody.shape);
            dir -= depth;
            
            var f = body.speed.Dot(-depth);
            if (f < 0)
            {
                body.speed += f * body.speed.normalized;
            }
        }

    }
}