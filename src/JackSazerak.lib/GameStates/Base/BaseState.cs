﻿// Copyright (c) 2018 Jarred Capellman
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;

using JackSazerak.lib.GameObjects.Base;
using JackSazerak.lib.IoC;
using JackSazerak.lib.Objects;

namespace JackSazerak.lib.GameStates.Base
{
    public abstract class BaseState
    {
        private double _mousePositionX;
        private double _mousePositionY;

        protected double _windowWidth;
        protected double _windowHeight;

        private List<BaseGameObject> _stateObjects;

        protected event EventHandler<Point> MousePositionChanged;

        public List<BaseGameObject> ResourceRenderables =>
            _stateObjects.Where(a => !string.IsNullOrEmpty(a.RenderObject.ResouceFileName)).ToList();

        protected BaseState()
        {
            _stateObjects = new List<BaseGameObject>();
        }
        
        protected BaseGameObject GetStateObject(Type type) => _stateObjects.FirstOrDefault(a => a.GetType() == type);

        protected void AddObject(BaseGameObject gameObject)
        {
            _stateObjects.Add(gameObject);
        }
        
        public void Render(object renderObject)
        {
            IOCContainer.GfxRenderer.Render(renderObject, _stateObjects);
        }

        public void UpdateWindowBounds(double width, double height)
        {
            _windowHeight = height;
            _windowWidth = width;
        }

        public void UpdateMousePosition(double positionX, double positionY)
        {
            _mousePositionX = positionX;
            _mousePositionY = positionY;

            MousePositionChanged?.Invoke(null, new Point((float) _mousePositionX, (float) _mousePositionY));
        }
    }
}