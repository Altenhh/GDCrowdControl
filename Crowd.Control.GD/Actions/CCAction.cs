// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Threading;
using osu.Framework.Bindables;

namespace Crowd.Control.GD.Actions
{
    public abstract class CCAction
    {
        public int Id;

        public abstract string Name { get; }

        public abstract BindableInt Price { get; }

        public abstract void Execute();

        public void Click()
        {
            CursorControl.MouseEvent(MouseEventFlags.LeftDown);
            CursorControl.MouseEvent(MouseEventFlags.LeftUp);
        }

        public void Click(MousePoint position)
        {
            CursorControl.SetCursorPosition(position);

            Thread.Sleep(10);

            CursorControl.MouseEvent(MouseEventFlags.LeftDown);
            CursorControl.MouseEvent(MouseEventFlags.LeftUp);
        }
    }
}
