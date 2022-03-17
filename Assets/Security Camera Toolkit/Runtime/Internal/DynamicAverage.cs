﻿// Copyright (c) https://github.com/Bian-Sh
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;

namespace zFramework.Media
{
    /// <summary>
    /// manage a dynamic average of a time series.
    /// <para>时间维度上的动态平均值</para>
    /// </summary>
    public class DynamicAverage
    {
        /// <summary>
        /// Number of samples in the moving average window.
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        /// Average value of the samples.
        /// </summary>
        public float Average { get; private set; } = 0f;

        /// <summary>
        /// Queue of samples in the moving window.
        /// </summary>
        private Queue<float> _samples;

        /// <summary>
        /// Create a new moving average with a given window size.
        /// </summary>
        /// <param name="capacity">The capacity of the sample window.</param>
        public DynamicAverage(int capacity)
        {
            Capacity = capacity;
            _samples = new Queue<float>(capacity);
        }

        /// <summary>
        /// Clear the moving average and discard all cached samples.
        /// </summary>
        public void Clear()
        {
            _samples.Clear();
            Average = 0f;
        }

        /// <summary>
        /// Push a new sample and recalculate the current average.
        /// </summary>
        /// <param name="value">The new value to add.</param>
        public void Push(float value)
        {
            var count = _samples.Count + 1;
            if (count <= Capacity)
            {
                Average += (value - Average) / count;
                Debug.Assert(!float.IsNaN(Average));
                _samples.Enqueue(value);
            }
            else
            {
                var popValue = _samples.Dequeue();
                Average += (value - popValue) / (count - 1);
                _samples.Enqueue(value);
            }
        }
    }
}
