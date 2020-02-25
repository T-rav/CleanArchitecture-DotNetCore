﻿using StoneAge.CleanArchitecture.Domain;
using StoneAge.CleanArchitecture.Domain.Messages;
using StoneAge.CleanArchitecture.Domain.Output;
using StoneAge.CleanArchitecture.Saga;
using StoneAge.CleanArchitecture.Tests.Saga.Steps;

namespace StoneAge.CleanArchitecture.Tests.Saga.UseCases
{
    public class TestUseCaseDi : IUseCase<TestInput, TestResult>
    {
        private readonly AddStep _addTask;
        private readonly AddStepWithDi _addWithDiTask;

        public TestUseCaseDi(AddStep addTask, AddStepWithDi addWithDiTask)
        {
            _addTask = addTask;
            _addWithDiTask = addWithDiTask;
        }

        public void Execute(TestInput inputTo, IRespondWithSuccessOrError<TestResult, ErrorOutput> presenter)
        {
            var context = new TestContext
            {
                a = inputTo.a,
                b = inputTo.b
            };

            var workflowResult = new SagaBuilder<TestContext>()
                            .With_Context_State(context)
                            .Using_Step(_addTask)
                            .Using_Step(_addWithDiTask)
                            .With_Roll_Back_Action_On_Error((ctx) =>
                            {
                                presenter.Respond(new ErrorOutput("Error on step 2"));
                            })
                            .With_Finish_Action((ctx) =>
                            {
                                presenter.Respond(new TestResult
                                {
                                    Result = ctx.c
                                });
                            })
                            .Run();
        }
    }
}
