﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Build.Framework
{
    /// <summary>
    /// The argument for a property reassignment event.
    /// </summary>
    [Serializable]
    public class PropertyReassignmentEventArgs : BuildStatusEventArgs
    {
        /// <summary>
        /// Creates an instance of the PropertyReassignmentEventArgs class.
        /// </summary>
        public PropertyReassignmentEventArgs()
        {
        }

        /// <summary>
        /// Creates an instance of the PropertyReassignmentEventArgs class.
        /// </summary>
        /// <param name="propertyName">The name of the property whose value was reassigned.</param>
        /// <param name="previousValue">The previous value of the reassigned property.</param>
        /// <param name="newValue">The new value of the reassigned property.</param>
        /// <param name="location">The location of the reassignment.</param>
        public PropertyReassignmentEventArgs(
            string propertyName,
            string previousValue,
            string newValue,
            string location,
            string message,
            string helpKeyword = null,
            string senderName = null) : base(message, helpKeyword, senderName)
        {
            this.PropertyName = propertyName;
            this.PreviousValue = previousValue;
            this.NewValue = newValue;
            this.Location = location;
        }

        /// <summary>
        /// The name of the property whose value was reassigned.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// The previous value of the reassigned property.
        /// </summary>
        public string PreviousValue { get; set; }

        /// <summary>
        /// The new value of the reassigned property.
        /// </summary>
        public string NewValue { get; set; }

        /// <summary>
        /// The location of the reassignment.
        /// </summary>
        public string Location { get; set; }
    }
}