﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;
using NUnit.Framework;

namespace CleanArchitecture.Presentation.Employees
{
    [TestFixture]
    public class EmployeesControllerTests
    {
        private EmployeesController _controller;
        private AutoMoqer _mocker;
        private EmployeeModel _model;

        [SetUp]
        public void SetUp()
        {
            _model = new EmployeeModel();

            _mocker = new AutoMoqer();

            _mocker.GetMock<IGetEmployeesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<EmployeeModel> { _model });

            _controller = _mocker.Create<EmployeesController>();
        }

        [Test]
        public void TestGetIndexShouldReturnListOfEmployees()
        {
            var viewResult = _controller.Index();

            var result = (List<EmployeeModel>) viewResult.Model;

            Assert.That(result.Single(), Is.EqualTo(_model));
        }
    }
}