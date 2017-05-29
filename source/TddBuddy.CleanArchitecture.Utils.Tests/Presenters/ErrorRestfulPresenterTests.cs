﻿using Microsoft.AspNetCore.Mvc;
using TddBuddy.CleanArchitecture.Domain.TOs;
using TddBuddy.CleanArchitecture.HttpResponses;
using TddBuddy.CleanArchitecture.Presenters;
using Xunit;

namespace Tddbuddy.CleanArchitecture.Tests.Presenters
{
    public class ErrorRestfulPresenterTests
    {
        [Fact]
        public void Render_GivenNoResponse_ShouldReturnOkResult()
        {
            //---------------Set up test pack-------------------
            var presenter = CreatePresenter();
            //---------------Execute Test ----------------------
            var result = presenter.Render() as OkResult;
            //---------------Test Result -----------------------
            Assert.NotNull(result);
        }

        [Fact]
        public void Render_GivenErrorResponse_ShouldReturnUnprocessableEntityResultWithContent()
        {
            //---------------Set up test pack-------------------
            var content = new ErrorOutputTo();
            var presenter = CreatePresenter();
            presenter.Respond(content);
            //---------------Execute Test ----------------------
            var result = presenter.Render() as UnprocessasbleEntityResult<ErrorOutputTo>;
            //---------------Test Result -----------------------
            Assert.NotNull(result);
            Assert.Equal(content, result.Value);
        }

        private ErrorRestfulPresenter<ErrorOutputTo> CreatePresenter()
        {
            return new ErrorRestfulPresenter<ErrorOutputTo>();
        }
    }
}