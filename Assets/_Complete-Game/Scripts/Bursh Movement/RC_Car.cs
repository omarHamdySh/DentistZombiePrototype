namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;



    public class RC_Car : MonoBehaviour
    {

        private Vector2 touchAxis;
        private float triggerAxis;

        public void SetTouchAxis(Vector2 data)
        {
            touchAxis = data;
        }

        public void SetTriggerAxis(float data)
        {
            triggerAxis = data;
        }

        private void FixedUpdate()
        {
            Turn();
        }

        private void Turn()
        {
            if (touchAxis != new Vector2(500, 500))
            {

                //transform
                if (touchAxis.y < .5)
                {
                    if (transform.localPosition.x <= 0.2)
                    {
                        transform.localPosition += new Vector3(0.007f, 0, 0);
                    }

                }

                if (touchAxis.y > -.5)
                {
                    if (transform.localPosition.x >= -0.1)
                    {
                        transform.localPosition -= new Vector3(0.007f, 0, 0);
                    }
                }

            }
        }

    } //end of the class
} //enf of the namespaces