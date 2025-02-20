/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;

namespace QuantConnect.Logging
{
    /// <summary>
    /// Provides an <see cref="ILogHandler"/> implementation that composes multiple handlers
    /// </summary>
    public class CompositeLogHandler : ILogHandler
    {
        private readonly ILogHandler[] _handlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeLogHandler"/> that pipes log messages to the console and log.txt
        /// </summary>
        public CompositeLogHandler()
            : this(new ConsoleLogHandler(), new FileLogHandler())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeLogHandler"/> class from the specified handlers
        /// </summary>
        /// <param name="handlers">The implementations to compose</param>
        public CompositeLogHandler(params ILogHandler[] handlers)
        {
            if (handlers == null || handlers.Length == 0)
            {
                throw new ArgumentNullException(nameof(handlers));
            }

            _handlers = handlers;
        }

        /// <summary>
        /// Write error message to log
        /// </summary>
        /// <param name="text"></param>
        public void Error(string text)
        {
            var stackFrame = new System.Diagnostics.StackFrame(2, true); // 获取上层调用堆栈
            var fileName = stackFrame.GetFileName(); // 文件名
            var lineNumber = stackFrame.GetFileLineNumber(); // 行号
            var formattedMessage = $"[{fileName}:{lineNumber}] {text}";
            foreach (var handler in _handlers)
            {
                handler.Error(formattedMessage);
            }
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text"></param>
        public void Debug(string text)
        {
            var stackFrame = new System.Diagnostics.StackFrame(2, true); // 获取上层调用堆栈
            var fileName = stackFrame.GetFileName(); // 文件名
            var lineNumber = stackFrame.GetFileLineNumber(); // 行号
            var formattedMessage = $"[{fileName}:{lineNumber}] {text}";
            foreach (var handler in _handlers)
            {
                handler.Debug(formattedMessage);
            }
        }

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="text"></param>
        public void Trace(string text)
        {
            var stackFrame = new System.Diagnostics.StackFrame(2, true); // 获取上层调用堆栈
            var fileName = stackFrame.GetFileName(); // 文件名
            var lineNumber = stackFrame.GetFileLineNumber(); // 行号
            var formattedMessage = $"[{fileName}:{lineNumber}] {text}";
            foreach (var handler in _handlers)
            {
                handler.Trace(formattedMessage);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            foreach (var handler in _handlers)
            {
                handler.Dispose();
            }
        }
    }
}
