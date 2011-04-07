/*
Copyright � Joan Charmant 2008.
joan.charmant@gmail.com 
 
This file is part of Kinovea.

Kinovea is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License version 2 
as published by the Free Software Foundation.

Kinovea is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Kinovea. If not, see http://www.gnu.org/licenses/.

*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using Kinovea.Services;

namespace Kinovea.ScreenManager
{
	/// <summary>
	/// Describes a generic drawing.
	/// </summary>
    public abstract class AbstractDrawing
    {
    	/// <summary>
    	/// Gets or set the fading object for this drawing. 
    	/// This is used in opacity calculation for Persistence.
    	/// </summary>
        public abstract InfosFading infosFading
        {
            get;
            set;
        }
        
        /// <summary>
        /// Draws this drawing on the provided canvas.
        /// The drawing must be drawn at the proper scale and place in the canvas.
        /// </summary>
        /// <param name="_canvas">The GDI+ surface on which to draw</param>
        /// <param name="_fStretchFactor">The scaling factor between the canvas and the original image size</param>
        /// <param name="_bSelected">Whether the drawing is currently selected</param>
        /// <param name="_iCurrentTimestamp">The current time position in the video</param>
        /// <param name="_DirectZoomTopLeft">The position of the zoom window relatively to the top left corner of the original image</param>
        public abstract void Draw(Graphics _canvas, double _fStretchFactor, bool _bSelected, long _iCurrentTimestamp, Point _DirectZoomTopLeft);
        
        /// <summary>
        /// Evaluates if a particular point is inside the drawing, on a handler, or completely outside the drawing.
        /// </summary>
        /// <param name="_point">The coordinates at original image scale of the point to evaluate</param>
        /// <param name="_iCurrentTimestamp">The current time position in the video</param>
        /// <returns>-1 : missed. 0 : The drawing as a whole has been hit. n (with n>0) : The id of a manipulation handle that has been hit</returns>
        public abstract int HitTest(Point _point, long _iCurrentTimestamp);
        
        /// <summary>
        /// Move the specified handle to its new location.
        /// </summary>
        /// <param name="point">The new location of the handle, in original image scale coordinates</param>
        /// <param name="handleNumber">The handle identifier</param>
        public abstract void MoveHandle(Point point, int handleNumber);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_deltaX"></param>
        /// <param name="_deltaY"></param>
        
        /// <summary>
        /// Move the drawing as a whole.
        /// </summary>
        /// <param name="_deltaX">Change in x coordinates</param>
        /// <param name="_deltaY">Change in y coordinates</param>
        /// <param name="_ModifierKeys">Modifiers key pressed while moving the drawing</param>
        public abstract void MoveDrawing(int _deltaX, int _deltaY, Keys _ModifierKeys);
    }
}
