﻿using TddBuddy.CleanArchitecture.Utils.TOs;
using Xunit;

namespace Tddbuddy.CleanArchitecture.Utils.Tests.TOs
{
    
    public class ErrorOutputToTests
    {
        [Fact]
        public void FetchErrors_WhenConstructed_ShouldReturnList()
        {
            //---------------Set up test pack-------------------
            //---------------Execute Test ----------------------
            var result = new ErrorOutputTo();
            //---------------Test Result -----------------------
            Assert.NotNull(result.FetchErrors());
        }

        [Fact]
        public void HasErrors_WhenNoErrors_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var errorOutputTo = new ErrorOutputTo();
            //---------------Execute Test ----------------------
            var result = errorOutputTo.HasErrors;
            //---------------Test Result -----------------------
            Assert.False(result);
        }

        [Fact]
        public void HasErrors_WhenErrors_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var errorOutputTo = new ErrorOutputTo();
            errorOutputTo.AddError("test error");
            //---------------Execute Test ----------------------
            var result = errorOutputTo.HasErrors;
            //---------------Test Result -----------------------
            Assert.True(result);
        }
    }
}
