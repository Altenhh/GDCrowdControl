// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace CC.GD.Service.Actions
{
    public abstract class CCAction : IDisposable
    {
        public int Id;

        /// <summary>
        /// Name of the action.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Initial price of the action.
        /// </summary>
        public abstract int Price { get; }

        /// <summary>
        /// Length of the action (in ms). If the value is set to 0, then the <see cref="Update"/> Function will not be called.
        /// </summary>
        public virtual int Length { get; }

        /// <summary>
        /// Called when initially started.
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Called every update frame
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Called when action is finished.
        /// </summary>
        public virtual void Dispose() { }

        public void Click()
        {
            CursorControl.MouseEvent(MouseEventFlags.LeftDown);
            CursorControl.MouseEvent(MouseEventFlags.LeftUp);
        }
    }
}
