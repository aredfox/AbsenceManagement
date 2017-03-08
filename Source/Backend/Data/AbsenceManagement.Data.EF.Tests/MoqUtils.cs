﻿using AbsenceManagement.Domain.People;
using AbsenceManagement.Domain.Tests;
using Coderful.EntityFramework.Testing.Mock;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AbsenceManagement.Data.EF.Tests
{
    public static class MoqUtils
    {
        public static Mock<AbsenceManagementContext> MockDbContext(
        IList<Person> people = null) {
            var mockContext = new Mock<AbsenceManagementContext>();

            people = people
                ?? TestData.GetPeopleTestData()
                           .Select(o => o[0])
                           .Cast<Person>()
                           .ToList();

            mockContext
                .MockDbSet(people, (o, p) => p.Id == (Guid)o[0]);

            return mockContext;
        }
    }
}
