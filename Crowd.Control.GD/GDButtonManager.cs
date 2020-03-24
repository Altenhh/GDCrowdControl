// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using WindowsInput;
using WindowsInput.Native;

namespace Crowd.Control.GD
{
    public class GDButtonManager
    {
        public static void DoAction(GDButtons actionToDo)
        {
            var keyboard = new InputSimulator().Keyboard;

            switch (actionToDo)
            {
                case GDButtons.Retry:
                    keyboard.KeyPress(VirtualKeyCode.ESCAPE);
                    Click(GDButtonsLocation.Retry);

                    break;

                case GDButtons.Practice:
                    keyboard.KeyPress(VirtualKeyCode.ESCAPE);
                    Click(GDButtonsLocation.Practice);

                    break;

                case GDButtons.Jump:
                    Click(changePosition: false);

                    break;
            }

            void Click(MousePoint position = new MousePoint(), bool changePosition = true)
            {
                if (changePosition)
                    CursorControl.SetCursorPosition(position);

                CursorControl.MouseEvent(MouseEventFlags.LeftDown);
                CursorControl.MouseEvent(MouseEventFlags.LeftUp);
            }
        }
    }

    public enum GDButtons
    {
        Retry,
        Practice,
        Jump
    }

    public static class GDButtonsLocation
    {
        public static MousePoint Retry = new MousePoint(1384, 646);

        public static MousePoint Practice = new MousePoint(534, 651);
    }
}
