using JMath;
using UnityEngine;
using Vector2 = JMath.Vector2;

namespace XPhysics
{
    public class WorldTest:MonoBehaviour
    {
        private World w;

        void Start()
        {
            Init();
        }
        
        void OnDrawGizmos()
        {
            if (w == null) return;
            for (int i = 0; i < w.bodyList.Count; i++)
            {
                var body = w.bodyList[i];
                for (int j = 0; j < body.shape.Count; j++)
                {
                    var k = j + 1 == body.shape.Count ? 0 : j + 1;
                    var pos1 = body.shape[j];
                    var pos2 = body.shape[k];
                    Gizmos.DrawLine(pos1.Val, pos2.Val);
                }
            }
        }

        void Update()
        {
            w.Upt();
        }

        void Init()
        {
            w = new World();
            Float offset = 5f;
            var r = new Rigidbody(true, Vector2.zero,
                new Vector2(-3f, 0.1f), new Vector2(10f, 0.1f + offset),
                new Vector2(10f, -0.1f + offset), new Vector2(-3f, -0.1f));

            w.AddRigidBody(r);

            r = new Rigidbody(false, Vector2.up * 10, new Vector2(-0.5f, 0.5f), new Vector2(0.5f, 0.5f),
                new Vector2(0.5f, -0.5f), new Vector2(-0.5f, -0.5f));
            w.AddRigidBody(r);
        }
    }
}