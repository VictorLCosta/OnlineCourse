using System;
using Xunit;

namespace OnlineCourse.Test.Utils
{
    public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException exception, string message) 
        {
            if(exception.Message == message)
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem '{message}'");
        }
    }
}