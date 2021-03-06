﻿namespace Xunit.Abstractions
{
    /// <summary>
    /// This message indicates that a test was skipped.
    /// </summary>
    public interface ITestSkipped : ITestResultMessage
    {
        /// <summary>
        /// The reason given for skipping the test.
        /// </summary>
        string Reason { get; }
    }
}