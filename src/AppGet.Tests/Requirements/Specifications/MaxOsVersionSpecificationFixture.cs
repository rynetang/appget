﻿using AppGet.HostSystem;
using AppGet.Manifests;
using AppGet.Requirements.Specifications;
using FluentAssertions;
using NUnit.Framework;

namespace AppGet.Tests.Requirements.Specifications
{
    [TestFixture]
    public class MaxOsVersionSpecificationFixture : TestBase<MaxOsVersionSpecification>
    {
        [Test]
        public void should_be_true_when_max_has_not_been_set()
        {
            Mocker.GetMock<IEnvironmentProxy>()
                  .SetupGet(s => s.WindowsVersion)
                  .Returns(WindowsVersion.Eight);

            Subject.IsRequirementSatisfied(new Installer()).Success.Should().BeTrue();
        }

        [Test]
        public void should_be_true_when_OS_is_less_than_max()
        {
            Mocker.GetMock<IEnvironmentProxy>()
                  .SetupGet(s => s.WindowsVersion)
                  .Returns(WindowsVersion.Seven);

            Subject.IsRequirementSatisfied(new Installer
                                           {
                                               MaxWindowsVersion = WindowsVersion.EightOne
                                           }).Success.Should().BeTrue();
        }

        [Test]
        public void should_be_false_when_OS_is_greater_than_max()
        {
            Mocker.GetMock<IEnvironmentProxy>()
                  .SetupGet(s => s.WindowsVersion)
                  .Returns(WindowsVersion.Eight);

            Subject.IsRequirementSatisfied(new Installer
                                           {
                                               MaxWindowsVersion = WindowsVersion.Seven
                                           }).Success.Should().BeFalse();
        }
    }
}