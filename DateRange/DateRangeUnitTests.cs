using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace DateRange
{
    class DateRangeUnitTests
    {
        [TestMethod]
        [TestCase(new object[] {"2018-05-01", "2018-05-25"}, TestName =
            "GetRangeTest_CorrectInput_DayDifference_Y-M-D")]
        [TestCase(new object[] { "2018-5-1", "2018-5-25" }, TestName =
            "GetRangeTest_CorrectInput_DayDifference_Y-m-d")]
        [TestCase(new object[] {"01.05.2018", "25.05.2018"}, TestName =
            "GetRangeTest_CorrectInput_DayDifference_D.M.Y")]
        [TestCase(new object[] { "01/05/2018", "25/05/2018" }, TestName =
            "GetRangeTest_CorrectInput_DayDifference_D/M/Y")]
        [TestCase(new object[] { "01 May 2018", "25 May 2018" }, TestName =
            "GetRangeTest_CorrectInput_DayDifference_D Month Y")]
        [TestCase(new object[] { "01 Maj 2018", "25 Maj 2018" }, TestName =
            "GetRangeTest_CorrectInput_DayDifference_D Month Y PL")]
        [TestCase(new object[] { "Maj 1, 2018", "Maj  25, 2018" }, TestName =
            "GetRangeTest_CorrectInput_DayDifference_Month D Y PL")]
        [TestCase(new object[] { "1 Maja 2018", "25 Maja 2018" }, TestName =
            "GetRangeTest_CorrectInput_DayDifference_D MonthLong Y PL")]
        public void GetRangeTest_CorrectInput_DayDifference(object[] args)
        {
            //Arrange
            var dateRange = new DateRange();
            var stringDates = Array.ConvertAll(args, x => x.ToString());
            //Act
            var result = dateRange.GetRange(stringDates);
            //Assert
            Assert.AreEqual("01 - 25.05.2018", result);
        }

        [TestMethod]
        [TestCase(new object[] { "2018-04-26", "2018-05-24" }, TestName =
            "GetRangeTest_CorrectInput_MonthDifference_Y-M-D")]
        [TestCase(new object[] { "26.04.2018", "24.05.2018" }, TestName =
            "GetRangeTest_CorrectInput_MonthDifference_D.M.Y")]
        [TestCase(new object[] { "26/04/2018", "24/05/2018" }, TestName =
            "GetRangeTest_CorrectInput_MonthDifference_D/M/Y")]
        [TestCase(new object[] { "26 April 2018", "24 May 2018" }, TestName =
            "GetRangeTest_CorrectInput_MonthDifference_D Month Y")]
        [TestCase(new object[] { "26 Kwiecień 2018", "24 Maj 2018" }, TestName =
            "GetRangeTest_CorrectInput_MonthDifference_D Month Y PL")]
        public void GetRangeTest_CorrectInput_MonthDifference(object[] args)
        {
            //Arrange
            var dateRange = new DateRange();
            var stringDates = Array.ConvertAll(args, x => x.ToString());
            //Act
            var result = dateRange.GetRange(stringDates);
            //Assert
            Assert.AreEqual(result, "26.04 - 24.05.2018");
        }

        [TestMethod]
        [TestCase(new object[] { "2017-02-01", "2018-11-23" }, TestName =
            "GetRangeTest_CorrectInput_YearDifference_Y-M-D")]
        [TestCase(new object[] { "01.02.2017", "23.11.2018" }, TestName =
            "GetRangeTest_CorrectInput_YearDifference_D.M.Y")]
        [TestCase(new object[] { "01/02/2017", "23/11/2018" }, TestName =
            "GetRangeTest_CorrectInput_YearDifference_D.M.Y")]
        [TestCase(new object[] { "01 February 2017", "23 November 2018" }, TestName =
            "GetRangeTest_CorrectInput_YearDifference_D Month Y")]
        [TestCase(new object[] { "01 Luty 2017", "23 Listopad 2018" }, TestName =
            "GetRangeTest_CorrectInput_YearDifference_D Month Y PL")]
        public void GetRangeTest_CorrectInput_YearDifference(object[] args)
        {
            //Arrange
            var dateRange = new DateRange();
            var stringDates = Array.ConvertAll(args, x => x.ToString());
            //Act
            var result = dateRange.GetRange(stringDates);
            //Assert
            Assert.AreEqual(result, "01.02.2017 - 23.11.2018");
        }

        [TestMethod]
        [TestCase(new object[] { "01 Listopad 2017", "23 Listopad 2018" }, TestName =
            "GetRangeTest_CorrectInput_YearDifference_SameMonth")]
        public void GetRangeTest_CorrectInput_YearDifference_EqualMonth(object[] args)
        {
            //Arrange
            var dateRange = new DateRange();
            var stringDates = Array.ConvertAll(args, x => x.ToString());
            //Act
            var result = dateRange.GetRange(stringDates);
            //Assert
            Assert.AreEqual(result, "01.11.2017 - 23.11.2018");
        }

        [TestMethod]
        [TestCase(new object[]{"23.10.1993", "23.10.1993"}, TestName = "GetRangeTest_IncorrectInput_EqualDate_SameFormat")]
        [TestCase(new object[] { "23.10.1993", "23 października 1993" }, TestName = "GetRangeTest_IncorrectInput_EqualDate_DifferentFormat")]
        public void GetRangeTest_IncorrectInput_EqualDate(object[] args)
        {
            //Arrange
            var dateRange = new DateRange();
            var stringDates = Array.ConvertAll(args, x => x.ToString());
            //Act
            var result = dateRange.GetRange(stringDates);
            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [TestCase(new object[] { "23.10.1993", "25.08.1993" }, TestName = "GetRangeTest_IncorrectInput_SecondDateIsEarlier_SameFormat")]
        [TestCase(new object[] { "23.10.1993", "25 sierpnia 1993" }, TestName = "GetRangeTest_IncorrectInput_SecondDateIsEarlier_DifferentFormat")]
        public void GetRangeTest_IncorrectInput_SecondDateIsEarlier(object[] args)
        {
            //Arrange
            var dateRange = new DateRange();
            var stringDates = Array.ConvertAll(args, x => x.ToString());
            //Act
            var result = dateRange.GetRange(stringDates);
            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [TestCase(new object[] { "07/13/1993", "08/25/1993" }, TestName = "GetRangeTest_IncorrectInput_WrongDateFormat_US")]
        [TestCase(new object[] { "trzynasty lipca 1993 ", "dwudziestypiąty sierpnia 1993" }, TestName = "GetRangeTest_IncorrectInput_WrongDateFormat_Words")]
        [TestCase(new object[] { "54g334(JJD##$ ", "#*JFDs((UIF" }, TestName = "GetRangeTest_IncorrectInput_WrongDateFormat_RandomCharacters")]

        public void GetRangeTest_IncorrectInput_WrongDateFormat(object[] args)
        {
            //Arrange
            var dateRange = new DateRange();
            var stringDates = Array.ConvertAll(args, x => x.ToString());
            //Act
            var result = dateRange.GetRange(stringDates);
            //Assert
            Assert.IsNull(result);
        }


        [TestMethod]
        [TestCase(new object[] { "2017-02-01", "2018-11-23", "2019-04-02" }, TestName = "GetRangeTest_IncorrectInput_WrongInputArgumentsNumber_Three")]
        [TestCase(new object[] { "21-03-1833"}, TestName = "GetRangeTest_IncorrectInput_WrongInputArgumentsNumber_One")]
        public void GetRangeTest_IncorrectInput_WrongInputArgumentsNumber(object[] args)
        {
            //Arrange
            var dateRange = new DateRange();
            var stringDates = Array.ConvertAll(args, x => x.ToString());
            //Act
            var result = dateRange.GetRange(stringDates);
            //Assert
            Assert.AreEqual(result, null);
        }

    }
}