﻿using System;
using Xunit.Abstractions;

#if XUNIT_CORE_DLL
namespace Xunit.Sdk
#else
namespace Xunit
#endif
{
    /// <summary>
    /// Default implementation of <see cref="ITestFailed"/>.
    /// </summary>
    public class TestFailed : TestResultMessage, ITestFailed
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestFailed"/> class.
        /// </summary>
        public TestFailed(ITestCase testCase,
                          string testDisplayName,
                          decimal executionTime,
                          string output,
                          string[] exceptionTypes,
                          string[] messages,
                          string[] stackTraces,
                          int[] exceptionParentIndices)
            : base(testCase, testDisplayName, executionTime, output)
        {
            StackTraces = stackTraces;
            Messages = messages;
            ExceptionTypes = exceptionTypes;
            ExceptionParentIndices = exceptionParentIndices;
        }

#if XUNIT_CORE_DLL
        /// <summary>
        /// Initializes a new instance of the <see cref="TestFailed"/> class.
        /// </summary>
        public TestFailed(ITestCase testCase,
                          string testDisplayName,
                          decimal executionTime,
                          string output,
                          Exception ex)
            : base(testCase, testDisplayName, executionTime, output)
        {
            var failureInfo = ExceptionUtility.ConvertExceptionToFailureInformation(ex);
            ExceptionTypes = failureInfo.ExceptionTypes;
            Messages = failureInfo.Messages;
            StackTraces = failureInfo.StackTraces;
            ExceptionParentIndices = failureInfo.ExceptionParentIndices;
        }
#endif

        /// <inheritdoc/>
        public string[] ExceptionTypes { get; private set; }

        /// <inheritdoc/>
        public string[] Messages { get; private set; }

        /// <inheritdoc/>
        public string[] StackTraces { get; private set; }

        /// <inheritdoc/>
        public int[] ExceptionParentIndices { get; private set; }
    }
}