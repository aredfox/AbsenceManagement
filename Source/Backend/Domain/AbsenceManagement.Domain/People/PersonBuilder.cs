﻿using NodaTime;
using System;

namespace AbsenceManagement.Domain.People
{
    public sealed class PersonBuilder        
    {
        private string _firstName;
        private string _lastName;
        private string _dataSource = "SYSTEM";
        private string _dataSourceId = SystemClock.Instance.Now.Ticks.ToString();        

        private PersonBuilder(string firstName, string lastName) {
            _firstName = firstName;
            _lastName = lastName;
        }

        public static PersonBuilder CreatePerson(string firstName, string lastName) {
            return new PersonBuilder(firstName, lastName);
        }
        public PersonBuilder WithDataSource(string dataSource, string dataSourceId) {
            _dataSource = dataSource;
            _dataSourceId = dataSourceId;
            return this;
        }

        public Person Build() {
            return new Person(_firstName, _lastName, _dataSource, _dataSourceId);
        }
    }
}
