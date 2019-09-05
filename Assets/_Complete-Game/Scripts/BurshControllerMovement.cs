using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class BurshControllerMovement : MonoBehaviour
{
    public VRTK_ControllerEvents RightcontrollerEvents;

    private void Start()
    {
        RightcontrollerEvents.TouchpadAxisChanged += new ControllerInteractionEventHandler(doTouchpadAxisChanged);
        RightcontrollerEvents.TouchpadAxisChanged += new ControllerInteractionEventHandler(doTouchpadAxisChanged);
        RightcontrollerEvents.TouchpadPressed += new ControllerInteractionEventHandler(doTouchpadPressed);
        RightcontrollerEvents.TouchpadReleased += new ControllerInteractionEventHandler(doTouchpadReleased);
        RightcontrollerEvents.TouchpadSenseAxisChanged += new ControllerInteractionEventHandler(doTouchpadSenseAxisChanged);
        RightcontrollerEvents.TouchpadTouchEnd += new ControllerInteractionEventHandler(doTouchpadTouchEnd);
        RightcontrollerEvents.TouchpadTouchStart += new ControllerInteractionEventHandler(doTouchpadTouchStart);
        RightcontrollerEvents.TouchpadTwoAxisChanged += new ControllerInteractionEventHandler(doTouchpadTwoAxisChanged);
        RightcontrollerEvents.TouchpadTwoPressed += new ControllerInteractionEventHandler(doTouchpadTwoPressed);
        RightcontrollerEvents.TouchpadTwoReleased += new ControllerInteractionEventHandler(doTouchpadTwoReleased);
        RightcontrollerEvents.TouchpadTwoTouchEnd += new ControllerInteractionEventHandler(doTouchpadTwoTouchEnd);
        RightcontrollerEvents.TouchpadTwoTouchStart += new ControllerInteractionEventHandler(doTouchpadTwoTouchStart);
    }

    private void doTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

        print("TouchpadAxisChanged : " + e.touchpadAxis);
    }

    private void doTouchpadTwoTouchStart(object sender, ControllerInteractionEventArgs e)
    {

        print("TouchpadTwoTouchStart : " + e.buttonPressure);
    }
    private void doTouchpadTwoTouchEnd(object sender, ControllerInteractionEventArgs e)
    {

        print("TouchpadTwoTouchEnd : " + e.buttonPressure);
    }
    private void doTouchpadTwoReleased(object sender, ControllerInteractionEventArgs e)
    {

        print("TouchpadTwoPressed : " + e.buttonPressure);
    }
    private void doTouchpadTwoPressed(object sender, ControllerInteractionEventArgs e)
    {

        print("TouchpadTwoPressed : " + e.buttonPressure);
    }

    private void doTouchpadTwoAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

        print("TouchpadTwoAxisChanged : " + e.buttonPressure);
    }
    private void doTouchpadTouchStart(object sender, ControllerInteractionEventArgs e)
    {

        print("TouchpadTouchStart : " + e.buttonPressure);
    }
    private void doTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
    {

        print("TouchpadTouchEnd : " + e.buttonPressure);
    }
    private void doTouchpadSenseAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

        print("TouchpadSenseAxisChanged : " + e.buttonPressure);
    }

    private void doTouchpadPressed(object sender, ControllerInteractionEventArgs e)
    {

        print("TouchpadPressed : " + e.buttonPressure);
    }
    private void doTouchpadReleased(object sender, ControllerInteractionEventArgs e)
    {

        print("TouchpadReleased : " + e.buttonPressure);
    }
}
